/*
 * Project Name:  DatabaseWebAPI
 * File Name:     DevelopmentTeamController.cs
 * File Function: DevelopmentTeam 控制器
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

[Route("api/development-team")]
[ApiController]
[SwaggerTag("开发团队表相关 API")]
public class DevelopmentTeamController(OracleDbContext context) : ControllerBase
{
    // 获取开发团队表的所有数据
    [HttpGet]
    [SwaggerOperation(Summary = "获取开发团队表的所有数据", Description = "获取开发团队表的所有数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<DevelopmentTeam>>> GetDevelopmentTeam()
    {
        try
        {
            return Ok(await context.DevelopmentTeamSet.ToListAsync());
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

    // 根据主键（ID）获取开发团队表的数据
    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取开发团队表的数据", Description = "根据主键（ID）获取开发团队表的数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<DevelopmentTeam>> GetDevelopmentTeamByPk(int id)
    {
        try
        {
            var developmentTeam = await context.DevelopmentTeamSet.FindAsync(id);
            if (developmentTeam == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            return Ok(developmentTeam);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）删除开发团队表的数据
    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）删除开发团队表的数据", Description = "根据主键（ID）删除开发团队表的数据")]
    [SwaggerResponse(200, "删除数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<DevelopmentTeam>> DeleteDevelopmentTeamByPk(int id)
    {
        try
        {
            var developmentTeam = await context.DevelopmentTeamSet.FindAsync(id);
            if (developmentTeam == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            context.DevelopmentTeamSet.Remove(developmentTeam);
            await context.SaveChangesAsync();
            return Ok($"Data with ID: {id} has been deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 向开发团队表添加数据项
    [HttpPost]
    [SwaggerOperation(Summary = "向开发团队表添加数据项", Description = "向开发团队表添加数据项")]
    [SwaggerResponse(201, "添加数据项成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> PostDevelopmentTeam([FromBody] DevelopmentTeam developmentTeam)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.DevelopmentTeamSet.Add(developmentTeam);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostDevelopmentTeam), new { id = developmentTeam.Id }, developmentTeam);
    }

    // 根据主键（ID）更新开发团队表的数据
    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新开发团队表的数据", Description = "根据主键（ID）更新开发团队表的数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdateDevelopmentTeam(int id, [FromBody] DevelopmentTeam developmentTeam)
    {
        if (id != developmentTeam.Id)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Entry(developmentTeam).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.DevelopmentTeamSet.Any(e => e.Id == id))
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