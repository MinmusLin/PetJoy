/*
 * Project Name:  DatabaseWebAPI
 * File Name:     AuthController.cs
 * File Function: 登陆鉴权控制器
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-29
 * License:       Creative Commons Attribution 4.0 International License
 */

using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using DatabaseWebAPI.Data;
using DatabaseWebAPI.Models.RequestModels;
using DatabaseWebAPI.Utils;

namespace DatabaseWebAPI.Controllers.AuthControllers;

[ApiController]
[Route("api")]
[SwaggerTag("登陆鉴权相关 API")]
public class AuthController(OracleDbContext context) : ControllerBase
{
    // 获取 Jwt Token
    [HttpPost("get-jwt-token")]
    [SwaggerOperation(Summary = "获取 Jwt Token", Description = "获取 Jwt Token")]
    [SwaggerResponse(200, "登陆鉴权成功")]
    [SwaggerResponse(401, "登陆鉴权失败")]
    public async Task<IActionResult> GetJwtToken([FromBody] PasswordVerificationRequest passwordVerificationRequest)
    {
        if (passwordVerificationRequest.UserId == 0 || string.IsNullOrEmpty(passwordVerificationRequest.PlainPassword))
        {
            return BadRequest(ModelState);
        }

        var user = await context.UserSet.FindAsync(passwordVerificationRequest.UserId);
        if (user == null)
        {
            return Unauthorized();
        }

        var hashedPassword = PasswordUtils.PlainPasswordToHashedPassword(passwordVerificationRequest.PlainPassword);
        if (hashedPassword != user.Password)
        {
            return Unauthorized();
        }

        var token = JwtTokenUtils.GenerateJwtToken(user);
        return Ok(new { token });
    }
}