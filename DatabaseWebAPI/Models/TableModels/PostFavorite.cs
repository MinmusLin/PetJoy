/*
 * Project Name:  DatabaseWebAPI
 * File Name:     PostFavorite.cs
 * File Function: PostFavorite 模型类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-05
 * License:       Creative Commons Attribution 4.0 International License
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Models.TableModels;

[Table("POST_FAVORITE")]
[SwaggerSchema(Description = "帖子收藏表")]
[PrimaryKey(nameof(PostId), nameof(UserId))]
public sealed class PostFavorite
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
    [Column("FAVORITE_TIME")]
    [SwaggerSchema("收藏时间")]
    public DateTime FavoriteTime { get; set; }

    // 关系定义
    public Post? Post { get; set; }
    public User? User { get; set; }
}