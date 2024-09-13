/*
 * Project Name:  DatabaseWebAPI
 * File Name:     NewsCommentController.cs
 * File Function: NewsComment 控制器
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-08-09
 * License:       Creative Commons Attribution 4.0 International License
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseWebAPI.Data;
using DatabaseWebAPI.Models.TableModels;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Controllers.ModelsControllers;

[Route("api/news-comment")]
[ApiController]
[SwaggerTag("新闻评论表相关 API")]
public class NewsCommentController(OracleDbContext context) : ControllerBase
{
    // 获取新闻评论表的所有数据
    [HttpGet]
    [SwaggerOperation(Summary = "获取新闻评论表的所有数据", Description = "获取新闻评论表的所有数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<NewsComment>>> GetNewsComment()
    {
        try
        {
            return Ok(await context.NewsCommentSet.ToListAsync());
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

    // 根据主键（ID）获取新闻评论表的数据
    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取新闻评论表的数据", Description = "根据主键（ID）获取新闻评论表的数据")]
    [SwaggerResponse(200, "删除数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<NewsComment>> DeleteNewsCommentByPk(int id)
    {
        try
        {
            var newsComment = await context.NewsCommentSet.FindAsync(id);
            if (newsComment == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            context.NewsCommentSet.Remove(newsComment);
            await context.SaveChangesAsync();
            return Ok($"Data with ID: {id} has been deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据新闻 ID（NEWS_ID）获取新闻评论表的数据
    [HttpGet("news-{id:int}")]
    [SwaggerOperation(Summary = "根据新闻 ID（NEWS_ID）获取新闻评论表的数据", Description = "根据新闻 ID（NEWS_ID）获取新闻评论表的数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<NewsComment>>> GetNewsCommentByPostId(int id)
    {
        try
        {
            return Ok(await context.NewsCommentSet
                .Where(pc => pc.NewsId == id)
                .OrderByDescending(pc => pc.CommentTime)
                .ToListAsync());
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）删除新闻评论表的数据
    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）删除新闻评论表的数据", Description = "根据主键（ID）删除新闻评论表的数据")]
    [SwaggerResponse(200, "删除数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<NewsComment>> GetNewsCommentByPk(int id)
    {
        try
        {
            var newsComment = await context.NewsCommentSet.FindAsync(id);
            if (newsComment == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            return Ok(newsComment);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 向新闻评论表添加数据项
    [HttpPost]
    [SwaggerOperation(Summary = "向新闻评论表添加数据项", Description = "向新闻评论表添加数据项（不需要提供 COMMENT_ID，因为它是由系统自动生成的）")]
    [SwaggerResponse(201, "添加数据项成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> PostNewsComment([FromBody] NewsComment newsComment)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.NewsCommentSet.Add(newsComment);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostNewsComment), new { id = newsComment.CommentId }, newsComment);
    }

    // 根据主键（ID）更新新闻评论表的数据
    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新新闻评论表的数据", Description = "根据主键（ID）更新新闻评论表的数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdateNewsComment(int id, [FromBody] NewsComment newsComment)
    {
        if (id != newsComment.CommentId)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Entry(newsComment).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.NewsCommentSet.Any(e => e.CommentId == id))
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