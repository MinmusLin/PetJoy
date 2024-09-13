/*
 * Project Name:  DatabaseWebAPI
 * File Name:     NewsCommentReport.cs
 * File Function: NewsCommentReport 模型类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-10
 * License:       Creative Commons Attribution 4.0 International License
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Models.TableModels;

[Table("NEWS_COMMENT_REPORT")]
[SwaggerSchema(Description = "新闻评论举报表")]
public sealed class NewsCommentReport
{
    // 属性定义
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("NEWS_COMMENT_REPORT_ID")]
    [SwaggerSchema("新闻评论举报ID")]
    public int NewsCommentReportId { get; set; }

    [Required]
    [ForeignKey("Reporter")]
    [Column("REPORTER_ID")]
    [SwaggerSchema("举报者ID")]
    public int ReporterId { get; set; }

    [Required]
    [ForeignKey("ReportedUser")]
    [Column("REPORTED_USER_ID")]
    [SwaggerSchema("被举报者ID")]
    public int ReportedUserId { get; set; }

    [Required]
    [ForeignKey("ReportedNews")]
    [Column("REPORTED_NEWS_ID")]
    [SwaggerSchema("被举报评论所属新闻ID")]
    public int ReportedNewsId { get; set; }

    [Required]
    [ForeignKey("ReportedComment")]
    [Column("REPORTED_COMMENT_ID")]
    [SwaggerSchema("被举报评论ID")]
    public int ReportedCommentId { get; set; }

    [Required]
    [Column("REPORT_REASON")]
    [StringLength(512)]
    [SwaggerSchema("举报原因")]
    public string ReportReason { get; set; } = string.Empty;

    [Required]
    [Column("REPORT_TIME")]
    [SwaggerSchema("举报时间")]
    public DateTime ReportTime { get; set; }

    [Required]
    [Column("STATUS")]
    [SwaggerSchema("处理状态")]
    public int Status { get; set; }

    // 关系定义
    public User? Reporter { get; set; }
    public User? ReportedUser { get; set; }
    public News? ReportedNews { get; set; }
    public NewsComment? ReportedComment { get; set; }
}