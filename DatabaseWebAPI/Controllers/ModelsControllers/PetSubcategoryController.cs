/*
 * Project Name:  DatabaseWebAPI
 * File Name:     PetSubcategoryController.cs
 * File Function: PetSubcategory 控制器
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-08-14
 * License:       Creative Commons Attribution 4.0 International License
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseWebAPI.Data;
using DatabaseWebAPI.Models.RequestModels;
using DatabaseWebAPI.Models.TableModels;
using Swashbuckle.AspNetCore.Annotations;
using DatabaseWebAPI.Utils;

namespace DatabaseWebAPI.Controllers.ModelsControllers;

[Route("api/pet-subcategory")]
[ApiController]
[SwaggerTag("宠物子类表相关 API")]
public class PetSubcategoryController(OracleDbContext context) : ControllerBase
{
    // 获取宠物子类表的所有数据
    [HttpGet]
    [SwaggerOperation(Summary = "获取宠物子类表的所有数据", Description = "获取宠物子类表的所有数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<PetSubcategory>>> GetPetSubcategory()
    {
        try
        {
            return Ok(await context.PetSubcategorySet.ToListAsync());
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

    // 根据主键（ID）获取宠物子类表的数据
    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取宠物子类表的数据", Description = "根据主键（ID）获取宠物子类表的数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<PetSubcategory>> GetPetSubcategoryByPk(int id)
    {
        try
        {
            var petSubcategory = await context.PetSubcategorySet.FindAsync(id);
            if (petSubcategory == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            return Ok(petSubcategory);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）和语言（Language）获取宠物子类表的宠物子类名称数据
    [HttpGet("subcategory-name/{id:int}-{language}")]
    [SwaggerOperation(Summary = "根据主键（ID）和语言（Language）获取宠物子类表的宠物子类名称数据",
        Description = "根据主键（ID）和语言（Language）获取宠物子类表的宠物子类名称数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<PetSubcategory>> GetPetSubcategoryNameByPkAndLanguage(int id, string language)
    {
        try
        {
            var petSubcategory = await context.PetSubcategorySet
                .Where(p => p.SubcategoryId == id)
                .Select(p => EF.Property<string>(p, FieldNameUtils.GetSubcategoryNameFieldName(language)))
                .FirstOrDefaultAsync();
            if (petSubcategory == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            return Ok(petSubcategory);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据数量（Number）和语言（Language）获取推荐宠物的数据
    [HttpGet("recommended-pet/{number:int}-{language}")]
    [SwaggerOperation(Summary = "根据数量（Number）和语言（Language）获取推荐宠物的数据",
        Description = "根据数量（Number）和语言（Language）获取推荐宠物的数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<RecommendedPetRequest>>> GetRecommendedPetByNumberAndLanguage(int number,
        string language)
    {
        try
        {
            var allIds = await context.PetSubcategorySet.Select(p => p.SubcategoryId).ToListAsync();
            var randomIds = allIds.OrderBy(_ => Guid.NewGuid()).Take(number).ToList();
            var recommendedPets = await context.PetSubcategorySet
                .Where(p => randomIds.Contains(p.SubcategoryId))
                .Select(petSubcategory => new RecommendedPetRequest
                {
                    SubcategoryId = petSubcategory.SubcategoryId,
                    SubcategoryName = EF.Property<string>(petSubcategory,
                        FieldNameUtils.GetSubcategoryNameFieldName(language)),
                    Description = EF.Property<string>(petSubcategory, FieldNameUtils.GetDescriptionFieldName(language)),
                    ImageUrl = petSubcategory.ImageUrl
                })
                .ToListAsync();
            return Ok(recommendedPets);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）删除宠物子类表的数据
    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）删除宠物子类表的数据", Description = "根据主键（ID）删除宠物子类表的数据")]
    [SwaggerResponse(200, "删除数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<PetSubcategory>> DeletePetSubcategoryByPk(int id)
    {
        try
        {
            var petSubcategory = await context.PetSubcategorySet.FindAsync(id);
            if (petSubcategory == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            context.PetSubcategorySet.Remove(petSubcategory);
            await context.SaveChangesAsync();
            return Ok($"Data with ID: {id} has been deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 向宠物子类表添加数据项
    [HttpPost]
    [SwaggerOperation(Summary = "向宠物子类表添加数据项", Description = "向宠物子类表添加数据项")]
    [SwaggerResponse(201, "添加数据项成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> PostPetSubcategory([FromBody] PetSubcategory petSubcategory)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.PetSubcategorySet.Add(petSubcategory);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostPetSubcategory), new { id = petSubcategory.SubcategoryId }, petSubcategory);
    }

    // 根据主键（ID）更新宠物子类表的数据
    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新宠物子类表的数据", Description = "根据主键（ID）更新宠物子类表的数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdatePetSubcategory(int id, [FromBody] PetSubcategory petSubcategory)
    {
        if (id != petSubcategory.SubcategoryId)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Entry(petSubcategory).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.PetSubcategorySet.Any(e => e.SubcategoryId == id))
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