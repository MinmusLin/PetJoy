/*
 * Project Name:  DatabaseWebAPI
 * File Name:     UserFollowController.cs
 * File Function: UserFollow 控制器
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

[Route("api/user-follow")]
[ApiController]
[SwaggerTag("用户关注表相关 API")]
public class UserFollowController(OracleDbContext context) : ControllerBase
{
    // 获取用户关注表的所有数据
    [HttpGet]
    [SwaggerOperation(Summary = "获取用户关注表的所有数据", Description = "获取用户关注表的所有数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<UserFollow>>> GetUserFollow()
    {
        try
        {
            return Ok(await context.UserFollowSet.ToListAsync());
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

    // 根据主键（ID）获取用户关注表的数据
    [HttpGet("{userId:int}-{followerId:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取用户关注表的数据", Description = "根据主键（ID）获取用户关注表的数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<UserFollow>> GetUserFollowByPk(int userId, int followerId)
    {
        try
        {
            var userFollow =
                await context.UserFollowSet.FirstOrDefaultAsync(n =>
                    n.UserId == userId && n.FollowerId == followerId);
            if (userFollow == null)
            {
                return NotFound($"No corresponding data found for User ID: {userId} and Follower ID: {followerId}");
            }

            return Ok(userFollow);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）删除用户关注表的数据
    [HttpDelete("{userId:int}-{followerId:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）删除用户关注表的数据", Description = "根据主键（ID）删除用户关注表的数据")]
    [SwaggerResponse(200, "删除数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<UserFollow>> DeleteUserFollowByPk(int userId, int followerId)
    {
        try
        {
            var userFollow =
                await context.UserFollowSet.FirstOrDefaultAsync(n =>
                    n.UserId == userId && n.FollowerId == followerId);
            if (userFollow == null)
            {
                return NotFound($"No corresponding data found for User ID: {userId} and Follower ID: {followerId}");
            }

            context.UserFollowSet.Remove(userFollow);
            await context.SaveChangesAsync();
            return Ok($"Data with User ID: {userId} and Follower ID: {followerId} has been deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 向用户关注表添加数据项
    [HttpPost]
    [SwaggerOperation(Summary = "向用户关注表添加数据项", Description = "向用户关注表添加数据项")]
    [SwaggerResponse(201, "添加数据项成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> PostUserFollow([FromBody] UserFollow userFollow)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.UserFollowSet.Add(userFollow);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostUserFollow),
            new { userId = userFollow.UserId, followerId = userFollow.FollowerId }, userFollow);
    }

    // 根据主键（ID）更新用户关注表的数据
    [HttpPut("{userId:int}-{followerId:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新用户关注表的数据", Description = "根据主键（ID）更新用户关注表的数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdateUserFollow(int userId, int followerId, [FromBody] UserFollow userFollow)
    {
        if (userId != userFollow.UserId || followerId != userFollow.FollowerId)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Entry(userFollow).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.UserFollowSet.Any(e => e.UserId == userId && e.FollowerId == followerId))
            {
                return NotFound($"No corresponding data found for User ID: {userId} and Follower ID: {followerId}");
            }

            throw;
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }

        return Ok($"Data with User ID: {userId} and Follower ID: {followerId} has been updated successfully.");
    }

    // 根据用户 ID（UserId）获取关注用户列表
    [HttpGet("following/{userId:int}")]
    [SwaggerOperation(Summary = "根据用户 ID（UserId）获取关注用户列表", Description = "根据用户 ID（UserId）获取关注用户列表")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<object>>> GetFollowingByUserId(int userId)
    {
        try
        {
            return Ok(await context.UserFollowSet
                .Where(uf => uf.FollowerId == userId)
                .Select(uf => new
                {
                    uf.UserId,
                    uf.User!.UserName,
                    uf.User.Profile,
                    uf.User.AvatarUrl
                })
                .ToListAsync());
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据用户 ID（UserId）获取粉丝用户列表
    [HttpGet("followers/{userId:int}")]
    [SwaggerOperation(Summary = "根据用户 ID（UserId）获取粉丝用户列表", Description = "根据用户 ID（UserId）获取粉丝用户列表")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<object>>> GetFollowersByUserId(int userId)
    {
        try
        {
            return Ok(await context.UserFollowSet
                .Where(uf => uf.UserId == userId)
                .Select(uf => new
                {
                    uf.FollowerId,
                    uf.Follower!.UserName,
                    uf.Follower.Profile,
                    uf.Follower.AvatarUrl
                })
                .ToListAsync());
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}