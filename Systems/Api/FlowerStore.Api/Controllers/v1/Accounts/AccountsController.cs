using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Api.Controllers.v1.Accounts.Models;
using FlowerStore.Context.Entities;
using FlowerStore.Services.UserAccount;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FlowerStore.Api.Controllers.v1.Accounts
{
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
        public async Task<UserAccountResponse> Register([FromBody] RegisterUserAccountRequest request)
        {
            var user = await userAccountService.Create(request);
            return user;
        }

        /// <summary>
        /// Get all user accounts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<UserAccountResponse>> GetAll()
        {
            var users = await userAccountService.GetAll();
            return users.Select(u => (UserAccountResponse)u);
        }
    }
}