/*
 * Project Name:  DatabaseWebAPI
 * File Name:     News.cs
 * File Function: News 模型类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-25
 * License:       Creative Commons Attribution 4.0 International License
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Models.TableModels;

[Table("NEWS")]
[SwaggerSchema(Description = "新闻表")]
public sealed class News
{
    // 属性定义
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("NEWS_ID")]
    [SwaggerSchema("新闻ID")]
    public int NewsId { get; set; }

    [Required]
    [ForeignKey("User")]
    [Column("USER_ID")]
    [SwaggerSchema("管理员ID")]
    public int UserId { get; set; }

    [Required]
    [ForeignKey("NewsTag")]
    [Column("TAG_ID")]
    [SwaggerSchema("新闻标签ID")]
    public int TagId { get; set; }

    [Required]
    [Column("TITLE")]
    [StringLength(256)]
    [SwaggerSchema("标题")]
    public string Title { get; set; } = string.Empty;

    [Required]
    [Column("SUMMARY")]
    [StringLength(512)]
    [SwaggerSchema("新闻摘要")]
    public string Summary { get; set; } = string.Empty;

    [Required]
    [Column("CONTENT")]
    [SwaggerSchema("内容")]
    // ReSharper disable once EntityFramework.ModelValidation.UnlimitedStringLength
    public string Content { get; set; } = string.Empty;

    [Required]
    [Column("CREATION_DATE")]
    [SwaggerSchema("创建时间")]
    public DateTime CreationDate { get; set; }

    [Required]
    [Column("UPDATE_DATE")]
    [SwaggerSchema("更新时间")]
    public DateTime UpdateDate { get; set; }

    [Required]
    [Column("COVER_URL")]
    [StringLength(2048)]
    [SwaggerSchema("封面图片链接")]
    public string CoverUrl { get; set; } = string.Empty;

    [Required]
    [Column("IS_STICKY")]
    [SwaggerSchema("是否置顶")]
    public int IsSticky { get; set; }

    [Required]
    [Column("LIKE_COUNT")]
    [SwaggerSchema("点赞数")]
    public int LikeCount { get; set; }

    [Required]
    [Column("DISLIKE_COUNT")]
    [SwaggerSchema("点踩数")]
    public int DislikeCount { get; set; }

    [Required]
    [Column("FAVORITE_COUNT")]
    [SwaggerSchema("收藏数")]
    public int FavoriteCount { get; set; }

    [Required]
    [Column("COMMENT_COUNT")]
    [SwaggerSchema("评论数")]
    public int CommentCount { get; set; }

    // 关系定义
    public User? User { get; set; }
    public NewsTag? NewsTag { get; set; }

    // 导航属性
    public ICollection<NewsComment> NewsCommentEntity { get; set; } =
        new HashSet<NewsComment>();

    public ICollection<NewsCommentReport> NewsCommentReportEntity { get; set; } =
        new HashSet<NewsCommentReport>();

    public ICollection<NewsDislike> NewsDislikeEntity { get; set; } =
        new HashSet<NewsDislike>();

    public ICollection<NewsFavorite> NewsFavoriteEntity { get; set; } =
        new HashSet<NewsFavorite>();

    public ICollection<NewsLike> NewsLikeEntity { get; set; } =
        new HashSet<NewsLike>();
}