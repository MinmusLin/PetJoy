/*
 * Project Name:  DatabaseWebAPI
 * File Name:     PostLike.cs
 * File Function: PostLike 模型类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-05
 * License:       Creative Commons Attribution 4.0 International License
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Models.TableModels;

[Table("POST_LIKE")]
[SwaggerSchema(Description = "帖子点赞表")]
[PrimaryKey(nameof(PostId), nameof(UserId))]
public sealed class PostLike
{
    // 属性定义
    [Column("POST_ID")]
    [ForeignKey("Post")]
    [SwaggerSchema("帖子ID")]
    public int PostId { get; set; }

    [Column("USER_ID")]
    [ForeignKey("User")]
    [SwaggerSchema("用户ID")]
    public int UserId { get; set; }

    [Required]
    [Column("LIKE_TIME")]
    [SwaggerSchema("点赞时间")]
    public DateTime LikeTime { get; set; }

    // 关系定义
    public Post? Post { get; set; }
    public User? User { get; set; }
}