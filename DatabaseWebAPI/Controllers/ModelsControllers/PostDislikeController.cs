/*
 * Project Name:  DatabaseWebAPI
 * File Name:     PostDislikeController.cs
 * File Function: PostDislike 控制器
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

[Route("api/post-dislike")]
[ApiController]
[SwaggerTag("帖子点踩表相关 API")]
public class PostDislikeController(OracleDbContext context) : ControllerBase
{
    // 获取帖子点踩表的所有数据
    [HttpGet]
    [SwaggerOperation(Summary = "获取帖子点踩表的所有数据", Description = "获取帖子点踩表的所有数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<PostDislike>>> GetPostDislike()
    {
        try
        {
            return Ok(await context.PostDislikeSet.ToListAsync());
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

    // 根据主键（ID）获取帖子点踩表的数据
    [HttpGet("{postId:int}-{userId:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取帖子点踩表的数据", Description = "根据主键（ID）获取帖子点踩表的数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<PostDislike>> GetPostDislikeByPk(int postId, int userId)
    {
        try
        {
            var postDislike =
                await context.PostDislikeSet.FirstOrDefaultAsync(n => n.PostId == postId && n.UserId == userId);
            if (postDislike == null)
            {
                return NotFound($"No corresponding data found for Post ID: {postId} and User ID: {userId}");
            }

            return Ok(postDislike);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）删除帖子点踩表的数据
    [HttpDelete("{postId:int}-{userId:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）删除帖子点踩表的数据", Description = "根据主键（ID）删除帖子点踩表的数据")]
    [SwaggerResponse(200, "删除数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<PostDislike>> DeletePostDislikeByPk(int postId, int userId)
    {
        try
        {
            var postDislike =
                await context.PostDislikeSet.FirstOrDefaultAsync(n => n.PostId == postId && n.UserId == userId);
            if (postDislike == null)
            {
                return NotFound($"No corresponding data found for Post ID: {postId} and User ID: {userId}");
            }

            context.PostDislikeSet.Remove(postDislike);
            await context.SaveChangesAsync();
            return Ok($"Data with Post ID: {postId} and User ID: {userId} has been deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 向帖子点踩表添加数据项
    [HttpPost]
    [SwaggerOperation(Summary = "向帖子点踩表添加数据项", Description = "向帖子点踩表添加数据项")]
    [SwaggerResponse(201, "添加数据项成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> PostPostDislike([FromBody] PostDislike postDislike)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.PostDislikeSet.Add(postDislike);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostPostDislike),
            new { postId = postDislike.PostId, userId = postDislike.UserId }, postDislike);
    }

    // 根据主键（ID）更新帖子点踩表的数据
    [HttpPut("{postId:int}-{userId:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新帖子点踩表的数据", Description = "根据主键（ID）更新帖子点踩表的数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdatePostDislike(int postId, int userId, [FromBody] PostDislike postDislike)
    {
        if (postId != postDislike.PostId || userId != postDislike.UserId)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Entry(postDislike).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.PostDislikeSet.Any(e => e.PostId == postId && e.UserId == userId))
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