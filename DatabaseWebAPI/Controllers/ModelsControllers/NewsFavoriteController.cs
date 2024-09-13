/*
 * Project Name:  DatabaseWebAPI
 * File Name:     NewsFavoriteController.cs
 * File Function: NewsFavorite 控制器
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

[Route("api/news-favorite")]
[ApiController]
[SwaggerTag("新闻收藏表相关 API")]
public class NewsFavoriteController(OracleDbContext context) : ControllerBase
{
    // 获取新闻收藏表的所有数据
    [HttpGet]
    [SwaggerOperation(Summary = "获取新闻收藏表的所有数据", Description = "获取新闻收藏表的所有数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<NewsFavorite>>> GetNewsFavorite()
    {
        try
        {
            return Ok(await context.NewsFavoriteSet.ToListAsync());
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

    // 根据主键（ID）获取新闻收藏表的数据
    [HttpGet("{newsId:int}-{userId:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取新闻收藏表的数据", Description = "根据主键（ID）获取新闻收藏表的数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<NewsFavorite>> GetNewsFavoriteByPk(int newsId, int userId)
    {
        try
        {
            var newsFavorite =
                await context.NewsFavoriteSet.FirstOrDefaultAsync(n => n.NewsId == newsId && n.UserId == userId);
            if (newsFavorite == null)
            {
                return NotFound($"No corresponding data found for News ID: {newsId} and User ID: {userId}");
            }

            return Ok(newsFavorite);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）删除新闻收藏表的数据
    [HttpDelete("{newsId:int}-{userId:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）删除新闻收藏表的数据", Description = "根据主键（ID）删除新闻收藏表的数据")]
    [SwaggerResponse(200, "删除数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<NewsFavorite>> DeleteNewsFavoriteByPk(int newsId, int userId)
    {
        try
        {
            var newsFavorite =
                await context.NewsFavoriteSet.FirstOrDefaultAsync(n => n.NewsId == newsId && n.UserId == userId);
            if (newsFavorite == null)
            {
                return NotFound($"No corresponding data found for News ID: {newsId} and User ID: {userId}");
            }

            context.NewsFavoriteSet.Remove(newsFavorite);
            await context.SaveChangesAsync();
            return Ok($"Data with News ID: {newsId} and User ID: {userId} has been deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 向新闻收藏表添加数据项
    [HttpPost]
    [SwaggerOperation(Summary = "向新闻收藏表添加数据项", Description = "向新闻收藏表添加数据项")]
    [SwaggerResponse(201, "添加数据项成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> PostNewsFavorite([FromBody] NewsFavorite newsFavorite)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.NewsFavoriteSet.Add(newsFavorite);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostNewsFavorite),
            new { newsId = newsFavorite.NewsId, userId = newsFavorite.UserId }, newsFavorite);
    }

    // 根据主键（ID）更新新闻收藏表的数据
    [HttpPut("{newsId:int}-{userId:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新新闻收藏表的数据", Description = "根据主键（ID）更新新闻收藏表的数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdateNewsFavorite(int newsId, int userId, [FromBody] NewsFavorite newsFavorite)
    {
        if (newsId != newsFavorite.NewsId || userId != newsFavorite.UserId)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Entry(newsFavorite).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.NewsFavoriteSet.Any(e => e.NewsId == newsId && e.UserId == userId))
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

    // 根据用户 ID（UserId）获取新闻 ID（NewsId）
    [HttpGet("user/{userId:int}")]
    [SwaggerOperation(Summary = "根据用户 ID（UserId）获取新闻 ID（NewsId）", Description = "根据用户 ID（UserId）获取新闻 ID（NewsId）")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<int>>> GetNewsIdsByUserId(int userId)
    {
        try
        {
            var newsIds = await context.NewsFavoriteSet
                .Where(pf => pf.UserId == userId)
                .OrderByDescending(pf => pf.FavoriteTime)
                .Select(pf => pf.NewsId)
                .ToListAsync();
            return Ok(newsIds);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}