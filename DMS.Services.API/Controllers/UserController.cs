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
    }
}
