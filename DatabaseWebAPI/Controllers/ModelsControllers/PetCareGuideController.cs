/*
 * Project Name:  DatabaseWebAPI
 * File Name:     PetCareGuideController.cs
 * File Function: PetCareGuide 控制器
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-08-14
 * License:       Creative Commons Attribution 4.0 International License
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseWebAPI.Data;
using DatabaseWebAPI.Models.TableModels;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Controllers.ModelsControllers;

[Route("api/pet-care-guide")]
[ApiController]
[SwaggerTag("宠物护理指导表相关 API")]
public class PetCareGuideController(OracleDbContext context) : ControllerBase
{
    // 获取宠物护理指导表的所有数据
    [HttpGet]
    [SwaggerOperation(Summary = "获取宠物护理指导表的所有数据", Description = "获取宠物护理指导表的所有数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<PetCareGuide>>> GetPetCareGuide()
    {
        try
        {
            return Ok(await context.PetCareGuideSet.ToListAsync());
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

    // 根据主键（ID）获取宠物护理指导表的数据
    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取宠物护理指导表的数据", Description = "根据主键（ID）获取宠物护理指导表的数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<PetCareGuide>> GetPetCareGuideByPk(int id)
    {
        try
        {
            var petCareGuide = await context.PetCareGuideSet.FindAsync(id);
            if (petCareGuide == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            return Ok(petCareGuide);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）删除宠物护理指导表的数据
    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）删除宠物护理指导表的数据", Description = "根据主键（ID）删除宠物护理指导表的数据")]
    [SwaggerResponse(200, "删除数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<PetCareGuide>> DeletePetCareGuideByPk(int id)
    {
        try
        {
            var petCareGuide = await context.PetCareGuideSet.FindAsync(id);
            if (petCareGuide == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            context.PetCareGuideSet.Remove(petCareGuide);
            await context.SaveChangesAsync();
            return Ok($"Data with ID: {id} has been deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 向宠物护理指导表添加数据项
    [HttpPost]
    [SwaggerOperation(Summary = "向宠物护理指导表添加数据项", Description = "向宠物护理指导表添加数据项")]
    [SwaggerResponse(201, "添加数据项成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> PostPetCareGuide([FromBody] PetCareGuide petCareGuide)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.PetCareGuideSet.Add(petCareGuide);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostPetCareGuide), new { id = petCareGuide.GuideId }, petCareGuide);
    }

    // 根据主键（ID）更新宠物护理指导表的数据
    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新宠物护理指导表的数据", Description = "根据主键（ID）更新宠物护理指导表的数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdatePetCareGuide(int id, [FromBody] PetCareGuide petCareGuide)
    {
        if (id != petCareGuide.GuideId)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Entry(petCareGuide).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.PetCareGuideSet.Any(e => e.GuideId == id))
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