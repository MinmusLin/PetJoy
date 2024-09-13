/*
 * Project Name:  DatabaseWebAPI
 * File Name:     NewsCommentReportController.cs
 * File Function: NewsCommentReport 控制器
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-09-07
 * License:       Creative Commons Attribution 4.0 International License
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseWebAPI.Data;
using DatabaseWebAPI.Models.TableModels;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Controllers.ModelsControllers;

[Route("api/news-comment-report")]
[ApiController]
[SwaggerTag("新闻评论举报表相关 API")]
public class NewsCommentReportController(OracleDbContext context) : ControllerBase
{
    // 获取新闻评论举报表的所有数据
    [HttpGet]
    [SwaggerOperation(Summary = "获取新闻评论举报表的所有数据", Description = "获取新闻评论举报表的所有数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<NewsCommentReport>>> GetNewsCommentReport()
    {
        try
        {
            return Ok(await context.NewsCommentReportSet.ToListAsync());
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

    // 根据主键（ID）获取新闻评论举报表的数据
    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取新闻评论举报表的数据", Description = "根据主键（ID）获取新闻评论举报表的数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<NewsCommentReport>> GetNewsCommentReportByPk(int id)
    {
        try
        {
            var newsCommentReport = await context.NewsCommentReportSet.FindAsync(id);
            if (newsCommentReport == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            return Ok(newsCommentReport);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）删除新闻评论举报表的数据
    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）删除新闻评论举报表的数据", Description = "根据主键（ID）删除新闻评论举报表的数据")]
    [SwaggerResponse(200, "删除数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<NewsCommentReport>> DeleteNewsCommentReportByPk(int id)
    {
        try
        {
            var newsCommentReport = await context.NewsCommentReportSet.FindAsync(id);
            if (newsCommentReport == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            context.NewsCommentReportSet.Remove(newsCommentReport);
            await context.SaveChangesAsync();
            return Ok($"Data with ID: {id} has been deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 向新闻评论举报表添加数据项
    [HttpPost]
    [SwaggerOperation(Summary = "向新闻评论举报表添加数据项",
        Description = "向新闻评论举报表添加数据项（不需要提供 NEWS_COMMENT_REPORT_ID，因为它是由系统自动生成的）")]
    [SwaggerResponse(201, "添加数据项成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> PostNewsCommentReport([FromBody] NewsCommentReport newsCommentReport)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.NewsCommentReportSet.Add(newsCommentReport);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostNewsCommentReport), new { id = newsCommentReport.NewsCommentReportId },
            newsCommentReport);
    }

    // 根据主键（ID）更新新闻评论举报表的数据
    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新新闻评论举报表的数据", Description = "根据主键（ID）更新新闻评论举报表的数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdateNewsCommentReport(int id, [FromBody] NewsCommentReport newsCommentReport)
    {
        if (id != newsCommentReport.NewsCommentReportId)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Entry(newsCommentReport).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.NewsCommentReportSet.Any(e => e.NewsCommentReportId == id))
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

    // 获取新闻评论举报管理数据
    [HttpGet("management")]
    [SwaggerOperation(Summary = "获取新闻评论举报管理数据", Description = "获取新闻评论举报管理数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<object>>> GetNewsCommentReportManagement()
    {
        try
        {
            return Ok(await context.NewsCommentReportSet
                .OrderByDescending(p => p.ReportTime)
                .Select(p => new
                {
                    p.NewsCommentReportId,
                    p.ReporterId,
                    ReporterName = p.Reporter!.UserName,
                    p.ReportedUserId,
                    ReportedUserName = p.ReportedUser!.UserName,
                    p.ReportedNewsId,
                    p.ReportedNews!.Title,
                    p.ReportedCommentId,
                    p.ReportedComment!.Content,
                    p.ReportReason,
                    p.ReportTime,
                    p.Status
                })
                .ToListAsync());
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}