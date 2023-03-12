using FlowerStore.Api.Controllers.v1.Login.Models;
using FlowerStore.Context.Entities;
using FlowerStore.Services.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FlowerStore.Api.Controllers.v1.Login
{
    /// <summary>
    /// Login controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly ILoginService loginService;

        /// <summary>
        /// Logout controller constructor
        /// </summary>
        /// <param name="config"></param>
        /// <param name="loginService"></param>
        public LoginController(IConfiguration config, ILoginService loginService)
        {
            this.config = config;
            this.loginService = loginService;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="userLogin">User login info</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> LoginAsync([FromBody] UserLogin userLogin)
        {
            var user = await AuthenticeteAsync(userLogin);
            if (user != null)
            {
                var token = GenerateToken(user);
                return Ok(token);
            }

            return NotFound("User not found");
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"] ??
                Guid.NewGuid().ToString()));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>()
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.UserName!),
                new Claim(ClaimTypes.Email, user.Email ?? ""),
            };

            user.UserRoles?.ToList().ForEach(x => claims.Add(new Claim(ClaimTypes.Role, x.Name!)));

            var token = new JwtSecurityToken(
                config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<User?> AuthenticeteAsync(UserLogin userLogin)
        {
            var currentUser = await loginService.LoginAsync(userLogin.UserName!, userLogin.Password!);
            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }
    }
}
