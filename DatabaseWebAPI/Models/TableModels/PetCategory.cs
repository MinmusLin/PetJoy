/*
 * Project Name:  DatabaseWebAPI
 * File Name:     PetCategory.cs
 * File Function: PetCategory 模型类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-25
 * License:       Creative Commons Attribution 4.0 International License
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

// ReSharper disable EntityFramework.ModelValidation.UnlimitedStringLength

namespace DatabaseWebAPI.Models.TableModels;

[Table("PET_CATEGORY")]
[SwaggerSchema(Description = "宠物分类表")]
public sealed class PetCategory
{
    // 属性定义
    [Key]
    [Column("CATEGORY_ID")]
    [SwaggerSchema("宠物分类ID")]
    public int CategoryId { get; set; }

    [Required]
    [Column("CATEGORY_NAME_ZH")]
    [StringLength(1024)]
    [SwaggerSchema("宠物分类名称（汉语）")]
    public string CategoryNameZh { get; set; } = string.Empty;

    [Required]
    [Column("CATEGORY_NAME_DE")]
    [StringLength(1024)]
    [SwaggerSchema("宠物分类名称（德语）")]
    public string CategoryNameDe { get; set; } = string.Empty;

    [Required]
    [Column("CATEGORY_NAME_EN")]
    [StringLength(1024)]
    [SwaggerSchema("宠物分类名称（英语）")]
    public string CategoryNameEn { get; set; } = string.Empty;

    [Required]
    [Column("CATEGORY_NAME_ES")]
    [StringLength(1024)]
    [SwaggerSchema("宠物分类名称（西班牙语）")]
    public string CategoryNameEs { get; set; } = string.Empty;

    [Required]
    [Column("CATEGORY_NAME_FR")]
    [StringLength(1024)]
    [SwaggerSchema("宠物分类名称（法语）")]
    public string CategoryNameFr { get; set; } = string.Empty;

    [Required]
    [Column("CATEGORY_NAME_IT")]
    [StringLength(1024)]
    [SwaggerSchema("宠物分类名称（意大利语）")]
    public string CategoryNameIt { get; set; } = string.Empty;

    [Required]
    [Column("CATEGORY_NAME_JA")]
    [StringLength(1024)]
    [SwaggerSchema("宠物分类名称（日语）")]
    public string CategoryNameJa { get; set; } = string.Empty;

    [Required]
    [Column("CATEGORY_NAME_KO")]
    [StringLength(1024)]
    [SwaggerSchema("宠物分类名称（韩语）")]
    public string CategoryNameKo { get; set; } = string.Empty;

    [Required]
    [Column("CATEGORY_NAME_PT")]
    [StringLength(1024)]
    [SwaggerSchema("宠物分类名称（葡萄牙语）")]
    public string CategoryNamePt { get; set; } = string.Empty;

    [Required]
    [Column("CATEGORY_NAME_RU")]
    [StringLength(1024)]
    [SwaggerSchema("宠物分类名称（俄语）")]
    public string CategoryNameRu { get; set; } = string.Empty;

    [Required]
    [Column("DESCRIPTION_ZH")]
    [SwaggerSchema("描述（汉语）")]
    public string DescriptionZh { get; set; } = string.Empty;

    [Required]
    [Column("DESCRIPTION_DE")]
    [SwaggerSchema("描述（德语）")]
    public string DescriptionDe { get; set; } = string.Empty;

    [Required]
    [Column("DESCRIPTION_EN")]
    [SwaggerSchema("描述（英语）")]
    public string DescriptionEn { get; set; } = string.Empty;

    [Required]
    [Column("DESCRIPTION_ES")]
    [SwaggerSchema("描述（西班牙语）")]
    public string DescriptionEs { get; set; } = string.Empty;

    [Required]
    [Column("DESCRIPTION_FR")]
    [SwaggerSchema("描述（法语）")]
    public string DescriptionFr { get; set; } = string.Empty;

    [Required]
    [Column("DESCRIPTION_IT")]
    [SwaggerSchema("描述（意大利语）")]
    public string DescriptionIt { get; set; } = string.Empty;

    [Required]
    [Column("DESCRIPTION_JA")]
    [SwaggerSchema("描述（日语）")]
    public string DescriptionJa { get; set; } = string.Empty;

    [Required]
    [Column("DESCRIPTION_KO")]
    [SwaggerSchema("描述（韩语）")]
    public string DescriptionKo { get; set; } = string.Empty;

    [Required]
    [Column("DESCRIPTION_PT")]
    [SwaggerSchema("描述（葡萄牙语）")]
    public string DescriptionPt { get; set; } = string.Empty;

    [Required]
    [Column("DESCRIPTION_RU")]
    [SwaggerSchema("描述（俄语）")]
    public string DescriptionRu { get; set; } = string.Empty;

    [Required]
    [Column("IMAGE_URL")]
    [StringLength(2048)]
    [SwaggerSchema("图片链接")]
    public string ImageUrl { get; set; } = string.Empty;

    // 导航属性
    public ICollection<PetAdoption> PetAdoptionEntity { get; set; } = new HashSet<PetAdoption>();
    public ICollection<PetSubcategory> PetSubcategoryEntity { get; set; } = new HashSet<PetSubcategory>();
}