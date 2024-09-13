/*
 * Project Name:  DatabaseWebAPI
 * File Name:     Main.cs
 * File Function: 后端应用程序入口
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-08-05
 * License:       Creative Commons Attribution 4.0 International License
 */

using DatabaseWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.Kestrel.Core;

// 加载配置文件
var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("config.json")
    .Build();

// 创建 Web 应用构建器
var builder = WebApplication.CreateBuilder(args);

// 配置服务
builder.Services.AddCors(options =>
{
    // 配置跨域资源共享（CORS）
    options.AddPolicy("AllowAll", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// 配置数据库上下文
builder.Services.AddDbContext<OracleDbContext>(options =>
{
    options.UseOracle("User Id="
                      + config["DatabaseConfig:UserId"]
                      + ";Password="
                      + config["DatabaseConfig:Password"]
                      + ";Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST="
                      + config["DatabaseConfig:Host"]
                      + ")(PORT="
                      + config["DatabaseConfig:Port"]
                      + ")))(CONNECT_DATA=(SERVICE_NAME="
                      + config["DatabaseConfig:ServiceName"] + ")));");
});

// 配置 Jwt Token 登录鉴权
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = config["Jwt:Issuer"],
            ValidAudience = config["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                config["Jwt:Key"] ?? throw new InvalidOperationException()))
        };
    });

// 配置全局请求体大小限制
builder.Services.Configure<KestrelServerOptions>(options => { options.Limits.MaxRequestBodySize = null; });

// 添加服务到容器
builder.Services.AddControllers();

// 配置 Swagger 服务
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("api", new OpenApiInfo
    {
        Title = "宠悦 | PetJoy - 数据库网络应用程序接口 | Database Web API",
        Description = """
                      欢迎来到[宠悦](http://[TODO: Host])，为宠物爱好者提供的一站式信息与资源交流天地。在这里，您可以浏览我们的数据库网络应用程序接口文档。

                      Welcome to [PetJoy](http://[TODO: Host]), a one-stop hub for information and resource exchange tailored to pet enthusiasts. Here, you can explore our database web API documentation.

                      ![PetJoyLogo](https://[TODO: BucketName].[TODO: Endpoint]/PetJoy/LogosAndIcons/PetJoyLogo.png)

                      版权所有 © 2024 宠悦 | PetJoy 项目开发组 - 采用 CC-BY-4.0 许可证授权

                      Copyright © 2024 PetJoy Development Team - Licensed under CC-BY-4.0 License

                      关于宠悦 - [About PetJoy](http://[TODO: Host]/about-petjoy) |
                      联系我们 - [Contact Us](mailto:minmuslin@outlook.com) |
                      GitHub 仓库 - [GitHub Repository](https://github.com/MinmusLin/PetJoy)
                      """
    });
    c.EnableAnnotations();
});

// 构建 Web 应用
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // 启用开发者异常页面中间件
}

app.UseSwagger(); // 启用 Swagger 中间件
app.UseSwaggerUI(c => // 配置 Swagger UI
{
    c.SwaggerEndpoint("/swagger/api/swagger.json", "api");
    c.RoutePrefix = string.Empty;
    c.DocumentTitle = "宠悦 PetJoy - API";
    // ReSharper disable once StringLiteralTypo
    c.HeadContent = """
                    <script type='text/javascript'>
                        document.addEventListener('DOMContentLoaded', function() {
                            var icons = document.querySelectorAll('link[rel=\"icon\"]');
                            icons.forEach(function(icon) {
                                if (icon.getAttribute('sizes') === '32x32') {
                                    icon.href = 'https://[TODO: BucketName].[TODO: Endpoint]/PetJoy/LogosAndIcons/PetJoyIcon.png';
                                }
                                if (icon.getAttribute('sizes') === '16x16') {
                                    icon.href = 'https://[TODO: BucketName].[TODO: Endpoint]/PetJoy/LogosAndIcons/PetJoyIcon.png';
                                }
                            });
                        });
                    </script>
                    <style>
                        .swagger-ui .topbar {
                            display: none !important;
                        }
                        .swagger-ui .info .title small {
                            display: none !important;
                        }
                        .swagger-ui .info hgroup.main a {
                            display: none !important;
                        }
                    </style>
                    """;
});
app.UseCors("AllowAll"); // 启用跨域资源共享（CORS）
app.UseRouting(); // 启用路由中间件
app.UseHttpsRedirection(); // 启用 HTTPS 重定向中间件
app.UseAuthorization(); // 启用授权中间件
app.MapControllers(); // 将控制器映射到路由
app.Run(); // 启动应用程序并开始处理请求