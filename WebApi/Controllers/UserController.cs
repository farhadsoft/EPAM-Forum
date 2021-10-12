using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BLL.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [Route("Registration")]
        [AllowAnonymous]
        public async Task<ActionResult> Register([FromBody] UserAddModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.RegisterAsync(user);
                if (result.Success)
                {
                    return Ok(result.Token);
                }

                return BadRequest(result.Errors);
            }
            else
            {
                return BadRequest("Invalid payload");
            }
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody] UserLoginModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.LoginAsync(user);
                if (result.Success)
                {
                    return Ok(result.Token);
                }

                return BadRequest(result.Errors);
            }
            else
            {
                return BadRequest("Invalid payload");
            }
        }

        [HttpPost]
        [Route("RoleChange")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> RoleChange([FromBody] RoleModel roleModel)
        {
            var result = await userService.RoleChangeAsync(roleModel);
            if (result.Success)
            {
                return Ok(result.Errors);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
    }
}
