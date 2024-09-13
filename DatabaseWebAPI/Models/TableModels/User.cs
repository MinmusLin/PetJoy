/*
 * Project Name:  DatabaseWebAPI
 * File Name:     User.cs
 * File Function: User 模型类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-15
 * License:       Creative Commons Attribution 4.0 International License
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Models.TableModels;

[Table("USER")]
[SwaggerSchema(Description = "用户表")]
public sealed class User
{
    // 属性定义
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("USER_ID")]
    [SwaggerSchema("用户ID")]
    public int UserId { get; set; }

    [Required]
    [Column("USER_NAME")]
    [StringLength(64)]
    [SwaggerSchema("用户名")]
    public string UserName { get; set; } = string.Empty;

    [Required]
    [Column("PASSWORD")]
    [StringLength(64)]
    [SwaggerSchema("密码")]
    public string Password { get; set; } = string.Empty;

    [Required]
    [Column("TELEPHONE")]
    [StringLength(16)]
    [SwaggerSchema("手机号码")]
    public string Telephone { get; set; } = string.Empty;

    [Required]
    [Column("REGISTRATION_DATE")]
    [SwaggerSchema("注册日期")]
    public DateTime RegistrationDate { get; set; }

    [Required]
    [Column("LAST_LOGIN_TIME")]
    [SwaggerSchema("上次登录时间")]
    public DateTime LastLoginTime { get; set; }

    [Required]
    [Column("ROLE")]
    [SwaggerSchema("用户角色")]
    public int Role { get; set; }

    [Required]
    [Column("STATUS")]
    [SwaggerSchema("用户状态")]
    public int Status { get; set; }

    [Column("AVATAR_URL")]
    [StringLength(2048)]
    [SwaggerSchema("头像链接")]
    public string? AvatarUrl { get; set; }

    [Column("PROFILE")]
    [StringLength(512)]
    [SwaggerSchema("个人简介")]
    public string? Profile { get; set; }

    [Required]
    [Column("GENDER")]
    [SwaggerSchema("性别")]
    public int Gender { get; set; }

    [Required]
    [Column("BIRTHDATE")]
    [SwaggerSchema("出生日期")]
    public DateTime Birthdate { get; set; }

    [Required]
    [Column("EXPERIENCE_POINTS")]
    [SwaggerSchema("经验点数")]
    public int ExperiencePoints { get; set; }

    [Required]
    [Column("FOLLOWS_COUNT")]
    [SwaggerSchema("关注数")]
    public int FollowsCount { get; set; }

    [Required]
    [Column("FOLLOWED_COUNT")]
    [SwaggerSchema("被关注数")]
    public int FollowedCount { get; set; }

    [Required]
    [Column("FAVORITES_COUNT")]
    [SwaggerSchema("收藏数")]
    public int FavoritesCount { get; set; }

    [Required]
    [Column("FAVORITED_COUNT")]
    [SwaggerSchema("被收藏数")]
    public int FavoritedCount { get; set; }

    [Required]
    [Column("LIKES_COUNT")]
    [SwaggerSchema("点赞数")]
    public int LikesCount { get; set; }

    [Required]
    [Column("LIKED_COUNT")]
    [SwaggerSchema("被点赞数")]
    public int LikedCount { get; set; }

    [Required]
    [Column("MESSAGE_COUNT")]
    [SwaggerSchema("留言数")]
    public int MessageCount { get; set; }

    // 导航属性
    public ICollection<News> NewsEntity { get; set; } =
        new HashSet<News>();

    public ICollection<NewsComment> NewsCommentEntity { get; set; } =
        new HashSet<NewsComment>();

    public ICollection<NewsCommentDislike> NewsCommentDislikeEntity { get; set; } =
        new HashSet<NewsCommentDislike>();

    public ICollection<NewsCommentLike> NewsCommentLikeEntity { get; set; } =
        new HashSet<NewsCommentLike>();

    public ICollection<NewsCommentReport> NewsCommentReportEntityReporter { get; set; } =
        new HashSet<NewsCommentReport>();

    public ICollection<NewsCommentReport> NewsCommentReportEntityReportedUser { get; set; } =
        new HashSet<NewsCommentReport>();

    public ICollection<NewsDislike> NewsDislikeEntity { get; set; } =
        new HashSet<NewsDislike>();

    public ICollection<NewsFavorite> NewsFavoriteEntity { get; set; } =
        new HashSet<NewsFavorite>();

    public ICollection<NewsLike> NewsLikeEntity { get; set; } =
        new HashSet<NewsLike>();

    public ICollection<PetAdoption> PetAdoptionEntity { get; set; } =
        new HashSet<PetAdoption>();

    public ICollection<Post> PostEntity { get; set; } =
        new HashSet<Post>();

    public ICollection<PostComment> PostCommentEntity { get; set; } =
        new HashSet<PostComment>();

    public ICollection<PostCommentDislike> PostCommentDislikeEntity { get; set; } =
        new HashSet<PostCommentDislike>();

    public ICollection<PostCommentLike> PostCommentLikeEntity { get; set; } =
        new HashSet<PostCommentLike>();

    public ICollection<PostCommentReport> PostCommentReportEntityReporter { get; set; } =
        new HashSet<PostCommentReport>();

    public ICollection<PostCommentReport> PostCommentReportEntityReportedUser { get; set; } =
        new HashSet<PostCommentReport>();

    public ICollection<PostDislike> PostDislikeEntity { get; set; } =
        new HashSet<PostDislike>();

    public ICollection<PostFavorite> PostFavoriteEntity { get; set; } =
        new HashSet<PostFavorite>();

    public ICollection<PostLike> PostLikeEntity { get; set; } =
        new HashSet<PostLike>();

    public ICollection<PostReport> PostReportEntityReporter { get; set; } =
        new HashSet<PostReport>();

    public ICollection<PostReport> PostReportEntityReportedUser { get; set; } =
        new HashSet<PostReport>();

    public ICollection<UserCheckIn> UserCheckInEntity { get; set; } =
        new HashSet<UserCheckIn>();

    public ICollection<UserFollow> UserFollowEntityUser { get; set; } =
        new HashSet<UserFollow>();

    public ICollection<UserFollow> UserFollowEntityFollower { get; set; } =
        new HashSet<UserFollow>();

    public ICollection<UserMessage> UserMessageEntityUser { get; set; } =
        new HashSet<UserMessage>();

    public ICollection<UserMessage> UserMessageEntityCommenter { get; set; } =
        new HashSet<UserMessage>();

    public ICollection<UserSetting> UserSettingEntity { get; set; } =
        new HashSet<UserSetting>();
}