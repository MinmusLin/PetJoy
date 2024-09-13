/*
 * Project Name:  DatabaseWebAPI
 * File Name:     PetAdoptionController.cs
 * File Function: PetAdoption 控制器
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-09-02
 * License:       Creative Commons Attribution 4.0 International License
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseWebAPI.Data;
using DatabaseWebAPI.Models.TableModels;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Controllers.ModelsControllers;

[Route("api/pet-adoption")]
[ApiController]
[SwaggerTag("宠物领养表相关 API")]
public class PetAdoptionController(OracleDbContext context) : ControllerBase
{
    // 获取宠物领养表的所有数据
    [HttpGet]
    [SwaggerOperation(Summary = "获取宠物领养表的所有数据", Description = "获取宠物领养表的所有数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<PetAdoption>>> GetPetAdoption()
    {
        try
        {
            return Ok(await context.PetAdoptionSet.ToListAsync());
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

    // 根据主键（ID）获取宠物领养表的数据
    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取宠物领养表的数据", Description = "根据主键（ID）获取宠物领养表的数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<PetAdoption>> GetPetAdoptionByPk(int id)
    {
        try
        {
            var petAdoption = await context.PetAdoptionSet.FindAsync(id);
            if (petAdoption == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            return Ok(petAdoption);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）删除宠物领养表的数据
    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）删除宠物领养表的数据", Description = "根据主键（ID）删除宠物领养表的数据")]
    [SwaggerResponse(200, "删除数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<PetAdoption>> DeletePetAdoptionByPk(int id)
    {
        try
        {
            var petAdoption = await context.PetAdoptionSet.FindAsync(id);
            if (petAdoption == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            context.PetAdoptionSet.Remove(petAdoption);
            await context.SaveChangesAsync();
            return Ok($"Data with ID: {id} has been deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 向宠物领养表添加数据项
    [HttpPost]
    [SwaggerOperation(Summary = "向宠物领养表添加数据项", Description = "向宠物领养表添加数据项（不需要提供 ADOPTION_ID，因为它是由系统自动生成的）")]
    [SwaggerResponse(201, "添加数据项成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> PostPetAdoption([FromBody] PetAdoption petAdoption)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.PetAdoptionSet.Add(petAdoption);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostPetAdoption), new { id = petAdoption.AdoptionId }, petAdoption);
    }

    // 根据主键（ID）更新宠物领养表的数据
    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新宠物领养表的数据", Description = "根据主键（ID）更新宠物领养表的数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdatePetAdoption(int id, [FromBody] PetAdoption petAdoption)
    {
        if (id != petAdoption.AdoptionId)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Entry(petAdoption).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.PetAdoptionSet.Any(e => e.AdoptionId == id))
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

    // 获取宠物领养表的所有 ID
    [HttpGet("ids")]
    [SwaggerOperation(Summary = "获取宠物领养表的所有 ID", Description = "获取宠物领养表的所有 ID")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<int>>> GetPetAdoptionIds()
    {
        try
        {
            var ids = await context.PetAdoptionSet
                .Select(p => p.AdoptionId)
                .ToListAsync();
            return Ok(ids);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据 UserId 获取宠物领养表的所有 ID
    [HttpGet("ids/user-{userId:int}")]
    [SwaggerOperation(Summary = "根据 UserId 获取宠物领养表的所有 ID", Description = "根据 UserId 获取宠物领养表的所有 ID")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<int>>> GetPetAdoptionIdsByUser(int userId)
    {
        try
        {
            var ids = await context.PetAdoptionSet
                .Where(p => p.UserId == userId)
                .Select(p => p.AdoptionId)
                .ToListAsync();
            if (ids.Count == 0)
            {
                return NotFound($"No corresponding data found for User ID: {userId}");
            }
            return Ok(ids);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}