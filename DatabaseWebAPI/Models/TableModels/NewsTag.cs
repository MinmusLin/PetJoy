/*
 * Project Name:  DatabaseWebAPI
 * File Name:     NewsTag.cs
 * File Function: NewsTag 模型类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-10
 * License:       Creative Commons Attribution 4.0 International License
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Models.TableModels;

[Table("NEWS_TAG")]
[SwaggerSchema(Description = "新闻标签表")]
public sealed class NewsTag
{
    // 属性定义
    [Key]
    [Column("TAG_ID")]
    [SwaggerSchema("新闻标签ID")]
    public int TagId { get; set; }

    [Required]
    [Column("TAG")]
    [StringLength(64)]
    [SwaggerSchema("新闻标签")]
    public string Tag { get; set; } = string.Empty;

    // 导航属性
    public ICollection<News> NewsEntity { get; set; } = new HashSet<News>();
}