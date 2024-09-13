/*
 * Project Name:  DatabaseWebAPI
 * File Name:     PetEncyclopediaController.cs
 * File Function: 宠物百科控制器
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-08-03
 * License:       Creative Commons Attribution 4.0 International License
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseWebAPI.Data;
using Swashbuckle.AspNetCore.Annotations;
using DatabaseWebAPI.Models.RequestModels;
using DatabaseWebAPI.Utils;

#pragma warning disable CS8604

namespace DatabaseWebAPI.Controllers.PetEncyclopediaControllers;

[Route("api/pet-encyclopedia")]
[ApiController]
[SwaggerTag("宠物百科相关 API")]
public class PetEncyclopediaController(OracleDbContext context) : ControllerBase
{
    // 获取宠物百科的菜单索引数据
    [HttpGet("menu-index/{language}")]
    [SwaggerOperation(Summary = "获取宠物百科的菜单索引数据", Description = "获取宠物百科的菜单索引数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<object>>> GetMenuIndex(string language)
    {
        try
        {
            var categories = await context.PetCategorySet
                .Include(category => category.PetSubcategoryEntity)
                .OrderBy(category => category.CategoryId)
                .Select(category => new
                {
                    // ReSharper disable once RedundantAnonymousTypePropertyName
                    CategoryId = category.CategoryId,
                    CategoryName = EF.Property<string>(category, FieldNameUtils.GetCategoryNameFieldName(language)),
                    Subcategories = category.PetSubcategoryEntity
                        .OrderBy(subcategory => subcategory.SubcategoryId)
                        .Select(subcategory => new
                        {
                            // ReSharper disable once RedundantAnonymousTypePropertyName
                            SubcategoryId = subcategory.SubcategoryId,
                            SubcategoryName = EF.Property<string>(subcategory,
                                FieldNameUtils.GetSubcategoryNameFieldName(language))
                        })
                }).ToListAsync();
            if (categories.Count == 0)
            {
                return NotFound("No corresponding data.");
            }

            var result = categories.Select(category => new
            {
                index = category.CategoryId.ToString(),
                title = category.CategoryName,
                children = category.Subcategories.Select(subcategory => new
                {
                    index = subcategory.SubcategoryId.ToString(),
                    title = subcategory.SubcategoryName
                }).ToList()
            });
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 获取宠物百科的宠物分类页面数据
    [HttpGet("pet-category-page/{id:int}-{language}")]
    [SwaggerOperation(Summary = "获取宠物百科的宠物分类页面数据", Description = "获取宠物百科的宠物分类页面数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<PetCategoryPageRequest>> GetPetCategoryPage(int id, string language)
    {
        try
        {
            var petCategory = await context.PetCategorySet
                .Include(c => c.PetSubcategoryEntity)
                .Where(c => c.CategoryId == id)
                .Select(c => new PetCategoryPageRequest
                {
                    CategoryId = c.CategoryId,
                    CategoryName = EF.Property<string>(c, FieldNameUtils.GetCategoryNameFieldName(language)),
                    Description = EF.Property<string>(c, FieldNameUtils.GetDescriptionFieldName(language)),
                    ImageUrl = c.ImageUrl,
                    PetSubcategoryRequests = c.PetSubcategoryEntity
                        .OrderBy(sub => sub.SubcategoryId)
                        .Select(sub => new PetSubcategoryInfo
                        {
                            SubcategoryId = sub.SubcategoryId,
                            SubcategoryName =
                                EF.Property<string>(sub, FieldNameUtils.GetSubcategoryNameFieldName(language)),
                            ImageUrl = sub.ImageUrl
                        }).ToList()
                }).FirstOrDefaultAsync();
            if (petCategory == null)
            {
                return NotFound("No corresponding data.");
            }

            return Ok(petCategory);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 获取宠物百科的宠物子类页面数据
    [HttpGet("pet-subcategory-page/{id:int}-{language}")]
    [SwaggerOperation(Summary = "获取宠物百科的宠物子类页面数据", Description = "获取宠物百科的宠物子类页面数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<PetSubcategoryPageRequest>> GetPetSubcategoryPagePage(int id, string language)
    {
        try
        {
            var petSubcategory = await context.PetSubcategorySet
                .Include(sub => sub.PetCareGuideEntity)
                .Where(sub => sub.SubcategoryId == id)
                .Select(sub => new PetSubcategoryPageRequest
                {
                    SubcategoryId = sub.SubcategoryId,
                    CategoryId = sub.CategoryId,
                    SubcategoryName = EF.Property<string>(sub, FieldNameUtils.GetSubcategoryNameFieldName(language)),
                    Description = EF.Property<string>(sub, FieldNameUtils.GetDescriptionFieldName(language)),
                    ImageUrl = sub.ImageUrl,
                    Origin = EF.Property<string>(sub, FieldNameUtils.GetOriginFieldName(language)),
                    Size = EF.Property<string>(sub, FieldNameUtils.GetSizeFieldName(language)),
                    Coat = EF.Property<string>(sub, FieldNameUtils.GetCoatFieldName(language)),
                    Lifespan = EF.Property<string>(sub, FieldNameUtils.GetLifespanFieldName(language)),
                    Temperament = EF.Property<string>(sub, FieldNameUtils.GetTemperamentFieldName(language)),
                    Diet = EF.Property<string>(sub, FieldNameUtils.GetDietFieldName(language)),
                    CategoryName = EF.Property<string>(sub.PetCategory, FieldNameUtils.GetCategoryNameFieldName(language)),
                    LatitudeAndLongitude = sub.LatitudeAndLongitude,
                    PetCareGuideRequests = sub.PetCareGuideEntity
                        .Where(guide => sub.SubcategoryId == guide.SubcategoryId)
                        .OrderBy(guide => guide.GuideId)
                        .Select(guide => new PetCareGuideInfo
                        {
                            GuideId = guide.GuideId,
                            SubcategoryId = guide.SubcategoryId,
                            Title = EF.Property<string>(guide, FieldNameUtils.GetTitleFieldName(language)),
                            Content = EF.Property<string>(guide, FieldNameUtils.GetContentFieldName(language)),
                        }).ToList()
                }).FirstOrDefaultAsync();
            if (petSubcategory == null)
            {
                return NotFound("No corresponding data.");
            }

            return Ok(petSubcategory);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}