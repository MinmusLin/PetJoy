/*
 * Project Name:  DatabaseWebAPI
 * File Name:     RecommendedPetRequest.cs
 * File Function: 推荐宠物请求类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-25
 * License:       Creative Commons Attribution 4.0 International License
 */

using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Models.RequestModels;

[SwaggerSchema(Description = "推荐宠物请求类")]
public class RecommendedPetRequest
{
    [SwaggerSchema("宠物子类ID")] public int SubcategoryId { get; set; }
    [SwaggerSchema("宠物子类名称")] public string SubcategoryName { get; set; } = string.Empty;
    [SwaggerSchema("描述")] public string Description { get; set; } = string.Empty;
    [SwaggerSchema("图片链接")] public string ImageUrl { get; set; } = string.Empty;
}