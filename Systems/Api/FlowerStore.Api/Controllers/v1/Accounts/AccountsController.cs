using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Api.Controllers.v1.Accounts.Models;
using FlowerStore.Common.Exceptions;
using FlowerStore.Context.Entities;
using FlowerStore.Services.UserAccount;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FlowerStore.Api.Controllers.v1.Accounts;

/// <summary>
/// Accounts controller
/// </summary>
[ApiController]
[Route("api/v{version:apiVersion}/accounts")]
[ApiVersion("1.0")]
public class AccountsController : BaseController
{
    private readonly ILogger<AccountsController> logger;
    private readonly IUserAccountService userAccountService;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="userAccountService"></param>
    public AccountsController(ILogger<AccountsController> logger, IUserAccountService userAccountService)
    {
        this.logger = logger;
        this.userAccountService = userAccountService;
    }

    /// <summary>
    /// Register new user
    /// </summary>
    /// <param name="request">User info</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<UserResponse> Register([FromBody] RegisterUserRequest request)
    {
        var user = await userAccountService.CreateAsync(request);
        return user;
    }

    /// <summary>
    /// Get all user accounts
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Authorize(Roles = "SystemAdmin")]
    public async Task<IEnumerable<UserResponse>> GetAll()
    {
        var users = await userAccountService.GetAllAsync();
        return users.Select(u => (UserResponse)u);
    }

    /// <summary>
    /// Get user by Id
    /// </summary>
    /// <param name="userId">User Id</param>
    /// <returns>UserResponse</returns>
    [HttpGet("{userId}")]
    [Authorize(Roles = "SystemAdmin")]
    public async Task<ActionResult<UserResponse>> GetById(string userId)
    {
        var user = await userAccountService.GetByIdAsync(userId);
        if (user == null) return NotFound();
        return Ok((UserResponse)user);
    }

    /// <summary>
    /// Get role types
    /// </summary>
    /// <returns></returns>
    [HttpGet("roles/types")]
    [Authorize(Roles = "SystemAdmin")]
    public IEnumerable<string> GetRoleTypes()
    {
        var roleTypes = userAccountService.GetRoleTypes().Result;
        return roleTypes;
    }

    /// <summary>
    /// Set user roles
    /// </summary>
    /// <param name="userId">User Id</param>
    /// <param name="roles">Roles in comma delimited</param>
    /// <returns></returns>
    [HttpPatch("{userId}/roles")]
    [Authorize(Roles = "SystemAdmin")]
    public async Task<IActionResult> SetRoles(string userId, [FromQuery] string roles)
    {
        try
        {
            var rolesList = roles.Split(',').Select(x => x.Trim());
            await userAccountService.SetRolesAsync(userId, rolesList);
            return Ok();
        }
        catch (ProcessException ex)
        {
            if (ex.Code == ProcessExceptionCode.NotFound) return NotFound(ex.Message);
            throw;
        }
    }

    /// <summary>
    /// Set user password
    /// </summary>
    /// <param name="userId">User ID</param>
    /// <param name="passwordRequest">Password request</param>
    /// <returns></returns>
    [HttpPatch("{userId}/password/set")]
    [Authorize(Roles = "SystemAdmin")]
    public async Task<IActionResult> SetPassword(string userId, [FromBody] SetPasswordRequest passwordRequest)
    {
        try
        {
            await userAccountService.SetPasswordAsync(userId, passwordRequest.Password!);
            return Ok("Success");
        }
        catch (ProcessException ex)
        {
            if (ex.Code == ProcessExceptionCode.NotFound) return NotFound(ex.Message);
            throw;
        }
    }

    [HttpPatch("password/change")]
    [Authorize]
    public async Task<IActionResult> CangePassword([FromBody] ChangePasswordRequest changePasswordRequest)
    {
        var userId = GetUserId();
        try
        {
            await userAccountService.ChangePasswordAsync(userId, changePasswordRequest.OldPassword!, changePasswordRequest.NewPassword!);
            return Ok("Password changed");
        }
        catch (ProcessException ex)
        {
            if (ex.Code == ProcessExceptionCode.NotFound) return NotFound(ex.Message);
            throw;
        }
    }
}