/*
 * Project Name:  DatabaseWebAPI
 * File Name:     PostFavoriteController.cs
 * File Function: PostFavorite 控制器
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-09-06
 * License:       Creative Commons Attribution 4.0 International License
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseWebAPI.Data;
using DatabaseWebAPI.Models.TableModels;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Controllers.ModelsControllers;

[Route("api/post-favorite")]
[ApiController]
[SwaggerTag("帖子收藏表相关 API")]
public class PostFavoriteController(OracleDbContext context) : ControllerBase
{
    // 获取帖子收藏表的所有数据
    [HttpGet]
    [SwaggerOperation(Summary = "获取帖子收藏表的所有数据", Description = "获取帖子收藏表的所有数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<PostFavorite>>> GetPostFavorite()
    {
        try
        {
            return Ok(await context.PostFavoriteSet.ToListAsync());
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

    // 根据主键（ID）获取帖子收藏表的数据
    [HttpGet("{postId:int}-{userId:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取帖子收藏表的数据", Description = "根据主键（ID）获取帖子收藏表的数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<PostFavorite>> GetPostFavoriteByPk(int postId, int userId)
    {
        try
        {
            var postFavorite =
                await context.PostFavoriteSet.FirstOrDefaultAsync(n => n.PostId == postId && n.UserId == userId);
            if (postFavorite == null)
            {
                return NotFound($"No corresponding data found for Post ID: {postId} and User ID: {userId}");
            }

            return Ok(postFavorite);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）删除帖子收藏表的数据
    [HttpDelete("{postId:int}-{userId:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）删除帖子收藏表的数据", Description = "根据删除（ID）获取帖子收藏表的数据")]
    [SwaggerResponse(200, "删除数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<PostFavorite>> DeletePostFavoriteByPk(int postId, int userId)
    {
        try
        {
            var postFavorite =
                await context.PostFavoriteSet.FirstOrDefaultAsync(n => n.PostId == postId && n.UserId == userId);
            if (postFavorite == null)
            {
                return NotFound($"No corresponding data found for Post ID: {postId} and User ID: {userId}");
            }

            context.PostFavoriteSet.Remove(postFavorite);
            await context.SaveChangesAsync();
            return Ok($"Data with Post ID: {postId} and User ID: {userId} has been deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 向帖子收藏表添加数据项
    [HttpPost]
    [SwaggerOperation(Summary = "向帖子收藏表添加数据项", Description = "向帖子收藏表添加数据项")]
    [SwaggerResponse(201, "添加数据项成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> PostPostFavorite([FromBody] PostFavorite postFavorite)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.PostFavoriteSet.Add(postFavorite);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostPostFavorite),
            new { postId = postFavorite.PostId, userId = postFavorite.UserId }, postFavorite);
    }

    // 根据主键（ID）更新帖子收藏表的数据
    [HttpPut("{postId:int}-{userId:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新帖子收藏表的数据", Description = "根据主键（ID）更新帖子收藏表的数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdatePostFavorite(int postId, int userId, [FromBody] PostFavorite postFavorite)
    {
        if (postId != postFavorite.PostId || userId != postFavorite.UserId)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Entry(postFavorite).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.PostFavoriteSet.Any(e => e.PostId == postId && e.UserId == userId))
            {
                return NotFound($"No corresponding data found for Post ID: {postId} and User ID: {userId}");
            }

            throw;
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }

        return Ok($"Data with Post ID: {postId} and User ID: {userId} has been updated successfully.");
    }

    // 根据用户 ID（UserId）获取帖子 ID（PostId）
    [HttpGet("user/{userId:int}")]
    [SwaggerOperation(Summary = "根据用户 ID（UserId）获取帖子 ID（PostId）", Description = "根据用户 ID（UserId）获取帖子 ID（PostId）")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<int>>> GetPostIdsByUserId(int userId)
    {
        try
        {
            var postIds = await context.PostFavoriteSet
                .Where(pf => pf.UserId == userId)
                .OrderByDescending(pf => pf.FavoriteTime)
                .Select(pf => pf.PostId)
                .ToListAsync();
            return Ok(postIds);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}