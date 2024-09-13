/*
 * Project Name:  DatabaseWebAPI
 * File Name:     NewsCommentLikeController.cs
 * File Function: NewsCommentLike 控制器
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

[Route("api/news-comment-like")]
[ApiController]
[SwaggerTag("新闻评论点赞表相关 API")]
public class NewsCommentLikeController(OracleDbContext context) : ControllerBase
{
    // 获取新闻评论点赞表的所有数据
    [HttpGet]
    [SwaggerOperation(Summary = "获取新闻评论点赞表的所有数据", Description = "获取新闻评论点赞表的所有数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<NewsCommentLike>>> GetNewsCommentLike()
    {
        try
        {
            return Ok(await context.NewsCommentLikeSet.ToListAsync());
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

    // 根据主键（ID）获取新闻评论点赞表的数据
    [HttpGet("{commentId:int}-{userId:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取新闻评论点赞表的数据", Description = "根据主键（ID）获取新闻评论点赞表的数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<NewsCommentLike>> GetNewsCommentLikeByPk(int commentId, int userId)
    {
        try
        {
            var newsCommentLike =
                await context.NewsCommentLikeSet.FirstOrDefaultAsync(n =>
                    n.CommentId == commentId && n.UserId == userId);
            if (newsCommentLike == null)
            {
                return NotFound($"No corresponding data found for Comment ID: {commentId} and User ID: {userId}");
            }

            return Ok(newsCommentLike);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）删除新闻评论点赞表的数据
    [HttpDelete("{commentId:int}-{userId:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）删除新闻评论点赞表的数据", Description = "根据主键（ID）删除新闻评论点赞表的数据")]
    [SwaggerResponse(200, "删除数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<NewsCommentLike>> DeleteNewsCommentLikeByPk(int commentId, int userId)
    {
        try
        {
            var newsCommentLike =
                await context.NewsCommentLikeSet.FirstOrDefaultAsync(n =>
                    n.CommentId == commentId && n.UserId == userId);
            if (newsCommentLike == null)
            {
                return NotFound($"No corresponding data found for Comment ID: {commentId} and User ID: {userId}");
            }

            context.NewsCommentLikeSet.Remove(newsCommentLike);
            await context.SaveChangesAsync();
            return Ok($"Data with Comment ID: {commentId} and User ID: {userId} has been deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 向新闻评论点赞表添加数据项
    [HttpPost]
    [SwaggerOperation(Summary = "向新闻评论点赞表添加数据项", Description = "向新闻评论点赞表添加数据项")]
    [SwaggerResponse(201, "添加数据项成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> PostNewsCommentLike([FromBody] NewsCommentLike newsCommentLike)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.NewsCommentLikeSet.Add(newsCommentLike);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostNewsCommentLike),
            new { commentId = newsCommentLike.CommentId, userId = newsCommentLike.UserId }, newsCommentLike);
    }

    // 根据主键（ID）更新新闻评论点赞表的数据
    [HttpPut("{commentId:int}-{userId:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新新闻评论点赞表的数据", Description = "根据主键（ID）更新新闻评论点赞表的数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdateNewsCommentLike(int commentId, int userId,
        [FromBody] NewsCommentLike newsCommentLike)
    {
        if (commentId != newsCommentLike.CommentId || userId != newsCommentLike.UserId)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Entry(newsCommentLike).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.NewsCommentLikeSet.Any(e => e.CommentId == commentId && e.UserId == userId))
            {
                return NotFound($"No corresponding data found for Comment ID: {commentId} and User ID: {userId}");
            }

            throw;
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }

        return Ok($"Data with Comment ID: {commentId} and User ID: {userId} has been updated successfully.");
    }
}