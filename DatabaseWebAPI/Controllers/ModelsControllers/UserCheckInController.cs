/*
 * Project Name:  DatabaseWebAPI
 * File Name:     UserCheckInController.cs
 * File Function: UserCheckIn 控制器
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-09-04
 * License:       Creative Commons Attribution 4.0 International License
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseWebAPI.Data;
using DatabaseWebAPI.Models.TableModels;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Controllers.ModelsControllers;

[Route("api/user-check-in")]
[ApiController]
[SwaggerTag("用户打卡表相关 API")]
public class UserCheckInController(OracleDbContext context) : ControllerBase
{
    // 获取用户打卡表的所有数据
    [HttpGet]
    [SwaggerOperation(Summary = "获取用户打卡表的所有数据", Description = "获取用户打卡表的所有数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<UserCheckIn>>> GetUserCheckIn()
    {
        try
        {
            return Ok(await context.UserCheckInSet.ToListAsync());
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

    // 根据主键（ID）获取用户打卡表的数据
    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取用户打卡表的数据", Description = "根据主键（ID）获取用户打卡表的数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<UserCheckIn>> GetUserCheckInByPk(int id)
    {
        try
        {
            var userCheckIn = await context.UserCheckInSet.FindAsync(id);
            if (userCheckIn == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            return Ok(userCheckIn);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）删除用户打卡表的数据
    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）删除用户打卡表的数据", Description = "根据主键（ID）删除用户打卡表的数据")]
    [SwaggerResponse(200, "删除数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<UserCheckIn>> DeleteUserCheckInByPk(int id)
    {
        try
        {
            var userCheckIn = await context.UserCheckInSet.FindAsync(id);
            if (userCheckIn == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            context.UserCheckInSet.Remove(userCheckIn);
            await context.SaveChangesAsync();
            return Ok($"Data with ID: {id} has been deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 向用户打卡表添加数据项
    [HttpPost]
    [SwaggerOperation(Summary = "向用户打卡表添加数据项", Description = "向用户打卡表添加数据项（不需要提供 CHECK_IN_ID，因为它是由系统自动生成的）")]
    [SwaggerResponse(201, "添加数据项成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> PostUserCheckIn([FromBody] UserCheckIn userCheckIn)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.UserCheckInSet.Add(userCheckIn);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostUserCheckIn), new { id = userCheckIn.CheckInId }, userCheckIn);
    }

    // 根据主键（ID）更新用户打卡表的数据
    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新用户打卡表的数据", Description = "根据主键（ID）更新用户打卡表的数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdateUserCheckIn(int id, [FromBody] UserCheckIn userCheckIn)
    {
        if (id != userCheckIn.CheckInId)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Entry(userCheckIn).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.UserCheckInSet.Any(e => e.CheckInId == id))
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

    // 判断用户在某一天是否存在打卡记录
    [HttpGet("check-by-date/{userId:int}-{date}")]
    [SwaggerOperation(Summary = "判断用户在某一天是否存在打卡记录", Description = "判断用户在某一天是否存在打卡记录")]
    [SwaggerResponse(200, "请求成功")]
    [SwaggerResponse(400, "请求失败")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<int>> CheckUserCheckInByDate(int userId, string date)
    {
        try
        {
            var parsedDate = DateTime.ParseExact(date, "yyyyMMdd", null);
            var userCheckIn = await context.UserCheckInSet
                .FirstOrDefaultAsync(uci => uci.UserId == userId && uci.CheckInTime.Date == parsedDate.Date);
            return Ok(userCheckIn != null ? 1 : 0);
        }
        catch (FormatException fe)
        {
            return BadRequest($"FormatException: {fe.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}