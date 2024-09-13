/*
 * Project Name:  DatabaseWebAPI
 * File Name:     UserSetting.cs
 * File Function: UserSetting 模型类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-15
 * License:       Creative Commons Attribution 4.0 International License
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Models.TableModels;

[Table("USER_SETTING")]
[SwaggerSchema(Description = "用户设置表")]
public sealed class UserSetting
{
    // 属性定义
    [Key]
    [ForeignKey("User")]
    [Column("USER_ID")]
    [SwaggerSchema("用户ID")]
    public int UserId { get; set; }

    [Required]
    [Column("IS_TELEPHONE_PUBLIC")]
    [SwaggerSchema("是否公开手机号码")]
    public int IsTelephonePublic { get; set; }

    [Required]
    [Column("IS_REGISTRATION_DATE_PUBLIC")]
    [SwaggerSchema("是否公开注册日期")]
    public int IsRegistrationDatePublic { get; set; }

    [Required]
    [Column("IS_PROFILE_PUBLIC")]
    [SwaggerSchema("是否公开个人简介")]
    public int IsProfilePublic { get; set; }

    [Required]
    [Column("IS_GENDER_PUBLIC")]
    [SwaggerSchema("是否公开性别")]
    public int IsGenderPublic { get; set; }

    [Required]
    [Column("IS_BIRTHDATE_PUBLIC")]
    [SwaggerSchema("是否公开出生日期")]
    public int IsBirthdatePublic { get; set; }

    [Required]
    [Column("IS_LEVEL_PUBLIC")]
    [SwaggerSchema("是否公开等级")]
    public int IsLevelPublic { get; set; }

    [Required]
    [Column("IS_FOLLOWING_COUNT_PUBLIC")]
    [SwaggerSchema("是否公开关注数")]
    public int IsFollowingCountPublic { get; set; }

    [Required]
    [Column("IS_FOLLOWERS_COUNT_PUBLIC")]
    [SwaggerSchema("是否公开被关注数")]
    public int IsFollowersCountPublic { get; set; }

    [Required]
    [Column("IS_FAVORITES_COUNT_PUBLIC")]
    [SwaggerSchema("是否公开收藏数")]
    public int IsFavoritesCountPublic { get; set; }

    [Required]
    [Column("IS_FAVORED_COUNT_PUBLIC")]
    [SwaggerSchema("是否公开被收藏数")]
    public int IsFavoredCountPublic { get; set; }

    [Required]
    [Column("IS_LIKES_COUNT_PUBLIC")]
    [SwaggerSchema("是否公开点赞数")]
    public int IsLikesCountPublic { get; set; }

    [Required]
    [Column("IS_LIKED_COUNT_PUBLIC")]
    [SwaggerSchema("是否公开被点赞数")]
    public int IsLikedCountPublic { get; set; }

    [Required]
    [Column("IS_MESSAGE_COUNT_PUBLIC")]
    [SwaggerSchema("是否公开留言数")]
    public int IsMessageCountPublic { get; set; }

    [Required]
    [Column("ALLOW_FOLLOWING")]
    [SwaggerSchema("是否允许他人关注")]
    public int AllowFollowing { get; set; }

    [Required]
    [Column("RECEIVE_ADMIN_NOTIFICATIONS")]
    [SwaggerSchema("是否接受管理员通知")]
    public int ReceiveAdminNotifications { get; set; }

    [Required]
    [Column("RECEIVE_USER_NOTIFICATIONS")]
    [SwaggerSchema("是否接受用户通知")]
    public int ReceiveUserNotifications { get; set; }

    // 关系定义
    public User? User { get; set; }
}