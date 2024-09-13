/*
 * Project Name:  DatabaseWebAPI
 * File Name:     PetAdoption.cs
 * File Function: PetAdoption 模型类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-10
 * License:       Creative Commons Attribution 4.0 International License
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Models.TableModels;

[Table("PET_ADOPTION")]
[SwaggerSchema(Description = "宠物领养表")]
public sealed class PetAdoption
{
    // 属性定义
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ADOPTION_ID")]
    [SwaggerSchema("宠物领养ID")]
    public int AdoptionId { get; set; }

    [Required]
    [ForeignKey("User")]
    [Column("USER_ID")]
    [SwaggerSchema("用户ID")]
    public int UserId { get; set; }

    [Required]
    [ForeignKey("PetCategory")]
    [Column("CATEGORY_ID")]
    [SwaggerSchema("宠物分类ID")]
    public int CategoryId { get; set; }

    [Required]
    [ForeignKey("PetSubcategory")]
    [Column("SUBCATEGORY_ID")]
    [SwaggerSchema("宠物子类ID")]
    public int SubcategoryId { get; set; }

    [Column("NAME")]
    [StringLength(64)]
    [SwaggerSchema("宠物名称")]
    public string? Name { get; set; }

    [Required]
    [Column("IMAGE_URL")]
    [StringLength(2048)]
    [SwaggerSchema("图片链接")]
    public string ImageUrl { get; set; } = string.Empty;

    [Required]
    [Column("AGE")]
    [SwaggerSchema("宠物年龄")]
    public int Age { get; set; }

    [Required]
    [Column("LOCATION")]
    [StringLength(1024)]
    [SwaggerSchema("地址")]
    public string Location { get; set; } = string.Empty;

    [Required]
    [Column("REASON")]
    [StringLength(1024)]
    [SwaggerSchema("转让原因")]
    public string Reason { get; set; } = string.Empty;

    [Required]
    [Column("HEALTH")]
    [StringLength(1024)]
    [SwaggerSchema("健康情况")]
    public string Health { get; set; } = string.Empty;

    [Required]
    [Column("LATEST_HEALTH_CHECK")]
    [SwaggerSchema("最近一次健康检查日期")]
    public DateTime LatestHealthCheck { get; set; }

    [Required]
    [Column("VACCINATION")]
    [StringLength(1024)]
    [SwaggerSchema("疫苗接种情况")]
    public string Vaccination { get; set; } = string.Empty;

    [Column("CARE_NEEDS")]
    [StringLength(1024)]
    [SwaggerSchema("特殊护理需求")]
    public string? CareNeeds { get; set; }

    [Column("DIETARY_NEEDS")]
    [StringLength(1024)]
    [SwaggerSchema("特殊饮食需求")]
    public string? DietaryNeeds { get; set; }

    [Column("BEHAVIOR")]
    [StringLength(1024)]
    [SwaggerSchema("性格行为特征")]
    public string? Behavior { get; set; }

    [Required]
    [Column("NEUTERED_OR_SPAYED")]
    [SwaggerSchema("是否已绝育")]
    public int NeuteredOrSpayed { get; set; }

    [Column("NOTES")]
    [StringLength(1024)]
    [SwaggerSchema("备注")]
    public string? Notes { get; set; }

    [Required]
    [Column("STATUS")]
    [SwaggerSchema("领养状态")]
    public int Status { get; set; }

    [Required]
    [Column("GENDER")]
    [SwaggerSchema("性别")]
    public int Gender { get; set; }

    [Column("APPENDIX_URL")]
    [StringLength(2048)]
    [SwaggerSchema("附件链接")]
    public string? AppendixUrl { get; set; }

    // 关系定义
    public User? User { get; set; }
    public PetCategory? PetCategory { get; set; }
    public PetSubcategory? PetSubcategory { get; set; }
}