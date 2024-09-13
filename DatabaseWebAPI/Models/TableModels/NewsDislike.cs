/*
 * Project Name:  DatabaseWebAPI
 * File Name:     NewsDislike.cs
 * File Function: NewsDislike 模型类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-05
 * License:       Creative Commons Attribution 4.0 International License
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Models.TableModels;

[Table("NEWS_DISLIKE")]
[SwaggerSchema(Description = "新闻点踩表")]
[PrimaryKey(nameof(NewsId), nameof(UserId))]
public sealed class NewsDislike
{
    // 属性定义
    [Column("NEWS_ID")]
    [ForeignKey("News")]
    [SwaggerSchema("新闻ID")]
    public int NewsId { get; set; }

    [Column("USER_ID")]
    [ForeignKey("User")]
    [SwaggerSchema("用户ID")]
    public int UserId { get; set; }

    [Required]
    [Column("DISLIKE_TIME")]
    [SwaggerSchema("点踩时间")]
    public DateTime DislikeTime { get; set; }

    // 关系定义
    public News? News { get; set; }
    public User? User { get; set; }
}