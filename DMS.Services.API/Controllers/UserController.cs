using DMS.Services.Application.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Services.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getLoggedInUserInfo", Name = "GetLoggedInUserInfo")]
        public async Task<ActionResult<List<UserInfoVM>>> GetLoggedInUserInfo(string userName,string password)
        {
            var result = await _mediator.Send(new UserInfoQuery { UserName = userName ,Password =password});

            return Ok(result);
        }

        [HttpPost("add", Name = "AddUser")]
        public async Task<ActionResult> AddUser([FromBody] UserCreateCommand userCreateCommand)
        {
            var id = await _mediator.Send(userCreateCommand);

            return Ok(id);
        }

        [HttpPut("update", Name = "UpdateUser")]
        public async Task<ActionResult> UpdateUser([FromBody] UserUpdateCommand userUpdateCommand)
        {
            await _mediator.Send(userUpdateCommand);

            return NoContent();
        }

        [HttpDelete("delete", Name = "DeleteUser")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _mediator.Send(new UserDeleteCommand { Id = id });

            return NoContent();
        }

        [HttpGet("allUsers", Name = "GetAllUsers")]
        public async Task<ActionResult<List<UserListVM>>> GetAllUsers()
        {
            var result = await _mediator.Send(new UserListQuery());

            return Ok(result);

        }
    }
}
