/*
 * Project Name:  DatabaseWebAPI
 * File Name:     PostController.cs
 * File Function: Post 控制器
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

[Route("api/post")]
[ApiController]
[SwaggerTag("帖子表相关 API")]
public class PostController(OracleDbContext context) : ControllerBase
{
    // 获取帖子表的所有数据
    [HttpGet]
    [SwaggerOperation(Summary = "获取帖子表的所有数据", Description = "获取帖子表的所有数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<Post>>> GetPost()
    {
        try
        {
            return Ok(await context.PostSet.ToListAsync());
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

    // 根据主键（ID）获取帖子表的数据
    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取帖子表的数据", Description = "根据主键（ID）获取帖子表的数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<Post>> GetPostByPk(int id)
    {
        try
        {
            var post = await context.PostSet.FindAsync(id);
            if (post == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            return Ok(post);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）删除帖子表的数据
    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）删除帖子表的数据", Description = "根据主键（ID）删除帖子表的数据")]
    [SwaggerResponse(200, "删除数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<Post>> DeletePostByPk(int id)
    {
        try
        {
            var post = await context.PostSet.FindAsync(id);
            if (post == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            context.PostSet.Remove(post);
            await context.SaveChangesAsync();
            return Ok($"Data with ID: {id} has been deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 向帖子表添加数据项
    [HttpPost]
    [SwaggerOperation(Summary = "向帖子表添加数据项", Description = "向帖子表添加数据项（不需要提供 POST_ID，因为它是由系统自动生成的）")]
    [SwaggerResponse(201, "添加数据项成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> PostPost([FromBody] Post post)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.PostSet.Add(post);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostPost), new { id = post.PostId }, post);
    }

    // 根据主键（ID）更新帖子表的数据
    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新帖子表的数据", Description = "根据主键（ID）更新帖子表的数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdatePost(int id, [FromBody] Post post)
    {
        if (id != post.PostId)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Entry(post).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.PostSet.Any(e => e.PostId == id))
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

    // 根据帖子分类（CategoryId）筛选帖子表的主键（ID）
    [HttpPost("filter-by-category")]
    [SwaggerOperation(Summary = "根据帖子分类（CategoryId）筛选帖子表的主键（ID）", Description = "根据帖子分类（CategoryId）筛选帖子表的主键（ID）")]
    [SwaggerResponse(200, "筛选成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<IEnumerable<int>>> FilterPostIdByCategoryId([FromBody] List<int> categoryIds)
    {
        if (categoryIds.Count == 0)
        {
            return BadRequest("Category ID list cannot be null or empty.");
        }

        try
        {
            var postIds = await context.PostSet
                .Where(post => categoryIds.Contains(post.CategoryId))
                .OrderByDescending(post => post.IsSticky) 
                .ThenByDescending(post => post.CreationDate)
                .Select(post => post.PostId)
                .ToListAsync();
            return Ok(postIds);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}