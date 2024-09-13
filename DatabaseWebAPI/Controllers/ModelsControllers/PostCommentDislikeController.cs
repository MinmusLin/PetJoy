/*
 * Project Name:  DatabaseWebAPI
 * File Name:     PostCommentDislikeController.cs
 * File Function: PostCommentDislike 控制器
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

[Route("api/post-comment-dislike")]
[ApiController]
[SwaggerTag("帖子评论点踩表相关 API")]
public class PostCommentDislikeController(OracleDbContext context) : ControllerBase
{
    // 获取帖子评论点踩表的所有数据
    [HttpGet]
    [SwaggerOperation(Summary = "获取帖子评论点踩表的所有数据", Description = "获取帖子评论点踩表的所有数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<PostCommentDislike>>> GetPostCommentDislike()
    {
        try
        {
            return Ok(await context.PostCommentDislikeSet.ToListAsync());
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

    // 根据主键（ID）获取帖子评论点踩表的数据
    [HttpGet("{commentId:int}-{userId:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取帖子评论点踩表的数据", Description = "根据主键（ID）获取帖子评论点踩表的数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<PostCommentDislike>> GetPostCommentDislikeByPk(int commentId, int userId)
    {
        try
        {
            var postCommentDislike =
                await context.PostCommentDislikeSet.FirstOrDefaultAsync(n =>
                    n.CommentId == commentId && n.UserId == userId);
            if (postCommentDislike == null)
            {
                return NotFound($"No corresponding data found for Comment ID: {commentId} and User ID: {userId}");
            }

            return Ok(postCommentDislike);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）删除帖子评论点踩表的数据
    [HttpDelete("{commentId:int}-{userId:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）删除帖子评论点踩表的数据", Description = "根据主键（ID）删除帖子评论点踩表的数据")]
    [SwaggerResponse(200, "删除数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<PostCommentDislike>> DeletePostCommentDislikeByPk(int commentId, int userId)
    {
        try
        {
            var postCommentDislike =
                await context.PostCommentDislikeSet.FirstOrDefaultAsync(n =>
                    n.CommentId == commentId && n.UserId == userId);
            if (postCommentDislike == null)
            {
                return NotFound($"No corresponding data found for Comment ID: {commentId} and User ID: {userId}");
            }

            context.PostCommentDislikeSet.Remove(postCommentDislike);
            await context.SaveChangesAsync();
            return Ok($"Data with Comment ID: {commentId} and User ID: {userId} has been deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 向帖子评论点踩表添加数据项
    [HttpPost]
    [SwaggerOperation(Summary = "向帖子评论点踩表添加数据项", Description = "向帖子评论点踩表添加数据项")]
    [SwaggerResponse(201, "添加数据项成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> PostPostCommentDislike([FromBody] PostCommentDislike postCommentDislike)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.PostCommentDislikeSet.Add(postCommentDislike);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostPostCommentDislike),
            new { commentId = postCommentDislike.CommentId, userId = postCommentDislike.UserId }, postCommentDislike);
    }

    // 根据主键（ID）更新帖子评论点踩表的数据
    [HttpPut("{commentId:int}-{userId:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新帖子评论点踩表的数据", Description = "根据主键（ID）更新帖子评论点踩表的数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdatePostCommentDislike(int commentId, int userId,
        [FromBody] PostCommentDislike postCommentDislike)
    {
        if (commentId != postCommentDislike.CommentId || userId != postCommentDislike.UserId)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Entry(postCommentDislike).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.PostCommentDislikeSet.Any(e => e.CommentId == commentId && e.UserId == userId))
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