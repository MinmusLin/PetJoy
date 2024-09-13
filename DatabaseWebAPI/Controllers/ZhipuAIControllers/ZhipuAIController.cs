/*
 * Project Name:  DatabaseWebAPI
 * File Name:     ZhipuAIController.cs
 * File Function: 智谱清言 AI 控制器
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-07-31
 * License:       Creative Commons Attribution 4.0 International License
 */

using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ZhipuApi;
using ZhipuApi.Models.RequestModels;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Controllers.ZhipuAIControllers;

[ApiController]
[Route("api")]
[SwaggerTag("智谱清言 AI 相关 API")]
// ReSharper disable once InconsistentNaming
public class ZhipuAIController : ControllerBase
{
    private readonly ClientV4 _clientV4 = new(Config["ZhipuAI:ZhipuAPI"]);

    private static readonly IConfiguration Config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("config.json")
        .Build();

    // 智谱清言 AI 宠物助理
    [HttpPost("zhipu-ai-pet-assistant")]
    [SwaggerOperation(Summary = "智谱清言 AI 宠物助理", Description = "智谱清言 AI 宠物助理")]
    [SwaggerResponse(200, "请求成功")]
    // ReSharper disable once InconsistentNaming
    public IActionResult ZhipuAIPetAssistant([FromBody] List<MessageItem> messages)
    {
        var response = _clientV4.chat.Completion(
            new TextRequestBase()
                .SetModel("glm-4")
                .SetMessages(messages.ToArray())
                .SetTemperature(0.7)
                .SetTopP(0.7)
        );
        var jsonResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        return Ok(jsonResponse);
    }
}