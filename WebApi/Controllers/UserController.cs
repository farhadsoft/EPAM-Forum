using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApi.Configuration;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly JwtConfig jwtConfig;

        public UserController(UserManager<IdentityUser> userManager,
                        RoleManager<IdentityRole> roleManager,
                        IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            jwtConfig = optionsMonitor.CurrentValue;
        }

        [HttpPost]
        [Route("Registration")]
        [AllowAnonymous]
        public async Task<ActionResult> Register([FromBody] UserAddModel user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await userManager.FindByEmailAsync(user.Email);

                if (existingUser is not null)
                {
                    return BadRequest(new UserService()
                    {
                        Errors = new List<string>() {
                                "Email already in use"
                            },
                        Success = false
                    });
                }

                var newUser = new IdentityUser() { Email = user.Email, UserName = user.Username };
                var isCreated = await userManager.CreateAsync(newUser, user.Password);
                if (isCreated.Succeeded)
                {
                    var jwtToken = GenerateJwtToken(newUser);
                    await userManager.AddToRoleAsync(newUser, "USER");

                    return Ok(new UserService()
                    {
                        Success = true,
                        Token = jwtToken.Result.ToString()
                    });
                }
                else
                {
                    return BadRequest(new UserService()
                    {
                        Errors = isCreated.Errors.Select(x => x.Description).ToList(),
                        Success = false
                    });
                }
            }
            return BadRequest(new UserService()
            {
                Errors = new List<string>() {
                        "Invalid payload"
                    },
                Success = false
            });
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody] UserLoginModel user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await userManager.FindByEmailAsync(user.Email);

                if (existingUser is null)
                {
                    return BadRequest(new UserService()
                    {
                        Errors = new List<string>() {
                                "Invalid login request"
                            },
                        Success = false
                    });
                }

                var isCorrect = await userManager.CheckPasswordAsync(existingUser, user.Password);

                if (!isCorrect)
                {
                    return BadRequest(new UserService()
                    {
                        Errors = new List<string>() {
                                "Invalid login request"
                            },
                        Success = false
                    });
                }

                var jwtToken = GenerateJwtToken(existingUser);

                return Ok(new UserService()
                {
                    Success = true,
                    Token = jwtToken.Result.ToString()
                });
            }

            return BadRequest(new UserService()
            {
                Errors = new List<string>() {
                        "Invalid payload"
                    },
                Success = false
            });
        }

        [HttpPost]
        [Route("RoleChange")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> RoleChange([FromBody] RoleModel roleModel)
        {
            var currentUser = await userManager.FindByEmailAsync(roleModel.Email);
            if (currentUser is null)
            {
                return BadRequest(new UserService()
                {
                    Errors = new List<string>() {
                        "Invalid user request"
                    },
                    Success = false
                });
            }

            if (!roleManager.RoleExistsAsync(roleModel.Role).Result)
            {
                return BadRequest(new UserService()
                {
                    Errors = new List<string>() {
                        "Invalid role request"
                    },
                    Success = false
                });
            }

            var isSuccess = await userManager.AddToRoleAsync(currentUser, roleModel.Role);

            if (isSuccess.Succeeded)
            {
                return Ok();
            }

            return BadRequest(new UserService()
            {
                Success = false,
                Errors = isSuccess.Errors.Select(x => x.Description).ToList()
            });

        }

        private async Task<object> GenerateJwtToken(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var roles = await userManager.GetRolesAsync(user);
            AddRolesToClaims(claims, roles);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(1);

            var token = new JwtSecurityToken(
                null,
                null,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static void AddRolesToClaims(List<Claim> claims, IEnumerable<string> roles)
        {
            foreach (var role in roles)
            {
                var roleClaim = new Claim(ClaimTypes.Role, role);
                claims.Add(roleClaim);
            }
        }
    }
}
