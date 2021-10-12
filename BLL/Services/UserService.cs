using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BLL.Configuration;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly JwtConfig jwtConfig;

        public UserService(UserManager<IdentityUser> userManager,
                        RoleManager<IdentityRole> roleManager,
                        IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.jwtConfig = optionsMonitor.CurrentValue;
        }
        public async Task<UserModel> LoginAsync(UserLoginModel user)
        {
            var existingUser = await userManager.FindByEmailAsync(user.Email);

                if (existingUser is null)
                {
                    return new UserModel()
                    {
                        Errors = new List<string>() {
                                "Invalid login request"
                            },
                        Success = false
                    };
                }

                var isCorrect = await userManager.CheckPasswordAsync(existingUser, user.Password);

                if (!isCorrect)
                {
                    return new UserModel()
                    {
                        Errors = new List<string>() {
                                "Invalid login request"
                            },
                        Success = false
                    };
                }

                var jwtToken = GenerateJwtToken(existingUser);

                return new UserModel()
                {
                    Success = true,
                    Errors = new List<string>() { jwtToken.Result.ToString() },
                };
        }
        public async Task<UserModel> RegisterAsync(UserAddModel user)
        {
            var existingUser = await userManager.FindByEmailAsync(user.Email);

            if (existingUser is not null)
            {
                return new UserModel()
                    {
                        Errors = new List<string>() {
                                "Email already in use"
                            },
                        Success = false
                    };
            }

            var newUser = new IdentityUser() { Email = user.Email, UserName = user.Username };
            var isCreated = await userManager.CreateAsync(newUser, user.Password);
            if (isCreated.Succeeded)
            {
                var jwtToken = GenerateJwtToken(newUser);
                await userManager.AddToRoleAsync(newUser, "USER");

                return new UserModel()
                {
                    Success = true,
                    Errors = new List<string>() { jwtToken.Result.ToString() }
                };
            }
            else
            {
                return new UserModel()
                {
                    Errors = isCreated.Errors.Select(x => x.Description).ToList(),
                    Success = false
                };
            }
        }

        public async Task<UserModel> RoleChangeAsync(RoleModel roleModel)
        {
            var currentUser = await userManager.FindByEmailAsync(roleModel.Email);
            if (currentUser is null)
            {
                return new UserModel()
                {
                    Errors = new List<string>() {
                        "Invalid user request"
                    },
                    Success = false
                };
            }

            bool roleExists = await roleManager.RoleExistsAsync(roleModel.Role);
            if (!roleExists)
            {
                return new UserModel()
                {
                    Errors = new List<string>() {
                        "Invalid role request"
                    },
                    Success = false
                };
            }

            var isSuccess = await userManager.AddToRoleAsync(currentUser, roleModel.Role);

            if (isSuccess.Succeeded)
            {
                return new UserModel()
                {
                    Success = true,
                    Errors = new List<string>() {
                        "Role is created"
                    },
                };
            }

            return new UserModel()
            {
                Success = false,
                Errors = isSuccess.Errors.Select(x => x.Description).ToList()
            };
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