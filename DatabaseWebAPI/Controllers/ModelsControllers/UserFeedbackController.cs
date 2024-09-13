/*
 * Project Name:  DatabaseWebAPI
 * File Name:     UserFeedbackController.cs
 * File Function: UserFeedback 控制器
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-05
 * License:       Creative Commons Attribution 4.0 International License
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseWebAPI.Data;
using DatabaseWebAPI.Models.TableModels;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Controllers.ModelsControllers;

[Route("api/user-feedback")]
[ApiController]
[SwaggerTag("用户反馈表相关 API")]
public class UserFeedbackController(OracleDbContext context) : ControllerBase
{
    // 获取用户反馈表的所有数据
    [HttpGet]
    [SwaggerOperation(Summary = "获取用户反馈表的所有数据", Description = "获取用户反馈表的所有数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<UserFeedback>>> GetUserFeedback()
    {
        try
        {
            return Ok(await context.UserFeedbackSet.ToListAsync());
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

    // 根据主键（ID）获取用户反馈表的数据
    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取用户反馈表的数据", Description = "根据主键（ID）获取用户反馈表的数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<UserFeedback>> GetUserFeedbackByPk(int id)
    {
        try
        {
            var userFeedback = await context.UserFeedbackSet.FindAsync(id);
            if (userFeedback == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            return Ok(userFeedback);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）删除用户反馈表的数据
    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）删除用户反馈表的数据", Description = "根据主键（ID）删除用户反馈表的数据")]
    [SwaggerResponse(200, "删除数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<UserFeedback>> DeleteUserFeedbackByPk(int id)
    {
        try
        {
            var userFeedback = await context.UserFeedbackSet.FindAsync(id);
            if (userFeedback == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            context.UserFeedbackSet.Remove(userFeedback);
            await context.SaveChangesAsync();
            return Ok($"Data with ID: {id} has been deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 向用户反馈表添加数据项
    [HttpPost]
    [SwaggerOperation(Summary = "向用户反馈表添加数据项", Description = "向用户反馈表添加数据项（不需要提供 FEEDBACK_ID，因为它是由系统自动生成的）")]
    [SwaggerResponse(201, "添加数据项成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> PostUserFeedback([FromBody] UserFeedback userFeedback)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.UserFeedbackSet.Add(userFeedback);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostUserFeedback), new { id = userFeedback.FeedbackId }, userFeedback);
    }

    // 根据主键（ID）更新用户反馈表的数据
    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新用户反馈表的数据", Description = "根据主键（ID）更新用户反馈表的数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdateUserFeedback(int id, [FromBody] UserFeedback userFeedback)
    {
        if (id != userFeedback.FeedbackId)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Entry(userFeedback).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.UserFeedbackSet.Any(e => e.FeedbackId == id))
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
}