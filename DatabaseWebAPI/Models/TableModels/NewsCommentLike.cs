/*
 * Project Name:  DatabaseWebAPI
 * File Name:     NewsCommentLike.cs
 * File Function: NewsCommentLike 模型类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-05
 * License:       Creative Commons Attribution 4.0 International License
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Models.TableModels;

[Table("NEWS_COMMENT_LIKE")]
[SwaggerSchema(Description = "新闻评论点赞表")]
[PrimaryKey(nameof(CommentId), nameof(UserId))]
public sealed class NewsCommentLike
{
    // 属性定义
    [Column("COMMENT_ID")]
    [ForeignKey("NewsComment")][SwaggerSchema("新闻评论ID")]
    public int CommentId { get; set; }

    [Column("USER_ID")]
    [ForeignKey("User")][SwaggerSchema("用户ID")]
    public int UserId { get; set; }

    [Required] [Column("LIKE_TIME")][SwaggerSchema("点赞时间")] public DateTime LikeTime { get; set; }

    // 关系定义
    public NewsComment? NewsComment { get; set; }
    public User? User { get; set; }
}