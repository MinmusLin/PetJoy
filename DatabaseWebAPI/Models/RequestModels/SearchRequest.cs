/*
 * Project Name:  DatabaseWebAPI
 * File Name:     SearchRequest.cs
 * File Function: 搜索请求类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-08-14
 * License:       Creative Commons Attribution 4.0 International License
 */

using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Models.RequestModels;

[SwaggerSchema(Description = "宠物分类搜索请求类")]
public class PetCategorySearchRequest
{
    [SwaggerSchema("宠物分类ID")] public int CategoryId { get; set; }
    [SwaggerSchema("宠物分类名称")] public string CategoryName { get; set; } = string.Empty;
    [SwaggerSchema("描述")] public string Description { get; set; } = string.Empty;
}

[SwaggerSchema(Description = "宠物子类搜索请求类")]
public class PetSubcategorySearchRequest
{
    [SwaggerSchema("宠物子类ID")] public int SubcategoryId { get; set; }
    [SwaggerSchema("宠物子类名称")] public string SubcategoryName { get; set; } = string.Empty;
    [SwaggerSchema("描述")] public string Description { get; set; } = string.Empty;
    [SwaggerSchema("起源地")] public string Origin { get; set; } = string.Empty;
    [SwaggerSchema("体型")] public string Size { get; set; } = string.Empty;
    [SwaggerSchema("毛色")] public string Coat { get; set; } = string.Empty;
    [SwaggerSchema("寿命")] public string Lifespan { get; set; } = string.Empty;
    [SwaggerSchema("性情")] public string Temperament { get; set; } = string.Empty;
    [SwaggerSchema("饮食习惯")] public string Diet { get; set; } = string.Empty;
}

[SwaggerSchema(Description = "宠物护理指导搜索请求类")]
public class PetCareGuideSearchRequest
{
    [SwaggerSchema("宠物子类ID")] public int SubcategoryId { get; set; }
    [SwaggerSchema("搜索标题")] public string SearchTitle { get; set; } = string.Empty;
    [SwaggerSchema("标题")] public string Title { get; set; } = string.Empty;
    [SwaggerSchema("内容")] public string Content { get; set; } = string.Empty;
}

[SwaggerSchema(Description = "新闻搜索请求类")]
public class NewsSearchRequest
{
    [SwaggerSchema("新闻ID")] public int NewsId { get; set; }
    [SwaggerSchema("标题")] public string Title { get; set; } = string.Empty;
    [SwaggerSchema("新闻摘要")] public string Summary { get; set; } = string.Empty;
    [SwaggerSchema("内容")] public string Content { get; set; } = string.Empty;
}

[SwaggerSchema(Description = "帖子搜索请求类")]
public class PostSearchRequest
{
    [SwaggerSchema("帖子ID")] public int PostId { get; set; }
    [SwaggerSchema("标题")] public string Title { get; set; } = string.Empty;
    [SwaggerSchema("内容")] public string Content { get; set; } = string.Empty;
}

[SwaggerSchema(Description = "帖子评论搜索请求类")]
public class PostCommentSearchRequest
{
    [SwaggerSchema("帖子ID")] public int PostId { get; set; }
    [SwaggerSchema("标题")] public string Title { get; set; } = string.Empty;
    [SwaggerSchema("评论内容")] public string Content { get; set; } = string.Empty;
}

[SwaggerSchema(Description = "宠物领养搜索请求类")]
public class PetAdoptionSearchRequest
{
    [SwaggerSchema("宠物领养ID")] public int AdoptionId { get; set; }
    [SwaggerSchema("宠物名称")] public string? Name { get; set; }
    [SwaggerSchema("地址")] public string Location { get; set; } = string.Empty;
    [SwaggerSchema("转让原因")] public string Reason { get; set; } = string.Empty;
    [SwaggerSchema("健康情况")] public string Health { get; set; } = string.Empty;
    [SwaggerSchema("疫苗接种情况")] public string Vaccination { get; set; } = string.Empty;
    [SwaggerSchema("特殊护理需求")] public string? CareNeeds { get; set; }
    [SwaggerSchema("特殊饮食需求")] public string? DietaryNeeds { get; set; }
    [SwaggerSchema("性格行为特征")] public string? Behavior { get; set; }
    [SwaggerSchema("备注")] public string? Notes { get; set; }
}