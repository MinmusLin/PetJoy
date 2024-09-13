/*
 * Project Name:  DatabaseWebAPI
 * File Name:     PetEncyclopediaRequest.cs
 * File Function: 宠物百科请求类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-08-14
 * License:       Creative Commons Attribution 4.0 International License
 */

using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Models.RequestModels;

[SwaggerSchema(Description = "宠物子类信息类")]
public class PetSubcategoryInfo
{
    [SwaggerSchema("宠物子类ID")] public int SubcategoryId { get; set; }
    [SwaggerSchema("宠物子类名称")] public string SubcategoryName { get; set; } = string.Empty;
    [SwaggerSchema("图片链接")] public string ImageUrl { get; set; } = string.Empty;
}

[SwaggerSchema(Description = "宠物护理指导信息类")]
public class PetCareGuideInfo
{
    [SwaggerSchema("宠物护理指导ID")] public int GuideId { get; set; }
    [SwaggerSchema("宠物子类ID")] public int SubcategoryId { get; set; }
    [SwaggerSchema("标题")] public string Title { get; set; } = string.Empty;
    [SwaggerSchema("内容")] public string Content { get; set; } = string.Empty;
}

[SwaggerSchema(Description = "宠物分类页面请求类")]
public class PetCategoryPageRequest
{
    [SwaggerSchema("宠物分类ID")] public int CategoryId { get; set; }
    [SwaggerSchema("宠物分类名称")] public string CategoryName { get; set; } = string.Empty;
    [SwaggerSchema("描述")] public string Description { get; set; } = string.Empty;
    [SwaggerSchema("图片链接")] public string ImageUrl { get; set; } = string.Empty;
    [SwaggerSchema("宠物子类信息")] public List<PetSubcategoryInfo> PetSubcategoryRequests { get; set; } = [];
}

[SwaggerSchema(Description = "宠物子类页面请求类")]
public class PetSubcategoryPageRequest
{
    [SwaggerSchema("宠物子类ID")] public int SubcategoryId { get; set; }
    [SwaggerSchema("宠物分类ID")] public int CategoryId { get; set; }
    [SwaggerSchema("宠物子类名称")] public string SubcategoryName { get; set; } = string.Empty;
    [SwaggerSchema("描述")] public string Description { get; set; } = string.Empty;
    [SwaggerSchema("图片链接")] public string ImageUrl { get; set; } = string.Empty;
    [SwaggerSchema("起源地")] public string Origin { get; set; } = string.Empty;
    [SwaggerSchema("体型")] public string Size { get; set; } = string.Empty;
    [SwaggerSchema("毛色")] public string Coat { get; set; } = string.Empty;
    [SwaggerSchema("寿命")] public string Lifespan { get; set; } = string.Empty;
    [SwaggerSchema("性情")] public string Temperament { get; set; } = string.Empty;
    [SwaggerSchema("饮食习惯")] public string Diet { get; set; } = string.Empty;
    [SwaggerSchema("宠物分类名称")] public string CategoryName { get; set; } = string.Empty;
    [SwaggerSchema("经纬度参数")] public string LatitudeAndLongitude { get; set; } = string.Empty;
    [SwaggerSchema("宠物护理指导信息")] public List<PetCareGuideInfo> PetCareGuideRequests { get; set; } = [];
}