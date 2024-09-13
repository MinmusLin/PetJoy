/*
 * Project Name:  DatabaseWebAPI
 * File Name:     UserFollow.cs
 * File Function: UserFollow 模型类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-05
 * License:       Creative Commons Attribution 4.0 International License
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Models.TableModels;

[Table("USER_FOLLOW")]
[SwaggerSchema(Description = "用户关注表")]
[PrimaryKey(nameof(UserId), nameof(FollowerId))]
public sealed class UserFollow
{
    // 属性定义
    [Column("USER_ID")]
    [ForeignKey("User")]
    [SwaggerSchema("被关注者ID")]
    public int UserId { get; set; }

    [Column("FOLLOWER_ID")]
    [ForeignKey("Follower")]
    [SwaggerSchema("关注者ID")]
    public int FollowerId { get; set; }

    [Required]
    [Column("FOLLOW_TIME")]
    [SwaggerSchema("关注时间")]
    public DateTime FollowTime { get; set; }

    // 关系定义
    public User? User { get; set; }
    public User? Follower { get; set; }
}