/*
 * Project Name:  DatabaseWebAPI
 * File Name:     UserCheckIn.cs
 * File Function: UserCheckIn 模型类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-05
 * License:       Creative Commons Attribution 4.0 International License
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Models.TableModels;

[Table("USER_CHECK_IN")]
[SwaggerSchema(Description = "用户打卡表")]
public sealed class UserCheckIn
{
    // 属性定义
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("CHECK_IN_ID")]
    [SwaggerSchema("打卡记录ID")]
    public int CheckInId { get; set; }

    [Required]
    [ForeignKey("User")]
    [Column("USER_ID")]
    [SwaggerSchema("用户ID")]
    public int UserId { get; set; }

    [Required]
    [Column("CHECK_IN_TIME")]
    [SwaggerSchema("打卡时间")]
    public DateTime CheckInTime { get; set; }

    // 关系定义
    public User? User { get; set; }
}