/*
 * Project Name:  DatabaseWebAPI
 * File Name:     PostCommentDislike.cs
 * File Function: PostCommentDislike 模型类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-05
 * License:       Creative Commons Attribution 4.0 International License
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Models.TableModels;

[Table("POST_COMMENT_DISLIKE")]
[SwaggerSchema(Description = "帖子评论点踩表")]
[PrimaryKey(nameof(CommentId), nameof(UserId))]
public sealed class PostCommentDislike
{
    // 属性定义
    [Column("COMMENT_ID")]
    [ForeignKey("PostComment")]
    [SwaggerSchema("帖子评论ID")]
    public int CommentId { get; set; }

    [Column("USER_ID")]
    [ForeignKey("User")]
    [SwaggerSchema("用户ID")]
    public int UserId { get; set; }

    [Required]
    [Column("DISLIKE_TIME")]
    [SwaggerSchema("点踩时间")]
    public DateTime DislikeTime { get; set; }

    // 关系定义
    public PostComment? PostComment { get; set; }
    public User? User { get; set; }
}