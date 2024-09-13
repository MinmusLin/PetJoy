/*
 * Project Name:  DatabaseWebAPI
 * File Name:     SmsRequest.cs
 * File Function: 短信验证码请求类
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-25
 * License:       Creative Commons Attribution 4.0 International License
 */

using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Models.RequestModels;

[SwaggerSchema(Description = "短信验证码请求类")]
public class SmsRequest
{
    [SwaggerSchema("电话号码")] public string TelephoneNumber { get; set; } = string.Empty;
    [SwaggerSchema("短信验证码")] public string VerificationCode { get; set; } = string.Empty;
}