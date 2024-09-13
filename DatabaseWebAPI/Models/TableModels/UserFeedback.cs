/*
 * Project Name:  DatabaseWebAPI
 * File Name:     UserFeedback.cs
 * File Function: UserFeedback 模型类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-10
 * License:       Creative Commons Attribution 4.0 International License
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Models.TableModels;

[Table("USER_FEEDBACK")]
[SwaggerSchema(Description = "用户反馈表")]
public sealed class UserFeedback
{
    // 属性定义
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("FEEDBACK_ID")]
    [SwaggerSchema("反馈意见ID")]
    public int FeedbackId { get; set; }

    [Required]
    [Column("FEEDBACK_CATEGORY")]
    [StringLength(32)]
    [SwaggerSchema("反馈类型")]
    public string FeedbackCategory { get; set; } = string.Empty;

    [Required]
    [Column("FEEDBACK_CONTENT")]
    [StringLength(2048)]
    [SwaggerSchema("反馈内容")]
    public string FeedbackContent { get; set; } = string.Empty;

    [Required]
    [Column("FEEDBACK_TIME")]
    [SwaggerSchema("反馈时间")]
    public DateTime FeedbackTime { get; set; }

    [Column("EMAIL")]
    [StringLength(2048)]
    [SwaggerSchema("电子邮箱")]
    public string? Email { get; set; }

    [Column("TELEPHONE")]
    [StringLength(16)]
    [SwaggerSchema("手机号码")]
    public string? Telephone { get; set; }
}