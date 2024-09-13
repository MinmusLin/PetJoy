/*
 * Project Name:  DatabaseWebAPI
 * File Name:     OSSController.cs
 * File Function: 对象存储 OSS 控制器
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-08-05
 * License:       Creative Commons Attribution 4.0 International License
 */

using Aliyun.OSS;
using Aliyun.OSS.Common;
using DatabaseWebAPI.Utils;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DatabaseWebAPI.Controllers.OSSControllers;

[ApiController]
[Route("api")]
[SwaggerTag("对象存储 OSS 相关 API")]
// ReSharper disable once InconsistentNaming
public class OSSController : ControllerBase
{
    private static readonly IConfiguration Config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("config.json")
        .Build();

    private static readonly OssClient Client = new(Config["OSSConfig:Endpoint"],
        Config["OSSConfig:AccessKeyId"],
        Config["OSSConfig:AccessKeySecret"]);

    // 上传头像
    [HttpPost("upload-avatar")]
    [SwaggerOperation(Summary = "上传头像（.jpg 文件）", Description = "上传头像（.jpg 文件）")]
    [SwaggerResponse(200, "上传头像成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public IActionResult UploadAvatar(IFormFile file)
    {
        if (file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        var key = $"Avatars/{FileNameUtils.GenerateRandomFileName(64)}.jpg";
        try
        {
            var putObjectResult =
                Client.PutObject(Config["OSSConfig:BucketName"], $"PetJoy/{key}", file.OpenReadStream());
            return Ok(new
            {
                message = "Avatar uploaded successfully.",
                fileName = key,
                requestId = putObjectResult.RequestId
            });
        }
        catch (OssException ex)
        {
            return StatusCode(500, $"OSS update error: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 上传新闻封面图片
    [HttpPost("upload-news-cover-image")]
    [SwaggerOperation(Summary = "上传新闻封面图片（.jpg 文件）", Description = "上传新闻封面图片（.jpg 文件）")]
    [SwaggerResponse(200, "上传新闻封面图片成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public IActionResult UploadNewsCoverImage(IFormFile file)
    {
        if (file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        var key = $"NewsCoverImages/{FileNameUtils.GenerateRandomFileName(64)}.jpg";
        try
        {
            var putObjectResult =
                Client.PutObject(Config["OSSConfig:BucketName"], $"PetJoy/{key}", file.OpenReadStream());
            return Ok(new
            {
                message = "News cover image uploaded successfully.",
                fileName = key,
                requestId = putObjectResult.RequestId
            });
        }
        catch (OssException ex)
        {
            return StatusCode(500, $"OSS update error: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 上传新闻内容图片
    [HttpPost("upload-news-content-image")]
    [SwaggerOperation(Summary = "上传新闻内容图片（.jpg 文件）", Description = "上传新闻内容图片（.jpg 文件）")]
    [SwaggerResponse(200, "上传新闻内容图片成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public IActionResult UploadNewsContentImage(IFormFile file)
    {
        if (file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        var key = $"NewsContentImages/{FileNameUtils.GenerateRandomFileName(64)}.jpg";
        try
        {
            var putObjectResult =
                Client.PutObject(Config["OSSConfig:BucketName"], $"PetJoy/{key}", file.OpenReadStream());
            return Ok(new
            {
                message = "News content image uploaded successfully.",
                fileName = key,
                requestId = putObjectResult.RequestId
            });
        }
        catch (OssException ex)
        {
            return StatusCode(500, $"OSS update error: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 上传新闻内容视频
    [HttpPost("upload-news-content-video")]
    [SwaggerOperation(Summary = "上传新闻内容视频（.mp4 文件）", Description = "上传新闻内容视频（.mp4 文件）")]
    [SwaggerResponse(200, "上传新闻内容视频成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public IActionResult UploadNewsContentVideo(IFormFile file)
    {
        if (file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        var key = $"NewsContentVideos/{FileNameUtils.GenerateRandomFileName(64)}.mp4";
        try
        {
            var putObjectResult =
                Client.PutObject(Config["OSSConfig:BucketName"], $"PetJoy/{key}", file.OpenReadStream());
            return Ok(new
            {
                message = "News content video uploaded successfully.",
                fileName = key,
                requestId = putObjectResult.RequestId
            });
        }
        catch (OssException ex)
        {
            return StatusCode(500, $"OSS update error: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 上传帖子图片
    [HttpPost("upload-post-image")]
    [SwaggerOperation(Summary = "上传帖子图片（.jpg 文件）", Description = "上传帖子图片（.jpg 文件）")]
    [SwaggerResponse(200, "上传帖子图片成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public IActionResult UploadPostImage(IFormFile file)
    {
        if (file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        var key = $"PostImages/{FileNameUtils.GenerateRandomFileName(64)}.jpg";
        try
        {
            var putObjectResult =
                Client.PutObject(Config["OSSConfig:BucketName"], $"PetJoy/{key}", file.OpenReadStream());
            return Ok(new
            {
                message = "Post image uploaded successfully.",
                fileName = key,
                requestId = putObjectResult.RequestId
            });
        }
        catch (OssException ex)
        {
            return StatusCode(500, $"OSS update error: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 上传宠物领养图片
    [HttpPost("upload-pet-adoption-image")]
    [SwaggerOperation(Summary = "上传宠物领养图片（.jpg 文件）", Description = "上传宠物领养图片（.jpg 文件）")]
    [SwaggerResponse(200, "上传宠物领养图片成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public IActionResult UploadPetAdoptionImage(IFormFile file)
    {
        if (file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        var key = $"PetAdoptionImages/{FileNameUtils.GenerateRandomFileName(64)}.jpg";
        try
        {
            var putObjectResult =
                Client.PutObject(Config["OSSConfig:BucketName"], $"PetJoy/{key}", file.OpenReadStream());
            return Ok(new
            {
                message = "Pet adoption image uploaded successfully.",
                fileName = key,
                requestId = putObjectResult.RequestId
            });
        }
        catch (OssException ex)
        {
            return StatusCode(500, $"OSS update error: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 上传宠物领养附件
    [HttpPost("upload-pet-adoption-appendix")]
    [SwaggerOperation(Summary = "上传宠物领养附件（.pdf 文件）", Description = "上传宠物领养附件（.pdf 文件）")]
    [SwaggerResponse(200, "上传宠物领养附件成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public IActionResult UploadPetAdoptionAppendix(IFormFile file)
    {
        if (file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        var key = $"PetAdoptionAppendices/{FileNameUtils.GenerateRandomFileName(64)}.pdf";
        try
        {
            var putObjectResult =
                Client.PutObject(Config["OSSConfig:BucketName"], $"PetJoy/{key}", file.OpenReadStream());
            return Ok(new
            {
                message = "Pet adoption appendix uploaded successfully.",
                fileName = key,
                requestId = putObjectResult.RequestId
            });
        }
        catch (OssException ex)
        {
            return StatusCode(500, $"OSS update error: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}