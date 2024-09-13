/*
 * Project Name:  DatabaseWebAPI
 * File Name:     MessageController.cs
 * File Function: 短信验证码控制器
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-25
 * License:       Creative Commons Attribution 4.0 International License
 */

using Microsoft.AspNetCore.Mvc;
using AlibabaCloud.SDK.Dysmsapi20170525.Models;
using AlibabaCloud.TeaUtil.Models;
using AlibabaCloud.OpenApiClient.Models;
using DatabaseWebAPI.Models.RequestModels;
using Tea;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Controllers.MessageControllers;

[ApiController]
[Route("api")]
[SwaggerTag("短信验证码相关 API")]
public class MessageController : ControllerBase
{
    // ReSharper disable once InconsistentNaming
    private static AlibabaCloud.SDK.Dysmsapi20170525.Client CreateClient()
    {
        return new AlibabaCloud.SDK.Dysmsapi20170525.Client(new Config
        {
            AccessKeyId = "[TODO: AccessKeyId]",
            AccessKeySecret = "[TODO: AccessKeySecret]",
            Endpoint = "[TODO: Endpoint]"
        });
    }

    // 发送短信验证码（注册验证码）
    [HttpPost("registration-verification")]
    [SwaggerOperation(Summary = "发送短信验证码（注册验证码）", Description = "发送短信验证码（注册验证码）")]
    [SwaggerResponse(200, "短信验证码（注册验证码）发送成功")]
    [SwaggerResponse(400, "短信验证码（注册验证码）发送失败")]
    // ReSharper disable once InconsistentNaming
    public IActionResult SendRegistrationVerification([FromBody] SmsRequest smsRequest)
    {
        var client = CreateClient();
        var sendSmsRequest = new SendSmsRequest
        {
            TemplateCode = "[TODO: TemplateCode]",
            TemplateParam = $"{{\"code\":\"{smsRequest.VerificationCode}\"}}",
            PhoneNumbers = smsRequest.TelephoneNumber,
            SignName = "宠悦PetJoy"
        };
        try
        {
            client.SendSmsWithOptions(sendSmsRequest, new RuntimeOptions());
            return Ok("The registration verification code has been successfully sent.");
        }
        catch (TeaException error)
        {
            return BadRequest($"TeaException: {error.Message}");
        }
        catch (Exception exception)
        {
            return BadRequest($"Exception: {exception.Message}");
        }
    }

    // 发送短信验证码（登录验证码）
    [HttpPost("login-verification")]
    [SwaggerOperation(Summary = "发送短信验证码（登录验证码）", Description = "发送短信验证码（登录验证码）")]
    [SwaggerResponse(200, "短信验证码（登录验证码）发送成功")]
    [SwaggerResponse(400, "短信验证码（登录验证码）发送失败")]
    // ReSharper disable once InconsistentNaming
    public IActionResult SendLoginVerification([FromBody] SmsRequest smsRequest)
    {
        var client = CreateClient();
        var sendSmsRequest = new SendSmsRequest
        {
            TemplateCode = "[TODO: TemplateCode]",
            TemplateParam = $"{{\"code\":\"{smsRequest.VerificationCode}\"}}",
            PhoneNumbers = smsRequest.TelephoneNumber,
            SignName = "宠悦PetJoy"
        };
        try
        {
            client.SendSmsWithOptions(sendSmsRequest, new RuntimeOptions());
            return Ok("The login verification code has been successfully sent.");
        }
        catch (TeaException error)
        {
            return BadRequest($"TeaException: {error.Message}");
        }
        catch (Exception exception)
        {
            return BadRequest($"Exception: {exception.Message}");
        }
    }

    // 发送短信验证码（重置验证码）
    [HttpPost("reset-verification")]
    [SwaggerOperation(Summary = "发送短信验证码（重置验证码）", Description = "发送短信验证码（重置验证码）")]
    [SwaggerResponse(200, "短信验证码（重置验证码）发送成功")]
    [SwaggerResponse(400, "短信验证码（重置验证码）发送失败")]
    // ReSharper disable once InconsistentNaming
    public IActionResult SendResetVerification([FromBody] SmsRequest smsRequest)
    {
        var client = CreateClient();
        var sendSmsRequest = new SendSmsRequest
        {
            TemplateCode = "[TODO: TemplateCode]",
            TemplateParam = $"{{\"code\":\"{smsRequest.VerificationCode}\"}}",
            PhoneNumbers = smsRequest.TelephoneNumber,
            SignName = "宠悦PetJoy"
        };
        try
        {
            client.SendSmsWithOptions(sendSmsRequest, new RuntimeOptions());
            return Ok("The reset verification code has been successfully sent.");
        }
        catch (TeaException error)
        {
            return BadRequest($"TeaException: {error.Message}");
        }
        catch (Exception exception)
        {
            return BadRequest($"Exception: {exception.Message}");
        }
    }

    // 发送短信验证码（注销验证码）
    [HttpPost("delete-verification")]
    [SwaggerOperation(Summary = "发送短信验证码（注销验证码）", Description = "发送短信验证码（注销验证码）")]
    [SwaggerResponse(200, "短信验证码（注销验证码）发送成功")]
    [SwaggerResponse(400, "短信验证码（注销验证码）发送失败")]
    // ReSharper disable once InconsistentNaming
    public IActionResult SendDeleteVerification([FromBody] SmsRequest smsRequest)
    {
        var client = CreateClient();
        var sendSmsRequest = new SendSmsRequest
        {
            TemplateCode = "[TODO: TemplateCode]",
            TemplateParam = $"{{\"code\":\"{smsRequest.VerificationCode}\"}}",
            PhoneNumbers = smsRequest.TelephoneNumber,
            SignName = "宠悦PetJoy"
        };
        try
        {
            client.SendSmsWithOptions(sendSmsRequest, new RuntimeOptions());
            return Ok("The delete verification code has been successfully sent.");
        }
        catch (TeaException error)
        {
            return BadRequest($"TeaException: {error.Message}");
        }
        catch (Exception exception)
        {
            return BadRequest($"Exception: {exception.Message}");
        }
    }

    // 发送短信验证码（修改验证码）
    [HttpPost("change-verification")]
    [SwaggerOperation(Summary = "发送短信验证码（修改验证码）", Description = "发送短信验证码（修改验证码）")]
    [SwaggerResponse(200, "短信验证码（修改验证码）发送成功")]
    [SwaggerResponse(400, "短信验证码（修改验证码）发送失败")]
    // ReSharper disable once InconsistentNaming
    public IActionResult SendChangeVerification([FromBody] SmsRequest smsRequest)
    {
        var client = CreateClient();
        var sendSmsRequest = new SendSmsRequest
        {
            TemplateCode = "[TODO: TemplateCode]",
            TemplateParam = $"{{\"code\":\"{smsRequest.VerificationCode}\"}}",
            PhoneNumbers = smsRequest.TelephoneNumber,
            SignName = "宠悦PetJoy"
        };
        try
        {
            client.SendSmsWithOptions(sendSmsRequest, new RuntimeOptions());
            return Ok("The delete verification code has been successfully sent.");
        }
        catch (TeaException error)
        {
            return BadRequest($"TeaException: {error.Message}");
        }
        catch (Exception exception)
        {
            return BadRequest($"Exception: {exception.Message}");
        }
    }
}