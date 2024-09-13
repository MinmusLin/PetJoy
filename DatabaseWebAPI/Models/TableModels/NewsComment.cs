/*
 * Project Name:  DatabaseWebAPI
 * File Name:     NewsComment.cs
 * File Function: NewsComment 模型类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-30
 * License:       Creative Commons Attribution 4.0 International License
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Models.TableModels;

[Table("NEWS_COMMENT")]
[SwaggerSchema(Description = "新闻评论表")]
public sealed class NewsComment
{
    // 属性定义
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("COMMENT_ID")]
    [SwaggerSchema("新闻评论ID")]
    public int CommentId { get; set; }

    [Required]
    [ForeignKey("News")]
    [Column("NEWS_ID")]
    [SwaggerSchema("新闻ID")]
    public int NewsId { get; set; }

    [Required]
    [ForeignKey("User")]
    [Column("USER_ID")]
    [SwaggerSchema("用户ID")]
    public int UserId { get; set; }

    [ForeignKey("ParentComment")]
    [Column("PARENT_COMMENT_ID")]
    [SwaggerSchema("父评论ID")]
    public int? ParentCommentId { get; set; }

    [Required]
    [Column("CONTENT")]
    [StringLength(512)]
    [SwaggerSchema("评论内容")]
    public string Content { get; set; } = string.Empty;

    [Required]
    [Column("COMMENT_TIME")]
    [SwaggerSchema("评论时间")]
    public DateTime CommentTime { get; set; }

    [Required]
    [Column("LIKE_COUNT")]
    [SwaggerSchema("点赞数")]
    public int LikeCount { get; set; }

    [Required]
    [Column("DISLIKE_COUNT")]
    [SwaggerSchema("点踩数")]
    public int DislikeCount { get; set; }

    // 关系定义
    public News? News { get; set; }
    public User? User { get; set; }
    public NewsComment? ParentComment { get; set; }

    // 导航属性
    // public ICollection<NewsComment> NewsCommentEntity { get; set; } =
    //     new HashSet<NewsComment>();

    public ICollection<NewsCommentDislike> NewsCommentDislikeEntity { get; set; } =
        new HashSet<NewsCommentDislike>();

    public ICollection<NewsCommentLike> NewsCommentLikeEntity { get; set; } =
        new HashSet<NewsCommentLike>();

    public ICollection<NewsCommentReport> NewsCommentReportEntity { get; set; } =
        new HashSet<NewsCommentReport>();
}