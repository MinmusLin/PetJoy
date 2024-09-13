﻿/*
 * Project Name:  DatabaseWebAPI
 * File Name:     UserMessageController.cs
 * File Function: UserMessage 控制器
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-09-07
 * License:       Creative Commons Attribution 4.0 International License
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseWebAPI.Data;
using DatabaseWebAPI.Models.TableModels;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Controllers.ModelsControllers;

[Route("api/user-message")]
[ApiController]
[SwaggerTag("用户留言表相关 API")]
public class UserMessageController(OracleDbContext context) : ControllerBase
{
    // 获取用户留言表的所有数据
    [HttpGet]
    [SwaggerOperation(Summary = "获取用户留言表的所有数据", Description = "获取用户留言表的所有数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<UserMessage>>> GetUserMessage()
    {
        try
        {
            return Ok(await context.UserMessageSet.ToListAsync());
        }
        catch (DbUpdateException dbEx)
        {
            return StatusCode(500, $"Database update error: {dbEx.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）获取用户留言表的数据
    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取用户留言表的数据", Description = "根据主键（ID）获取用户留言表的数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<UserMessage>> GetUserMessageByPk(int id)
    {
        try
        {
            var userMessage = await context.UserMessageSet.FindAsync(id);
            if (userMessage == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            return Ok(userMessage);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）删除用户留言表的数据
    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）删除用户留言表的数据", Description = "根据主键（ID）删除用户留言表的数据")]
    [SwaggerResponse(200, "删除数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<UserMessage>> DeleteUserMessageByPk(int id)
    {
        try
        {
            var userMessage = await context.UserMessageSet.FindAsync(id);
            if (userMessage == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            context.UserMessageSet.Remove(userMessage);
            await context.SaveChangesAsync();
            return Ok($"Data with ID: {id} has been deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 向用户留言表添加数据项
    [HttpPost]
    [SwaggerOperation(Summary = "向用户留言表添加数据项", Description = "向用户留言表添加数据项（不需要提供 MESSAGE_ID，因为它是由系统自动生成的）")]
    [SwaggerResponse(201, "添加数据项成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> PostUserMessage([FromBody] UserMessage userMessage)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.UserMessageSet.Add(userMessage);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostUserMessage), new { id = userMessage.MessageId }, userMessage);
    }

    // 根据主键（ID）更新用户留言表的数据
    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新用户留言表的数据", Description = "根据主键（ID）更新用户留言表的数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdateUserMessage(int id, [FromBody] UserMessage userMessage)
    {
        if (id != userMessage.MessageId)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Entry(userMessage).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.UserMessageSet.Any(e => e.MessageId == id))
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            throw;
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }

        return Ok($"Data with ID: {id} has been updated successfully.");
    }

    // 根据用户 ID（UserId）获取用户留言表的所有数据
    [HttpGet("user/{userId:int}")]
    [SwaggerOperation(Summary = "根据用户 ID（UserId）获取用户留言表的所有数据", Description = "根据用户 ID（UserId）获取用户留言表的所有数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<UserMessage>>> GetUserMessageByUserId(int userId)
    {
        try
        {
            return Ok(await context.UserMessageSet
                .Where(p => p.UserId == userId)
                .OrderByDescending(pc => pc.CommentTime)
                .ToListAsync());
        }
        catch (DbUpdateException dbEx)
        {
            return StatusCode(500, $"Database update error: {dbEx.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}