/*
 * Project Name:  DatabaseWebAPI
 * File Name:     SearchController.cs
 * File Function: 搜索控制器
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-08-14
 * License:       Creative Commons Attribution 4.0 International License
 */

using DatabaseWebAPI.Data;
using DatabaseWebAPI.Models.RequestModels;
using DatabaseWebAPI.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Controllers.SearchControllers;

[ApiController]
[Route("api/search")]
[SwaggerTag("搜索相关 API")]
public class SearchController(OracleDbContext context) : ControllerBase
{
    // 根据语言（Language）获取宠物分类的搜索数据
    [HttpGet("pet-category/{language}")]
    [SwaggerOperation(Summary = "根据语言（Language）获取宠物分类的搜索数据", Description = "根据语言（Language）获取宠物分类的搜索数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<PetCategorySearchRequest>>> GetPetCategorySearchData(string language)
    {
        try
        {
            return Ok(await context.PetCategorySet.Where(p => p.CategoryId != 0).Select(p =>
                new PetCategorySearchRequest
                {
                    CategoryId = p.CategoryId,
                    CategoryName = EF.Property<string>(p, FieldNameUtils.GetCategoryNameFieldName(language)),
                    Description = EF.Property<string>(p, FieldNameUtils.GetDescriptionFieldName(language))
                }).ToListAsync());
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

    // 根据语言（Language）获取宠物子类的搜索数据
    [HttpGet("pet-subcategory/{language}")]
    [SwaggerOperation(Summary = "根据语言（Language）获取宠物子类的搜索数据", Description = "根据语言（Language）获取宠物子类的搜索数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<PetSubcategorySearchRequest>>> GetPetSubcategorySearchData(
        string language)
    {
        try
        {
            return Ok(await context.PetSubcategorySet.Where(sub => sub.SubcategoryId != 0).Select(sub =>
                new PetSubcategorySearchRequest
                {
                    SubcategoryId = sub.SubcategoryId,
                    SubcategoryName = EF.Property<string>(sub, FieldNameUtils.GetSubcategoryNameFieldName(language)),
                    Description = EF.Property<string>(sub, FieldNameUtils.GetDescriptionFieldName(language)),
                    Origin = EF.Property<string>(sub, FieldNameUtils.GetOriginFieldName(language)),
                    Size = EF.Property<string>(sub, FieldNameUtils.GetSizeFieldName(language)),
                    Coat = EF.Property<string>(sub, FieldNameUtils.GetCoatFieldName(language)),
                    Lifespan = EF.Property<string>(sub, FieldNameUtils.GetLifespanFieldName(language)),
                    Temperament = EF.Property<string>(sub, FieldNameUtils.GetTemperamentFieldName(language)),
                    Diet = EF.Property<string>(sub, FieldNameUtils.GetDietFieldName(language))
                }).ToListAsync());
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

    // 根据语言（Language）获取宠物护理指导的搜索数据
    [HttpGet("pet-care-guide/{language}")]
    [SwaggerOperation(Summary = "根据语言（Language）获取宠物护理指导的搜索数据", Description = "根据语言（Language）获取宠物护理指导的搜索数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<PetCareGuideSearchRequest>>> GetPetCareGuideSearchData(string language)
    {
        try
        {
            return Ok(await context.PetCareGuideSet.Select(c =>
                new PetCareGuideSearchRequest
                {
                    SubcategoryId = c.SubcategoryId,
                    SearchTitle =
                        EF.Property<string>(c.PetSubcategory!, FieldNameUtils.GetSubcategoryNameFieldName(language)) +
                        " / " + EF.Property<string>(c, FieldNameUtils.GetTitleFieldName(language)),
                    Title = EF.Property<string>(c, FieldNameUtils.GetTitleFieldName(language)),
                    Content = EF.Property<string>(c, FieldNameUtils.GetContentFieldName(language))
                }).ToListAsync());
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

    // 获取新闻的搜索数据
    [HttpGet("news")]
    [SwaggerOperation(Summary = "获取新闻的搜索数据", Description = "获取新闻的搜索数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<NewsSearchRequest>>> GetNewsSearchData()
    {
        try
        {
            return Ok(await context.NewsSet.Select(n =>
                new NewsSearchRequest
                {
                    NewsId = n.NewsId,
                    Title = n.Title,
                    Summary = n.Summary,
                    Content = n.Content
                }).ToListAsync());
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

    // 获取帖子的搜索数据
    [HttpGet("post")]
    [SwaggerOperation(Summary = "获取帖子的搜索数据", Description = "获取帖子的搜索数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<PostSearchRequest>>> GetPostSearchData()
    {
        try
        {
            return Ok(await context.PostSet.Select(p =>
                new PostSearchRequest
                {
                    PostId = p.PostId,
                    Title = p.Title,
                    Content = p.Content
                }).ToListAsync());
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

    // 获取帖子评论的搜索数据
    [HttpGet("post-comment")]
    [SwaggerOperation(Summary = "获取帖子评论的搜索数据", Description = "获取帖子评论的搜索数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<PostCommentSearchRequest>>> GetPostCommentSearchData()
    {
        try
        {
            return Ok(await context.PostCommentSet.Select(p =>
                new PostCommentSearchRequest
                {
                    PostId = p.PostId,
                    Title = p.Post!.Title,
                    Content = p.Content
                }).ToListAsync());
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

    // 获取宠物领养的搜索数据
    [HttpGet("pet-adoption")]
    [SwaggerOperation(Summary = "获取宠物领养的搜索数据", Description = "获取宠物领养的搜索数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<PetAdoptionSearchRequest>>> GetPetAdoptionSearchData()
    {
        try
        {
            return Ok(await context.PetAdoptionSet.Select(p =>
                new PetAdoptionSearchRequest
                {
                    AdoptionId = p.AdoptionId,
                    Name = p.Name,
                    Location = p.Location,
                    Reason = p.Reason,
                    Health = p.Health,
                    Vaccination = p.Vaccination,
                    CareNeeds = p.CareNeeds,
                    DietaryNeeds = p.DietaryNeeds,
                    Behavior = p.Behavior,
                    Notes = p.Notes
                }).ToListAsync());
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
}