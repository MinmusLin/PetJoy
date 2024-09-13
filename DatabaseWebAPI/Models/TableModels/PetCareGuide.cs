/*
 * Project Name:  DatabaseWebAPI
 * File Name:     PetCareGuide.cs
 * File Function: PetCareGuide 模型类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-25
 * License:       Creative Commons Attribution 4.0 International License
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

// ReSharper disable EntityFramework.ModelValidation.UnlimitedStringLength

namespace DatabaseWebAPI.Models.TableModels;

[Table("PET_CARE_GUIDE")]
[SwaggerSchema(Description = "宠物护理指导表")]
public sealed class PetCareGuide
{
    // 属性定义
    [Key]
    [Column("GUIDE_ID")]
    [SwaggerSchema("宠物护理指导ID")]
    public int GuideId { get; set; }

    [Required]
    [ForeignKey("PetSubcategory")]
    [Column("SUBCATEGORY_ID")]
    [SwaggerSchema("宠物子类ID")]
    public int SubcategoryId { get; set; }

    [Required]
    [Column("TITLE_ZH")]
    [StringLength(2048)]
    [SwaggerSchema("标题（汉语）")]
    public string TitleZh { get; set; } = string.Empty;

    [Required]
    [Column("TITLE_DE")]
    [StringLength(2048)]
    [SwaggerSchema("标题（德语）")]
    public string TitleDe { get; set; } = string.Empty;

    [Required]
    [Column("TITLE_EN")]
    [StringLength(2048)]
    [SwaggerSchema("标题（英语）")]
    public string TitleEn { get; set; } = string.Empty;

    [Required]
    [Column("TITLE_ES")]
    [StringLength(2048)]
    [SwaggerSchema("标题（西班牙语）")]
    public string TitleEs { get; set; } = string.Empty;

    [Required]
    [Column("TITLE_FR")]
    [StringLength(2048)]
    [SwaggerSchema("标题（法语）")]
    public string TitleFr { get; set; } = string.Empty;

    [Required]
    [Column("TITLE_IT")]
    [StringLength(2048)]
    [SwaggerSchema("标题（意大利语）")]
    public string TitleIt { get; set; } = string.Empty;

    [Required]
    [Column("TITLE_JA")]
    [StringLength(2048)]
    [SwaggerSchema("标题（日语）")]
    public string TitleJa { get; set; } = string.Empty;

    [Required]
    [Column("TITLE_KO")]
    [StringLength(2048)]
    [SwaggerSchema("标题（韩语）")]
    public string TitleKo { get; set; } = string.Empty;

    [Required]
    [Column("TITLE_PT")]
    [StringLength(2048)]
    [SwaggerSchema("标题（葡萄牙语）")]
    public string TitlePt { get; set; } = string.Empty;

    [Required]
    [Column("TITLE_RU")]
    [StringLength(2048)]
    [SwaggerSchema("标题（俄语）")]
    public string TitleRu { get; set; } = string.Empty;

    [Required]
    [Column("CONTENT_ZH")]
    [SwaggerSchema("内容（汉语）")]
    public string ContentZh { get; set; } = string.Empty;

    [Required]
    [Column("CONTENT_DE")]
    [SwaggerSchema("内容（德语）")]
    public string ContentDe { get; set; } = string.Empty;

    [Required]
    [Column("CONTENT_EN")]
    [SwaggerSchema("内容（英语）")]
    public string ContentEn { get; set; } = string.Empty;

    [Required]
    [Column("CONTENT_ES")]
    [SwaggerSchema("内容（西班牙语）")]
    public string ContentEs { get; set; } = string.Empty;

    [Required]
    [Column("CONTENT_FR")]
    [SwaggerSchema("内容（法语）")]
    public string ContentFr { get; set; } = string.Empty;

    [Required]
    [Column("CONTENT_IT")]
    [SwaggerSchema("内容（意大利语）")]
    public string ContentIt { get; set; } = string.Empty;

    [Required]
    [Column("CONTENT_JA")]
    [SwaggerSchema("内容（日语）")]
    public string ContentJa { get; set; } = string.Empty;

    [Required]
    [Column("CONTENT_KO")]
    [SwaggerSchema("内容（韩语）")]
    public string ContentKo { get; set; } = string.Empty;

    [Required]
    [Column("CONTENT_PT")]
    [SwaggerSchema("内容（葡萄牙语）")]
    public string ContentPt { get; set; } = string.Empty;

    [Required]
    [Column("CONTENT_RU")]
    [SwaggerSchema("内容（俄语）")]
    public string ContentRu { get; set; } = string.Empty;

    // 关系定义
    public PetSubcategory? PetSubcategory { get; set; }
}