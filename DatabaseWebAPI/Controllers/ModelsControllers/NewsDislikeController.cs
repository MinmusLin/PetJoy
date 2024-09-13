/*
 * Project Name:  DatabaseWebAPI
 * File Name:     NewsDislikeController.cs
 * File Function: NewsDislike 控制器
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

[Route("api/news-dislike")]
[ApiController]
[SwaggerTag("新闻点踩表相关 API")]
public class NewsDislikeController(OracleDbContext context) : ControllerBase
{
    // 获取新闻点踩表的所有数据
    [HttpGet]
    [SwaggerOperation(Summary = "获取新闻点踩表的所有数据", Description = "获取新闻点踩表的所有数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<NewsDislike>>> GetNewsDislike()
    {
        try
        {
            return Ok(await context.NewsDislikeSet.ToListAsync());
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

    // 根据主键（ID）获取新闻点踩表的数据
    [HttpGet("{newsId:int}-{userId:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取新闻点踩表的数据", Description = "根据主键（ID）获取新闻点踩表的数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<NewsDislike>> GetNewsDislikeByPk(int newsId, int userId)
    {
        try
        {
            var newsDislike =
                await context.NewsDislikeSet.FirstOrDefaultAsync(n => n.NewsId == newsId && n.UserId == userId);
            if (newsDislike == null)
            {
                return NotFound($"No corresponding data found for News ID: {newsId} and User ID: {userId}");
            }

            return Ok(newsDislike);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）删除新闻点踩表的数据
    [HttpDelete("{newsId:int}-{userId:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）删除新闻点踩表的数据", Description = "根据主键（ID）删除新闻点踩表的数据")]
    [SwaggerResponse(200, "删除数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<NewsDislike>> DeleteNewsDislikeByPk(int newsId, int userId)
    {
        try
        {
            var newsDislike =
                await context.NewsDislikeSet.FirstOrDefaultAsync(n => n.NewsId == newsId && n.UserId == userId);
            if (newsDislike == null)
            {
                return NotFound($"No corresponding data found for News ID: {newsId} and User ID: {userId}");
            }

            context.NewsDislikeSet.Remove(newsDislike);
            await context.SaveChangesAsync();
            return Ok($"Data with News ID: {newsId} and User ID: {userId} has been deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 向新闻点踩表添加数据项
    [HttpPost]
    [SwaggerOperation(Summary = "向新闻点踩表添加数据项", Description = "向新闻点踩表添加数据项")]
    [SwaggerResponse(201, "添加数据项成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> PostNewsDislike([FromBody] NewsDislike newsDislike)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.NewsDislikeSet.Add(newsDislike);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostNewsDislike),
            new { newsId = newsDislike.NewsId, userId = newsDislike.UserId }, newsDislike);
    }

    // 根据主键（ID）更新新闻点踩表的数据
    [HttpPut("{newsId:int}-{userId:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新新闻点踩表的数据", Description = "根据主键（ID）更新新闻点踩表的数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdateNewsDislike(int newsId, int userId, [FromBody] NewsDislike newsDislike)
    {
        if (newsId != newsDislike.NewsId || userId != newsDislike.UserId)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Entry(newsDislike).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.NewsDislikeSet.Any(e => e.NewsId == newsId && e.UserId == userId))
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