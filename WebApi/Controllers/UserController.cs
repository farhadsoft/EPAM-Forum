using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService userService;

        public UserController()
        {
            userService = new UserService();
        }

        //GET: /api/user/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        //POST: /api/user/
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] UserModel userModel)
        {
            throw new NotImplementedException();
        }

        //PUT: /api/user/
        [HttpPut]
        public async Task<ActionResult> Update(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        //DELETE: /api/user/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
