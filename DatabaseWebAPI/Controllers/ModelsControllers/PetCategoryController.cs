/*
 * Project Name:  DatabaseWebAPI
 * File Name:     PetCategoryController.cs
 * File Function: PetCategory 控制器
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-08-14
 * License:       Creative Commons Attribution 4.0 International License
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseWebAPI.Data;
using DatabaseWebAPI.Models.TableModels;
using DatabaseWebAPI.Utils;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Controllers.ModelsControllers;

[Route("api/pet-category")]
[ApiController]
[SwaggerTag("宠物分类表相关 API")]
public class PetCategoryController(OracleDbContext context) : ControllerBase
{
    // 获取宠物分类表的所有数据
    [HttpGet]
    [SwaggerOperation(Summary = "获取宠物分类表的所有数据", Description = "获取宠物分类表的所有数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<PetCategory>>> GetPetCategory()
    {
        try
        {
            return Ok(await context.PetCategorySet.ToListAsync());
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

    // 根据主键（ID）获取宠物分类表的数据
    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取宠物分类表的数据", Description = "根据主键（ID）获取宠物分类表的数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<PetCategory>> GetPetCategoryByPk(int id)
    {
        try
        {
            var petCategory = await context.PetCategorySet.FindAsync(id);
            if (petCategory == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            return Ok(petCategory);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）和语言（Language）获取宠物分类表的宠物分类名称数据
    [HttpGet("category-name/{id:int}-{language}")]
    [SwaggerOperation(Summary = "根据主键（ID）和语言（Language）获取宠物分类表的宠物分类名称数据",
        Description = "根据主键（ID）和语言（Language）获取宠物分类表的宠物分类名称数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<PetCategory>> GetPetCategoryNameByPkAndLanguage(int id, string language)
    {
        try
        {
            var petCategory = await context.PetCategorySet
                .Where(p => p.CategoryId == id)
                .Select(p => EF.Property<string>(p, FieldNameUtils.GetCategoryNameFieldName(language)))
                .FirstOrDefaultAsync();
            if (petCategory == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            return Ok(petCategory);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）删除宠物分类表的数据
    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）删除宠物分类表的数据", Description = "根据主键（ID）删除宠物分类表的数据")]
    [SwaggerResponse(200, "删除数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<PetCategory>> DeletePetCategoryByPk(int id)
    {
        try
        {
            var petCategory = await context.PetCategorySet.FindAsync(id);
            if (petCategory == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            context.PetCategorySet.Remove(petCategory);
            await context.SaveChangesAsync();
            return Ok($"Data with ID: {id} has been deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 向宠物分类表添加数据项
    [HttpPost]
    [SwaggerOperation(Summary = "向宠物分类表添加数据项", Description = "向宠物分类表添加数据项")]
    [SwaggerResponse(201, "添加数据项成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> PostPetCategory([FromBody] PetCategory petCategory)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.PetCategorySet.Add(petCategory);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostPetCategory), new { id = petCategory.CategoryId }, petCategory);
    }

    // 根据主键（ID）更新宠物分类表的数据
    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新宠物分类表的数据", Description = "根据主键（ID）更新宠物分类表的数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdatePetCategory(int id, [FromBody] PetCategory petCategory)
    {
        if (id != petCategory.CategoryId)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Entry(petCategory).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.PetCategorySet.Any(e => e.CategoryId == id))
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