/*
 * Project Name:  DatabaseWebAPI
 * File Name:     UserController.cs
 * File Function: User 控制器
 * Author:        宠悦 | PetJoy 项目开发组
 * Update Date:   2024-08-16
 * License:       Creative Commons Attribution 4.0 International License
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseWebAPI.Data;
using DatabaseWebAPI.Models.TableModels;
using Swashbuckle.AspNetCore.Annotations;
using DatabaseWebAPI.Models.RequestModels;
using DatabaseWebAPI.Utils;

namespace DatabaseWebAPI.Controllers.ModelsControllers;

[Route("api/user")]
[ApiController]
[SwaggerTag("用户表相关 API")]
public class UserController(OracleDbContext context) : ControllerBase
{
    // 获取用户表的所有数据
    [HttpGet]
    [SwaggerOperation(Summary = "获取用户表的所有数据", Description = "获取用户表的所有数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<IEnumerable<User>>> GetUser()
    {
        try
        {
            return Ok(await context.UserSet.ToListAsync());
        }
        catch (DbUpdateException dbEx)
        {
            return StatusCode(500, $"Database update error: {dbEx.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）获取用户表的数据
    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取用户表的数据", Description = "根据主键（ID）获取用户表的数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<User>> GetUserByPk(int id)
    {
        try
        {
            var user = await context.UserSet.FindAsync(id);
            if (user == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            return Ok(user);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）获取用户表的用户名数据
    [HttpGet("user-name/{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取用户表的用户名数据", Description = "根据主键（ID）获取用户表的用户名数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<User>> GetUserNameByPk(int id)
    {
        try
        {
            var user = await context.UserSet.FindAsync(id);
            if (user == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            return Ok(user.UserName);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）获取用户表的手机号码数据
    [HttpGet("telephone/{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取用户表的手机号码数据", Description = "根据主键（ID）获取用户表的手机号码数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<User>> GetUserTelephoneByPk(int id)
    {
        try
        {
            var user = await context.UserSet.FindAsync(id);
            if (user == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            return Ok(user.Telephone);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）获取用户表的头像链接数据
    [HttpGet("avatar-url/{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取用户表的头像链接数据", Description = "根据主键（ID）获取用户表的头像链接数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<User>> GetUserAvatarUrlByPk(int id)
    {
        try
        {
            var user = await context.UserSet.FindAsync(id);
            if (user == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            return Ok(user.AvatarUrl);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）获取用户表的用户角色数据
    [HttpGet("role/{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）获取用户表的用户角色数据", Description = "根据主键（ID）获取用户表的用户角色数据")]
    [SwaggerResponse(200, "获取数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    public async Task<ActionResult<User>> GetUserRoleByPk(int id)
    {
        try
        {
            var user = await context.UserSet.FindAsync(id);
            if (user == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            return Ok(user.Role);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）删除用户表的数据
    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）删除用户表的数据", Description = "根据主键（ID）删除用户表的数据")]
    [SwaggerResponse(200, "删除数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<User>> DeleteUserByPk(int id)
    {
        try
        {
            var user = await context.UserSet.FindAsync(id);
            if (user == null)
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            context.UserSet.Remove(user);
            await context.SaveChangesAsync();
            return Ok($"Data with ID: {id} has been deleted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 向用户表添加数据项
    [HttpPost]
    [SwaggerOperation(Summary = "向用户表添加数据项", Description = "向用户表添加数据项（不需要提供 USER_ID，因为它是由系统自动生成的）")]
    [SwaggerResponse(201, "添加数据项成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> PostUser([FromBody] User user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.UserSet.Add(user);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(PostUser), new { id = user.UserId }, user);
    }

    // 根据主键（ID）更新用户表的数据
    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新用户表的数据", Description = "根据主键（ID）更新用户表的数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
    {
        if (id != user.UserId)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        context.Entry(user).State = EntityState.Modified;
        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!context.UserSet.Any(e => e.UserId == id))
            {
                return NotFound($"No corresponding data found for ID: {id}");
            }

            throw;
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }

        return Ok($"Data with ID: {id} has been updated successfully.");
    }

    // 根据主键（ID）更新用户表的个人信息数据
    [HttpPut("personal-information/{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新用户表的个人信息数据", Description = "根据主键（ID）更新用户表的个人信息数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdatePersonalInformation(int id,
        [FromBody] PersonalInformationRequest personalInformationRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await context.UserSet.FindAsync(id);
        if (user == null)
        {
            return NotFound($"No corresponding data found for ID: {id}");
        }

        user.Profile = personalInformationRequest.Profile;
        user.Gender = personalInformationRequest.Gender;
        user.Birthdate = personalInformationRequest.Birthdate;
        try
        {
            await context.SaveChangesAsync();
            return Ok($"Data with ID: {id} has been updated successfully.");
        }
        catch (DbUpdateConcurrencyException ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）更新用户表的头像链接数据
    [HttpPut("avatar-url/{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新用户表的头像链接数据", Description = "根据主键（ID）更新用户表的头像链接数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdateAvatarUrl(int id, [FromBody] AvatarUrlRequest avatarUrlRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await context.UserSet.FindAsync(id);
        if (user == null)
        {
            return NotFound($"No corresponding data found for ID: {id}");
        }

        user.AvatarUrl = avatarUrlRequest.AvatarUrl;
        try
        {
            await context.SaveChangesAsync();
            return Ok($"Data with ID: {id} has been updated successfully.");
        }
        catch (DbUpdateConcurrencyException ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）更新用户表的上次登录时间数据
    [HttpPut("last-login-time/{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新用户表的上次登录时间数据", Description = "根据主键（ID）更新用户表的上次登录时间数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdateLastLoginTime(int id, [FromBody] LastLoginTimeRequest lastLoginTimeRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await context.UserSet.FindAsync(id);
        if (user == null)
        {
            return NotFound($"No corresponding data found for ID: {id}");
        }

        user.LastLoginTime = lastLoginTimeRequest.LastLoginTime;
        try
        {
            await context.SaveChangesAsync();
            return Ok($"Data with ID: {id} has been updated successfully.");
        }
        catch (DbUpdateConcurrencyException ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）更新用户表的密码数据
    [HttpPut("password/{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新用户表的密码数据", Description = "根据主键（ID）更新用户表的密码数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdatePassword(int id, [FromBody] PlainPasswordRequest plainPasswordRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await context.UserSet.FindAsync(id);
        if (user == null)
        {
            return NotFound($"No corresponding data found for ID: {id}");
        }

        user.Password = PasswordUtils.PlainPasswordToHashedPassword(plainPasswordRequest.PlainPassword);
        try
        {
            await context.SaveChangesAsync();
            return Ok($"Data with ID: {id} has been updated successfully.");
        }
        catch (DbUpdateConcurrencyException ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据主键（ID）更新用户表的手机号码数据
    [HttpPut("telephone/{id:int}")]
    [SwaggerOperation(Summary = "根据主键（ID）更新用户表的手机号码数据", Description = "根据主键（ID）更新用户表的手机号码数据")]
    [SwaggerResponse(200, "更新数据成功")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<IActionResult> UpdateTelephone(int id, [FromBody] TelephoneRequest telephoneRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await context.UserSet.FindAsync(id);
        if (user == null)
        {
            return NotFound($"No corresponding data found for ID: {id}");
        }

        user.Telephone = telephoneRequest.Telephone;
        try
        {
            await context.SaveChangesAsync();
            return Ok($"Data with ID: {id} has been updated successfully.");
        }
        catch (DbUpdateConcurrencyException ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 判断用户名是否存在于用户表中
    [HttpGet("check-username-unique/{username}")]
    [SwaggerOperation(Summary = "判断用户名是否存在于用户表中", Description = "判断用户名是否存在于用户表中")]
    [SwaggerResponse(200, "请求成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<int>> CheckUserNameUnique(string userName)
    {
        try
        {
            var count = await context.UserSet.CountAsync(u => u.UserName == userName);
            return Ok(count > 0 ? 1 : 0);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 判断手机号码是否存在于用户表中
    [HttpGet("check-telephone-unique/{telephone}")]
    [SwaggerOperation(Summary = "判断手机号码是否存在于用户表中", Description = "判断手机号码是否存在于用户表中")]
    [SwaggerResponse(200, "请求成功")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<int>> CheckTelephoneUnique(string telephone)
    {
        try
        {
            var count = await context.UserSet.CountAsync(u => u.Telephone == telephone);
            return Ok(count > 0 ? 1 : 0);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 验证用户密码是否正确
    [HttpPost("verify-password")]
    [SwaggerOperation(Summary = "验证用户密码是否正确", Description = "验证用户密码是否正确")]
    [SwaggerResponse(200, "请求成功")]
    [SwaggerResponse(400, "请求无效")]
    [SwaggerResponse(404, "未找到对应数据")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<int>> VerifyPassword(
        [FromBody] PasswordVerificationRequest passwordVerificationRequest)
    {
        if (passwordVerificationRequest.UserId == 0 || string.IsNullOrEmpty(passwordVerificationRequest.PlainPassword))
        {
            return BadRequest(ModelState);
        }

        try
        {
            var user = await context.UserSet.FindAsync(passwordVerificationRequest.UserId);
            if (user == null)
            {
                return NotFound($"No corresponding data found for ID: {passwordVerificationRequest.UserId}");
            }

            var hashedPassword = PasswordUtils.PlainPasswordToHashedPassword(passwordVerificationRequest.PlainPassword);
            return Ok(hashedPassword == user.Password ? 1 : 0);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // 根据电话号码获取用户 ID
    [HttpGet("get-user-id-by-telephone/{telephone}")]
    [SwaggerOperation(Summary = "根据电话号码获取用户 ID", Description = "根据电话号码获取用户 ID")]
    [SwaggerResponse(200, "请求成功")]
    [SwaggerResponse(404, "未找到对应的电话号码")]
    [SwaggerResponse(500, "服务器内部错误")]
    // ReSharper disable once InconsistentNaming
    public async Task<ActionResult<int>> GetUserIdByTelephone(string telephone)
    {
        try
        {
            var user = await context.UserSet.FirstOrDefaultAsync(u => u.Telephone == telephone);
            if (user == null)
            {
                return NotFound($"No corresponding data found for telephone: {telephone}");
            }

            return Ok(user.UserId);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}