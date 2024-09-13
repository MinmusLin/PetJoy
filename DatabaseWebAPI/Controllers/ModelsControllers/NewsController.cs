/*
 * Project Name:  DatabaseWebAPI
 * File Name:     NewsController.cs
 * File Function: News 控制器
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-09-03
 * License:       Creative Commons Attribution 4.0 International License
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseWebAPI.Data;
using DatabaseWebAPI.Models.TableModels;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Controllers.ModelsControllers;

[Route("api/news")]
[ApiController]
[SwaggerTag("新闻表相关 API")]
public class NewsController(OracleDbContext context) : ControllerBase
{
    // 获取新闻表的所有数据
    [HttpGet]
    [SwaggerOperation(Summary = "获取新闻表的所有数据", Description = "获取新闻表的所有数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<News>>> GetNews()
    {
        try
        {
            return Ok(await context.NewsSet.ToListAsync());
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

    // 根据主键（ID）获取新闻表的数据
    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取新闻表的数据", Description = "根据主键（ID）获取新闻表的数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<News>> GetNewsByPk(int id)
    {
        try
        {
            var news = await context.NewsSet.FindAsync(id);
            if (news == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            return Ok(news);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）删除新闻表的数据
    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）删除新闻表的数据", Description = "根据主键（ID）删除新闻表的数据")]
    [SwaggerResponse(200, "删除数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<News>> DeleteNewsByPk(int id)
    {
        try
        {
            var news = await context.NewsSet.FindAsync(id);
            if (news == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            context.NewsSet.Remove(news);
            await context.SaveChangesAsync();
            return Ok($"Data with ID: {id} has been deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 向新闻表添加数据项
    [HttpPost]
    [SwaggerOperation(Summary = "向新闻表添加数据项", Description = "向新闻表添加数据项（不需要提供 NEWS_ID，因为它是由系统自动生成的）")]
    [SwaggerResponse(201, "添加数据项成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> PostNews([FromBody] News news)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.NewsSet.Add(news);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostNews), new { id = news.NewsId }, news);
    }

    // 根据主键（ID）更新新闻表的数据
    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新新闻表的数据", Description = "根据主键（ID）更新新闻表的数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdateNews(int id, [FromBody] News news)
    {
        if (id != news.NewsId)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Entry(news).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.NewsSet.Any(e => e.NewsId == id))
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

    // 根据新闻标签（TagId）筛选新闻表的主键（ID）
    [HttpPost("filter-by-tag")]
    [SwaggerOperation(Summary = "根据新闻标签（TagId）筛选新闻表的主键（ID）", Description = "根据新闻标签（TagId）筛选新闻表的主键（ID）")]
    [SwaggerResponse(200, "筛选成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<IEnumerable<int>>> FilterNewsIdByTagId([FromBody] List<int> tagIds)
    {
        if (tagIds.Count == 0)
        {
            return BadRequest("Tag ID list cannot be null or empty.");
        }

        try
        {
            var newsIds = await context.NewsSet
                .Where(news => tagIds.Contains(news.TagId))
                .OrderByDescending(news => news.IsSticky)
                .ThenByDescending(news => news.CreationDate)
                .Select(news => news.NewsId)
                .ToListAsync();
            return Ok(newsIds);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 获取新闻热榜的数据
    [HttpGet("top-news")]
    [SwaggerOperation(Summary = "获取新闻热榜的数据", Description = "获取新闻热榜的数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<object>>> GetTopNews()
    {
        try
        {
            return Ok(await context.NewsSet
                .OrderByDescending(news => news.LikeCount)
                .Select(news => new
                {
                    news.NewsId,
                    news.Title,
                    news.Summary,
                    news.CoverUrl,
                    news.LikeCount,
                    news.CreationDate
                })
                .Take(10)
                .ToListAsync());
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}