/*
 * Project Name:  DatabaseWebAPI
 * File Name:     Post.cs
 * File Function: Post 模型类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-10
 * License:       Creative Commons Attribution 4.0 International License
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Models.TableModels;

[Table("POST")]
[SwaggerSchema(Description = "帖子表")]
public sealed class Post
{
    // 属性定义
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("POST_ID")]
    [SwaggerSchema("帖子ID")]
    public int PostId { get; set; }

    [Required]
    [ForeignKey("User")]
    [Column("USER_ID")]
    [SwaggerSchema("发帖用户ID")]
    public int UserId { get; set; }

    [Required]
    [ForeignKey("PostCategory")]
    [Column("CATEGORY_ID")]
    [SwaggerSchema("帖子分类ID")]
    public int CategoryId { get; set; }

    [Required]
    [Column("TITLE")]
    [StringLength(256)]
    [SwaggerSchema("标题")]
    public string Title { get; set; } = string.Empty;

    [Required]
    [Column("CONTENT")]
    [StringLength(2048)]
    [SwaggerSchema("内容")]
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

    [Column("IMAGE_URL")]
    [StringLength(2048)]
    [SwaggerSchema("图片链接")]
    public string? ImageUrl { get; set; }

    // 关系定义
    public User? User { get; set; }
    public PostCategory? PostCategory { get; set; }

    // 导航属性
    public ICollection<PostComment> PostCommentEntity { get; set; } =
        new HashSet<PostComment>();

    public ICollection<PostCommentReport> PostCommentReportEntity { get; set; } =
        new HashSet<PostCommentReport>();

    public ICollection<PostDislike> PostDislikeEntity { get; set; } =
        new HashSet<PostDislike>();

    public ICollection<PostFavorite> PostFavoriteEntity { get; set; } =
        new HashSet<PostFavorite>();

    public ICollection<PostLike> PostLikeEntity { get; set; } =
        new HashSet<PostLike>();

    public ICollection<PostReport> PostReportEntity { get; set; } =
        new HashSet<PostReport>();
}