/*
 * Project Name:  DatabaseWebAPI
 * File Name:     PostLikeController.cs
 * File Function: PostLike 控制器
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

[Route("api/post-like")]
[ApiController]
[SwaggerTag("帖子点赞表相关 API")]
public class PostLikeController(OracleDbContext context) : ControllerBase
{
    // 获取帖子点赞表的所有数据
    [HttpGet]
    [SwaggerOperation(Summary = "获取帖子点赞表的所有数据", Description = "获取帖子点赞表的所有数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<PostLike>>> GetPostLike()
    {
        try
        {
            return Ok(await context.PostLikeSet.ToListAsync());
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

    // 根据主键（ID）获取帖子点赞表的数据
    [HttpGet("{postId:int}-{userId:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取帖子点赞表的数据", Description = "根据主键（ID）获取帖子点赞表的数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<PostLike>> GetPostLikeByPk(int postId, int userId)
    {
        try
        {
            var postLike =
                await context.PostLikeSet.FirstOrDefaultAsync(n => n.PostId == postId && n.UserId == userId);
            if (postLike == null)
            {
                return NotFound($"No corresponding data found for Post ID: {postId} and User ID: {userId}");
            }

            return Ok(postLike);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）删除帖子点赞表的数据
    [HttpDelete("{postId:int}-{userId:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）删除帖子点赞表的数据", Description = "根据主键（ID）删除帖子点赞表的数据")]
    [SwaggerResponse(200, "删除数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<PostLike>> DeletePostLikeByPk(int postId, int userId)
    {
        try
        {
            var postLike =
                await context.PostLikeSet.FirstOrDefaultAsync(n => n.PostId == postId && n.UserId == userId);
            if (postLike == null)
            {
                return NotFound($"No corresponding data found for Post ID: {postId} and User ID: {userId}");
            }

            context.PostLikeSet.Remove(postLike);
            await context.SaveChangesAsync();
            return Ok($"Data with Post ID: {postId} and User ID: {userId} has been deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 向帖子点赞表添加数据项
    [HttpPost]
    [SwaggerOperation(Summary = "向帖子点赞表添加数据项", Description = "向帖子点赞表添加数据项")]
    [SwaggerResponse(201, "添加数据项成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> PostPostLike([FromBody] PostLike postLike)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.PostLikeSet.Add(postLike);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostPostLike),
            new { postId = postLike.PostId, userId = postLike.UserId }, postLike);
    }

    // 根据主键（ID）更新帖子点赞表的数据
    [HttpPut("{postId:int}-{userId:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新帖子点赞表的数据", Description = "根据主键（ID）更新帖子点赞表的数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdatePostLike(int postId, int userId, [FromBody] PostLike postLike)
    {
        if (postId != postLike.PostId || userId != postLike.UserId)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Entry(postLike).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.PostLikeSet.Any(e => e.PostId == postId && e.UserId == userId))
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
}