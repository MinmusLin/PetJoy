/*
 * Project Name:  DatabaseWebAPI
 * File Name:     PostCategoryController.cs
 * File Function: PostCategory 控制器
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-10
 * License:       Creative Commons Attribution 4.0 International License
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseWebAPI.Data;
using DatabaseWebAPI.Models.TableModels;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Controllers.ModelsControllers;

[Route("api/post-category")]
[ApiController]
[SwaggerTag("帖子分类表相关 API")]
public class PostCategoryController(OracleDbContext context) : ControllerBase
{
    // 获取帖子分类表的所有数据
    [HttpGet]
    [SwaggerOperation(Summary = "获取帖子分类表的所有数据", Description = "获取帖子分类表的所有数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<PostCategory>>> GetPostCategory()
    {
        try
        {
            return Ok(await context.PostCategorySet.ToListAsync());
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

    // 根据主键（ID）获取帖子分类表的数据
    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取帖子分类表的数据", Description = "根据主键（ID）获取帖子分类表的数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<PostCategory>> GetPostCategoryByPk(int id)
    {
        try
        {
            var postCategory = await context.PostCategorySet.FindAsync(id);
            if (postCategory == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            return Ok(postCategory);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）删除帖子分类表的数据
    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）删除帖子分类表的数据", Description = "根据主键（ID）删除帖子分类表的数据")]
    [SwaggerResponse(200, "删除数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<PostCategory>> DeletePostCategoryByPk(int id)
    {
        try
        {
            var postCategory = await context.PostCategorySet.FindAsync(id);
            if (postCategory == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            context.PostCategorySet.Remove(postCategory);
            await context.SaveChangesAsync();
            return Ok($"Data with ID: {id} has been deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 向帖子分类表添加数据项
    [HttpPost]
    [SwaggerOperation(Summary = "向帖子分类表添加数据项", Description = "向帖子分类表添加数据项")]
    [SwaggerResponse(201, "添加数据项成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> PostPostCategory([FromBody] PostCategory postCategory)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.PostCategorySet.Add(postCategory);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostPostCategory), new { id = postCategory.CategoryId }, postCategory);
    }

    // 根据主键（ID）更新帖子分类表的数据
    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新帖子分类表的数据", Description = "根据主键（ID）更新帖子分类表的数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdatePostCategory(int id, [FromBody] PostCategory postCategory)
    {
        if (id != postCategory.CategoryId)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Entry(postCategory).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.PostCategorySet.Any(e => e.CategoryId == id))
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