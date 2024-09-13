/*
 * Project Name:  DatabaseWebAPI
 * File Name:     PetSubcategory.cs
 * File Function: PetSubcategory 模型类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-08-03
 * License:       Creative Commons Attribution 4.0 International License
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

// ReSharper disable EntityFramework.ModelValidation.UnlimitedStringLength

namespace DatabaseWebAPI.Models.TableModels;

[Table("PET_SUBCATEGORY")]
[SwaggerSchema(Description = "宠物子类表")]
public sealed class PetSubcategory
{
    // 属性定义
    [Key]
    [Column("SUBCATEGORY_ID")]
    [SwaggerSchema("宠物子类ID")]
    public int SubcategoryId { get; set; }

    [Required]
    [ForeignKey("PetCategory")]
    [Column("CATEGORY_ID")]
    [SwaggerSchema("宠物分类ID")]
    public int CategoryId { get; set; }

    [Required]
    [Column("SUBCATEGORY_NAME_ZH")]
    [StringLength(1024)]
    [SwaggerSchema("宠物子类名称（汉语）")]
    public string SubcategoryNameZh { get; set; } = string.Empty;

    [Required]
    [Column("SUBCATEGORY_NAME_DE")]
    [StringLength(1024)]
    [SwaggerSchema("宠物子类名称（德语）")]
    public string SubcategoryNameDe { get; set; } = string.Empty;

    [Required]
    [Column("SUBCATEGORY_NAME_EN")]
    [StringLength(1024)]
    [SwaggerSchema("宠物子类名称（英语）")]
    public string SubcategoryNameEn { get; set; } = string.Empty;

    [Required]
    [Column("SUBCATEGORY_NAME_ES")]
    [StringLength(1024)]
    [SwaggerSchema("宠物子类名称（西班牙语）")]
    public string SubcategoryNameEs { get; set; } = string.Empty;

    [Required]
    [Column("SUBCATEGORY_NAME_FR")]
    [StringLength(1024)]
    [SwaggerSchema("宠物子类名称（法语）")]
    public string SubcategoryNameFr { get; set; } = string.Empty;

    [Required]
    [Column("SUBCATEGORY_NAME_IT")]
    [StringLength(1024)]
    [SwaggerSchema("宠物子类名称（意大利语）")]
    public string SubcategoryNameIt { get; set; } = string.Empty;

    [Required]
    [Column("SUBCATEGORY_NAME_JA")]
    [StringLength(1024)]
    [SwaggerSchema("宠物子类名称（日语）")]
    public string SubcategoryNameJa { get; set; } = string.Empty;

    [Required]
    [Column("SUBCATEGORY_NAME_KO")]
    [StringLength(1024)]
    [SwaggerSchema("宠物子类名称（韩语）")]
    public string SubcategoryNameKo { get; set; } = string.Empty;

    [Required]
    [Column("SUBCATEGORY_NAME_PT")]
    [StringLength(1024)]
    [SwaggerSchema("宠物子类名称（葡萄牙语）")]
    public string SubcategoryNamePt { get; set; } = string.Empty;

    [Required]
    [Column("SUBCATEGORY_NAME_RU")]
    [StringLength(1024)]
    [SwaggerSchema("宠物子类名称（俄语）")]
    public string SubcategoryNameRu { get; set; } = string.Empty;

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

    [Required]
    [Column("ORIGIN_ZH")]
    [StringLength(512)]
    [SwaggerSchema("起源地（汉语）")]
    public string OriginZh { get; set; } = string.Empty;

    [Required]
    [Column("ORIGIN_DE")]
    [StringLength(512)]
    [SwaggerSchema("起源地（德语）")]
    public string OriginDe { get; set; } = string.Empty;

    [Required]
    [Column("ORIGIN_EN")]
    [StringLength(512)]
    [SwaggerSchema("起源地（英语）")]
    public string OriginEn { get; set; } = string.Empty;

    [Required]
    [Column("ORIGIN_ES")]
    [StringLength(512)]
    [SwaggerSchema("起源地（西班牙语）")]
    public string OriginEs { get; set; } = string.Empty;

    [Required]
    [Column("ORIGIN_FR")]
    [StringLength(512)]
    [SwaggerSchema("起源地（法语）")]
    public string OriginFr { get; set; } = string.Empty;

    [Required]
    [Column("ORIGIN_IT")]
    [StringLength(512)]
    [SwaggerSchema("起源地（意大利语）")]
    public string OriginIt { get; set; } = string.Empty;

    [Required]
    [Column("ORIGIN_JA")]
    [StringLength(512)]
    [SwaggerSchema("起源地（日语）")]
    public string OriginJa { get; set; } = string.Empty;

    [Required]
    [Column("ORIGIN_KO")]
    [StringLength(512)]
    [SwaggerSchema("起源地（韩语）")]
    public string OriginKo { get; set; } = string.Empty;

    [Required]
    [Column("ORIGIN_PT")]
    [StringLength(512)]
    [SwaggerSchema("起源地（葡萄牙语）")]
    public string OriginPt { get; set; } = string.Empty;

    [Required]
    [Column("ORIGIN_RU")]
    [StringLength(512)]
    [SwaggerSchema("起源地（俄语）")]
    public string OriginRu { get; set; } = string.Empty;

    [Required]
    [Column("SIZE_ZH")]
    [StringLength(512)]
    [SwaggerSchema("体型（汉语）")]
    public string SizeZh { get; set; } = string.Empty;

    [Required]
    [Column("SIZE_DE")]
    [StringLength(512)]
    [SwaggerSchema("体型（德语）")]
    public string SizeDe { get; set; } = string.Empty;

    [Required]
    [Column("SIZE_EN")]
    [StringLength(512)]
    [SwaggerSchema("体型（英语）")]
    public string SizeEn { get; set; } = string.Empty;

    [Required]
    [Column("SIZE_ES")]
    [StringLength(512)]
    [SwaggerSchema("体型（西班牙语）")]
    public string SizeEs { get; set; } = string.Empty;

    [Required]
    [Column("SIZE_FR")]
    [StringLength(512)]
    [SwaggerSchema("体型（法语）")]
    public string SizeFr { get; set; } = string.Empty;

    [Required]
    [Column("SIZE_IT")]
    [StringLength(512)]
    [SwaggerSchema("体型（意大利语）")]
    public string SizeIt { get; set; } = string.Empty;

    [Required]
    [Column("SIZE_JA")]
    [StringLength(512)]
    [SwaggerSchema("体型（日语）")]
    public string SizeJa { get; set; } = string.Empty;

    [Required]
    [Column("SIZE_KO")]
    [StringLength(512)]
    [SwaggerSchema("体型（韩语）")]
    public string SizeKo { get; set; } = string.Empty;

    [Required]
    [Column("SIZE_PT")]
    [StringLength(512)]
    [SwaggerSchema("体型（葡萄牙语）")]
    public string SizePt { get; set; } = string.Empty;

    [Required]
    [Column("SIZE_RU")]
    [StringLength(512)]
    [SwaggerSchema("体型（俄语）")]
    public string SizeRu { get; set; } = string.Empty;

    [Required]
    [Column("COAT_ZH")]
    [StringLength(512)]
    [SwaggerSchema("毛色（汉语）")]
    public string CoatZh { get; set; } = string.Empty;

    [Required]
    [Column("COAT_DE")]
    [StringLength(512)]
    [SwaggerSchema("毛色（德语）")]
    public string CoatDe { get; set; } = string.Empty;

    [Required]
    [Column("COAT_EN")]
    [StringLength(512)]
    [SwaggerSchema("毛色（英语）")]
    public string CoatEn { get; set; } = string.Empty;

    [Required]
    [Column("COAT_ES")]
    [StringLength(512)]
    [SwaggerSchema("毛色（西班牙语）")]
    public string CoatEs { get; set; } = string.Empty;

    [Required]
    [Column("COAT_FR")]
    [StringLength(512)]
    [SwaggerSchema("毛色（法语）")]
    public string CoatFr { get; set; } = string.Empty;

    [Required]
    [Column("COAT_IT")]
    [StringLength(512)]
    [SwaggerSchema("毛色（意大利语）")]
    public string CoatIt { get; set; } = string.Empty;

    [Required]
    [Column("COAT_JA")]
    [StringLength(512)]
    [SwaggerSchema("毛色（日语）")]
    public string CoatJa { get; set; } = string.Empty;

    [Required]
    [Column("COAT_KO")]
    [StringLength(512)]
    [SwaggerSchema("毛色（韩语）")]
    public string CoatKo { get; set; } = string.Empty;

    [Required]
    [Column("COAT_PT")]
    [StringLength(512)]
    [SwaggerSchema("毛色（葡萄牙语）")]
    public string CoatPt { get; set; } = string.Empty;

    [Required]
    [Column("COAT_RU")]
    [StringLength(512)]
    [SwaggerSchema("毛色（俄语）")]
    public string CoatRu { get; set; } = string.Empty;

    [Required]
    [Column("LIFESPAN_ZH")]
    [StringLength(512)]
    [SwaggerSchema("寿命（汉语）")]
    public string LifespanZh { get; set; } = string.Empty;

    [Required]
    [Column("LIFESPAN_DE")]
    [StringLength(512)]
    [SwaggerSchema("寿命（德语）")]
    public string LifespanDe { get; set; } = string.Empty;

    [Required]
    [Column("LIFESPAN_EN")]
    [StringLength(512)]
    [SwaggerSchema("寿命（英语）")]
    public string LifespanEn { get; set; } = string.Empty;

    [Required]
    [Column("LIFESPAN_ES")]
    [StringLength(512)]
    [SwaggerSchema("寿命（西班牙语）")]
    public string LifespanEs { get; set; } = string.Empty;

    [Required]
    [Column("LIFESPAN_FR")]
    [StringLength(512)]
    [SwaggerSchema("寿命（法语）")]
    public string LifespanFr { get; set; } = string.Empty;

    [Required]
    [Column("LIFESPAN_IT")]
    [StringLength(512)]
    [SwaggerSchema("寿命（意大利语）")]
    public string LifespanIt { get; set; } = string.Empty;

    [Required]
    [Column("LIFESPAN_JA")]
    [StringLength(512)]
    [SwaggerSchema("寿命（日语）")]
    public string LifespanJa { get; set; } = string.Empty;

    [Required]
    [Column("LIFESPAN_KO")]
    [StringLength(512)]
    [SwaggerSchema("寿命（韩语）")]
    public string LifespanKo { get; set; } = string.Empty;

    [Required]
    [Column("LIFESPAN_PT")]
    [StringLength(512)]
    [SwaggerSchema("寿命（葡萄牙语）")]
    public string LifespanPt { get; set; } = string.Empty;

    [Required]
    [Column("LIFESPAN_RU")]
    [StringLength(512)]
    [SwaggerSchema("寿命（俄语）")]
    public string LifespanRu { get; set; } = string.Empty;

    [Required]
    [Column("TEMPERAMENT_ZH")]
    [StringLength(512)]
    [SwaggerSchema("性情（汉语）")]
    public string TemperamentZh { get; set; } = string.Empty;

    [Required]
    [Column("TEMPERAMENT_DE")]
    [StringLength(512)]
    [SwaggerSchema("性情（德语）")]
    public string TemperamentDe { get; set; } = string.Empty;

    [Required]
    [Column("TEMPERAMENT_EN")]
    [StringLength(512)]
    [SwaggerSchema("性情（英语）")]
    public string TemperamentEn { get; set; } = string.Empty;

    [Required]
    [Column("TEMPERAMENT_ES")]
    [StringLength(512)]
    [SwaggerSchema("性情（西班牙语）")]
    public string TemperamentEs { get; set; } = string.Empty;

    [Required]
    [Column("TEMPERAMENT_FR")]
    [StringLength(512)]
    [SwaggerSchema("性情（法语）")]
    public string TemperamentFr { get; set; } = string.Empty;

    [Required]
    [Column("TEMPERAMENT_IT")]
    [StringLength(512)]
    [SwaggerSchema("性情（意大利语）")]
    public string TemperamentIt { get; set; } = string.Empty;

    [Required]
    [Column("TEMPERAMENT_JA")]
    [StringLength(512)]
    [SwaggerSchema("性情（日语）")]
    public string TemperamentJa { get; set; } = string.Empty;

    [Required]
    [Column("TEMPERAMENT_KO")]
    [StringLength(512)]
    [SwaggerSchema("性情（韩语）")]
    public string TemperamentKo { get; set; } = string.Empty;

    [Required]
    [Column("TEMPERAMENT_PT")]
    [StringLength(512)]
    [SwaggerSchema("性情（葡萄牙语）")]
    public string TemperamentPt { get; set; } = string.Empty;

    [Required]
    [Column("TEMPERAMENT_RU")]
    [StringLength(512)]
    [SwaggerSchema("性情（俄语）")]
    public string TemperamentRu { get; set; } = string.Empty;

    [Required]
    [Column("DIET_ZH")]
    [StringLength(512)]
    [SwaggerSchema("饮食习惯（汉语）")]
    public string DietZh { get; set; } = string.Empty;

    [Required]
    [Column("DIET_DE")]
    [StringLength(512)]
    [SwaggerSchema("饮食习惯（德语）")]
    public string DietDe { get; set; } = string.Empty;

    [Required]
    [Column("DIET_EN")]
    [StringLength(512)]
    [SwaggerSchema("饮食习惯（英语）")]
    public string DietEn { get; set; } = string.Empty;

    [Required]
    [Column("DIET_ES")]
    [StringLength(512)]
    [SwaggerSchema("饮食习惯（西班牙语）")]
    public string DietEs { get; set; } = string.Empty;

    [Required]
    [Column("DIET_FR")]
    [StringLength(512)]
    [SwaggerSchema("饮食习惯（法语）")]
    public string DietFr { get; set; } = string.Empty;

    [Required]
    [Column("DIET_IT")]
    [StringLength(512)]
    [SwaggerSchema("饮食习惯（意大利语）")]
    public string DietIt { get; set; } = string.Empty;

    [Required]
    [Column("DIET_JA")]
    [StringLength(512)]
    [SwaggerSchema("饮食习惯（日语）")]
    public string DietJa { get; set; } = string.Empty;

    [Required]
    [Column("DIET_KO")]
    [StringLength(512)]
    [SwaggerSchema("饮食习惯（韩语）")]
    public string DietKo { get; set; } = string.Empty;

    [Required]
    [Column("DIET_PT")]
    [StringLength(512)]
    [SwaggerSchema("饮食习惯（葡萄牙语）")]
    public string DietPt { get; set; } = string.Empty;

    [Required]
    [Column("DIET_RU")]
    [StringLength(512)]
    [SwaggerSchema("饮食习惯（俄语）")]
    public string DietRu { get; set; } = string.Empty;

    [Required]
    [Column("LATITUDE_AND_LONGITUDE")]
    [StringLength(512)]
    [SwaggerSchema("经纬度参数")]
    public string LatitudeAndLongitude { get; set; } = string.Empty;

    // 关系定义
    public PetCategory? PetCategory { get; set; }

    // 导航属性
    public ICollection<PetAdoption> PetAdoptionEntity { get; set; } =
        new HashSet<PetAdoption>();

    public ICollection<PetCareGuide> PetCareGuideEntity { get; set; } =
        new HashSet<PetCareGuide>();
}