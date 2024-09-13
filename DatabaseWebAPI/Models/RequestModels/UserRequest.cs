/*
 * Project Name:  DatabaseWebAPI
 * File Name:     UserRequest.cs
 * File Function: 用户表请求类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-26
 * License:       Creative Commons Attribution 4.0 International License
 */

using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Models.RequestModels;

[SwaggerSchema(Description = "密码验证请求类")]
public class PasswordVerificationRequest
{
    [SwaggerSchema("用户ID")] public int UserId { get; set; }
    [SwaggerSchema("明文密码")] public string PlainPassword { get; set; } = string.Empty;
}

[SwaggerSchema(Description = "个人信息请求类")]
public class PersonalInformationRequest
{
    [SwaggerSchema("个人简介")] public string? Profile { get; set; }
    [SwaggerSchema("性别")] public int Gender { get; set; }
    [SwaggerSchema("出生日期")] public DateTime Birthdate { get; set; }
}

[SwaggerSchema(Description = "头像链接请求类")]
public class AvatarUrlRequest
{
    [SwaggerSchema("头像链接")] public string? AvatarUrl { get; set; }
}

[SwaggerSchema(Description = "上次登录时间请求类")]
public class LastLoginTimeRequest
{
    [SwaggerSchema("上次登录时间")] public DateTime LastLoginTime { get; set; }
}

[SwaggerSchema(Description = "明文密码请求类")]
public class PlainPasswordRequest
{
    [SwaggerSchema("明文密码")] public string PlainPassword { get; set; } = string.Empty;
}

[SwaggerSchema(Description = "手机号码请求类")]
public class TelephoneRequest
{
    [SwaggerSchema("手机号码")] public string Telephone { get; set; } = string.Empty;
}