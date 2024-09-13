/*
 * Project Name:  DatabaseWebAPI
 * File Name:     UserSettingController.cs
 * File Function: UserSetting 控制器
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

[Route("api/user-setting")]
[ApiController]
[SwaggerTag("用户设置表相关 API")]
public class UserSettingController(OracleDbContext context) : ControllerBase
{
    // 获取用户设置表的所有数据
    [HttpGet]
    [SwaggerOperation(Summary = "获取用户设置表的所有数据", Description = "获取用户设置表的所有数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<UserSetting>>> GetUserSetting()
    {
        try
        {
            return Ok(await context.UserSettingSet.ToListAsync());
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

    // 根据主键（ID）获取用户设置表的数据
    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取用户设置表的数据", Description = "根据主键（ID）获取用户设置表的数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<UserSetting>> GetUserSettingByPk(int id)
    {
        try
        {
            var userSetting = await context.UserSettingSet.FindAsync(id);
            if (userSetting == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            return Ok(userSetting);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）删除用户设置表的数据
    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）删除用户设置表的数据", Description = "根据主键（ID）删除用户设置表的数据")]
    [SwaggerResponse(200, "删除数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<UserSetting>> DeleteUserSettingByPk(int id)
    {
        try
        {
            var userSetting = await context.UserSettingSet.FindAsync(id);
            if (userSetting == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            context.UserSettingSet.Remove(userSetting);
            await context.SaveChangesAsync();
            return Ok($"Data with ID: {id} has been deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 向用户设置表添加数据项
    [HttpPost]
    [SwaggerOperation(Summary = "向用户设置表添加数据项", Description = "向用户设置表添加数据项")]
    [SwaggerResponse(201, "添加数据项成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> PostUserSetting([FromBody] UserSetting userSetting)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.UserSettingSet.Add(userSetting);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostUserSetting), new { id = userSetting.UserId }, userSetting);
    }

    // 根据主键（ID）更新用户设置表的数据
    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新用户设置表的数据", Description = "根据主键（ID）更新用户设置表的数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdateUserSetting(int id, [FromBody] UserSetting userSetting)
    {
        if (id != userSetting.UserId)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Entry(userSetting).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.UserSettingSet.Any(e => e.UserId == id))
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