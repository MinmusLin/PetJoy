/*
 * Project Name:  DatabaseWebAPI
 * File Name:     NewsTagController.cs
 * File Function: NewsTag 控制器
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

[Route("api/news-tag")]
[ApiController]
[SwaggerTag("新闻标签表相关 API")]
public class NewsTagController(OracleDbContext context) : ControllerBase
{
    // 获取新闻标签表的所有数据
    [HttpGet]
    [SwaggerOperation(Summary = "获取新闻标签表的所有数据", Description = "获取新闻标签表的所有数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<NewsTag>>> GetNewsTag()
    {
        try
        {
            return Ok(await context.NewsTagSet.ToListAsync());
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

    // 根据主键（ID）获取新闻标签表的数据
    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取新闻标签表的数据", Description = "根据主键（ID）获取新闻标签表的数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<NewsTag>> GetNewsTagByPk(int id)
    {
        try
        {
            var newsTag = await context.NewsTagSet.FindAsync(id);
            if (newsTag == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            return Ok(newsTag);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）删除新闻标签表的数据
    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）删除新闻标签表的数据", Description = "根据主键（ID）删除新闻标签表的数据")]
    [SwaggerResponse(200, "删除数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<NewsTag>> DeleteNewsTagByPk(int id)
    {
        try
        {
            var newsTag = await context.NewsTagSet.FindAsync(id);
            if (newsTag == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            context.NewsTagSet.Remove(newsTag);
            await context.SaveChangesAsync();
            return Ok($"Data with ID: {id} has been deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 向新闻标签表添加数据项
    [HttpPost]
    [SwaggerOperation(Summary = "向新闻标签表添加数据项", Description = "向新闻标签表添加数据项")]
    [SwaggerResponse(201, "添加数据项成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> PostNewsTag([FromBody] NewsTag newsTag)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.NewsTagSet.Add(newsTag);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostNewsTag), new { id = newsTag.TagId }, newsTag);
    }

    // 根据主键（ID）更新新闻标签表的数据
    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新新闻标签表的数据", Description = "根据主键（ID）更新新闻标签表的数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdateNewsTag(int id, [FromBody] NewsTag newsTag)
    {
        if (id != newsTag.TagId)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Entry(newsTag).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.NewsTagSet.Any(e => e.TagId == id))
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