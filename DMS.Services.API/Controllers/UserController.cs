using DMS.Services.Application.Features;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<UserInfoVM>> GetLoggedInUserInfo(string userName,string email)
        {
            var result = await _mediator.Send(new UserInfoQuery { UserName = userName ,Email =email});

            return result == null ? StatusCode(StatusCodes.Status500InternalServerError) : Ok(result);
        }

        [HttpPost("add", Name = "AddUser")]
        public async Task<ActionResult> AddUser([FromBody] UserCreateCommand userCreateCommand)
        {
            var response = await _mediator.Send(userCreateCommand);

            return Ok(response);
        }

        [HttpPut("update", Name = "UpdateUser")]
        public async Task<ActionResult> UpdateUser([FromBody] UserUpdateCommand userUpdateCommand)
        {
            var response = await _mediator.Send(userUpdateCommand);

             return Ok(response);
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
