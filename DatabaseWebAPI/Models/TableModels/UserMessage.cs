/*
 * Project Name:  DatabaseWebAPI
 * File Name:     UserMessage.cs
 * File Function: UserMessage 模型类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-10
 * License:       Creative Commons Attribution 4.0 International License
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Models.TableModels;

[Table("USER_MESSAGE")]
[SwaggerSchema(Description = "用户留言表")]
public sealed class UserMessage
{
    // 属性定义
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("MESSAGE_ID")]
    [SwaggerSchema("留言ID")]
    public int MessageId { get; set; }

    [Required]
    [ForeignKey("User")]
    [Column("USER_ID")]
    [SwaggerSchema("用户ID")]
    public int UserId { get; set; }

    [Required]
    [ForeignKey("Commenter")]
    [Column("COMMENTER_ID")]
    [SwaggerSchema("留言者ID")]
    public int CommenterId { get; set; }

    [Required]
    [Column("MESSAGE")]
    [StringLength(512)]
    [SwaggerSchema("留言内容")]
    public string Message { get; set; } = string.Empty;

    [Required]
    [Column("COMMENT_TIME")]
    [SwaggerSchema("留言时间")]
    public DateTime CommentTime { get; set; }

    // 关系定义
    public User? User { get; set; }
    public User? Commenter { get; set; }
}