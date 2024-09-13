/*
 * Project Name:  DatabaseWebAPI
 * File Name:     DevelopmentTeam.cs
 * File Function: DevelopmentTeam 模型类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-10
 * License:       Creative Commons Attribution 4.0 International License
 */

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Models.TableModels;

[Table("DEVELOPMENT_TEAM")]
[SwaggerSchema(Description = "开发团队表")]
public sealed class DevelopmentTeam
{
    // 属性定义
    [Key]
    [Column("ID")]
    [SwaggerSchema("学号")]
    public int Id { get; set; }

    [Required]
    [Column("NAME")]
    [StringLength(64)]
    [SwaggerSchema("姓名")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Column("SCHOOL")]
    [StringLength(64)]
    [SwaggerSchema("学校")]
    public string School { get; set; } = string.Empty;

    [Required]
    [Column("EMAIL")]
    [StringLength(2048)]
    [SwaggerSchema("电子邮箱")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Column("GITHUB_NAME")]
    [StringLength(64)]
    [SwaggerSchema("GitHub名称")]
    public string GithubName { get; set; } = string.Empty;

    [Required]
    [Column("GITHUB_PROFILE")]
    [StringLength(2048)]
    [SwaggerSchema("GitHub主页")]
    public string GithubProfile { get; set; } = string.Empty;
}