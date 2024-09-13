/*
 * Project Name:  DatabaseWebAPI
 * File Name:     PostCommentLike.cs
 * File Function: PostCommentLike 模型类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-05
 * License:       Creative Commons Attribution 4.0 International License
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Models.TableModels;

[Table("POST_COMMENT_LIKE")]
[SwaggerSchema(Description = "帖子评论点赞表")]
[PrimaryKey(nameof(CommentId), nameof(UserId))]
public sealed class PostCommentLike
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
    [Column("LIKE_TIME")]
    [SwaggerSchema("点赞时间")]
    public DateTime LikeTime { get; set; }

    // 关系属性
    public PostComment? PostComment { get; set; }
    public User? User { get; set; }
}