using final_assignment.API.Models;
using final_assignment.BLL.Services.Account;
using final_assignment.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

//testing
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel;
using System.IdentityModel;

namespace final_assignment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController: ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;
        private readonly RoleManager<RoleModel> _roleManager;
        private readonly UserManager<LoginModel> _userManager;
        private readonly IConfiguration _configuration;
        public AccountController(
            ILogger<AccountController> logger, 
            IAccountService accountService,
            RoleManager<RoleModel> roleManager,
            UserManager<LoginModel> userManager,
            IConfiguration configuration)
        {
            _logger = logger;
            _accountService = accountService;
            _roleManager = roleManager;
            _userManager = userManager;
            _configuration = configuration;
        }
        // Authenthıcation request, returns token
        // api/Account/login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel login)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(login.UserName);
                if (user != null && await _userManager.CheckPasswordAsync(user, login.PasswordHash))
                {
                    var userRoles = await _userManager.GetRolesAsync(user);

                    var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }

                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(3),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                        );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                }
                return StatusCode(StatusCodes.Status403Forbidden, new Response { Status = "Forbidden", Message = "User Login failed! Please check user details and try again." });
            }
            catch (Exception)
            {
                // Logging
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User login failed! Please check user details and try again." });
            }
            
        }
        // api/Account/register
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(LoginModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.UserName);
            if (userExists != null)
                return StatusCode(StatusCodes.Status302Found, new Response { Status = "Error", Message = "User already exists!" });

            LoginModel user = new LoginModel()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                PasswordHash = model.PasswordHash
            };
            var userReturn = _accountService.AddLogin(user);
            if (userReturn == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }
    }
}
