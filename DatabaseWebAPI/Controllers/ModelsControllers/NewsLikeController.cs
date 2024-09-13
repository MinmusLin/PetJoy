/*
 * Project Name:  DatabaseWebAPI
 * File Name:     NewsLikeController.cs
 * File Function: NewsLike 控制器
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

[Route("api/news-like")]
[ApiController]
[SwaggerTag("新闻点赞表相关 API")]
public class NewsLikeController(OracleDbContext context) : ControllerBase
{
    // 获取新闻点赞表的所有数据
    [HttpGet]
    [SwaggerOperation(Summary = "获取新闻点赞表的所有数据", Description = "获取新闻点赞表的所有数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<NewsLike>>> GetNewsLike()
    {
        try
        {
            return Ok(await context.NewsLikeSet.ToListAsync());
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

    // 根据主键（ID）获取新闻点赞表的数据
    [HttpGet("{newsId:int}-{userId:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取新闻点赞表的数据", Description = "根据主键（ID）获取新闻点赞表的数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<NewsLike>> GetNewsLikeByPk(int newsId, int userId)
    {
        try
        {
            var newsLike =
                await context.NewsLikeSet.FirstOrDefaultAsync(n => n.NewsId == newsId && n.UserId == userId);
            if (newsLike == null)
            {
                return NotFound($"No corresponding data found for News ID: {newsId} and User ID: {userId}");
            }

            return Ok(newsLike);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）删除新闻点赞表的数据
    [HttpDelete("{newsId:int}-{userId:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）删除新闻点赞表的数据", Description = "根据主键（ID）删除新闻点赞表的数据")]
    [SwaggerResponse(200, "删除数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<NewsLike>> DeleteNewsLikeByPk(int newsId, int userId)
    {
        try
        {
            var newsLike =
                await context.NewsLikeSet.FirstOrDefaultAsync(n => n.NewsId == newsId && n.UserId == userId);
            if (newsLike == null)
            {
                return NotFound($"No corresponding data found for News ID: {newsId} and User ID: {userId}");
            }

            context.NewsLikeSet.Remove(newsLike);
            await context.SaveChangesAsync();
            return Ok($"Data with News ID: {newsId} and User ID: {userId} has been deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 向新闻点赞表添加数据项
    [HttpPost]
    [SwaggerOperation(Summary = "向新闻点赞表添加数据项", Description = "向新闻点赞表添加数据项")]
    [SwaggerResponse(201, "添加数据项成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> PostNewsLike([FromBody] NewsLike newsLike)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.NewsLikeSet.Add(newsLike);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostNewsLike), new { newsId = newsLike.NewsId, userId = newsLike.UserId },
            newsLike);
    }

    // 根据主键（ID）更新新闻点赞表的数据
    [HttpPut("{newsId:int}-{userId:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新新闻点赞表的数据", Description = "根据主键（ID）更新新闻点赞表的数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdateNewsLike(int newsId, int userId, [FromBody] NewsLike newsLike)
    {
        if (newsId != newsLike.NewsId || userId != newsLike.UserId)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Entry(newsLike).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.NewsLikeSet.Any(e => e.NewsId == newsId && e.UserId == userId))
            {
                return NotFound($"No corresponding data found for News ID: {newsId} and User ID: {userId}");
            }

            throw;
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }

        return Ok($"Data with News ID: {newsId} and User ID: {userId} has been updated successfully.");
    }
}