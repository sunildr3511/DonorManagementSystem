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
    public class StakeHolderController : Controller
    {
        private readonly IMediator _mediator;
        public StakeHolderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("delete", Name = "DeleteStakeHolder")]
        public async Task<ActionResult> DeleteStakeHolder([FromBody] StakeHolderDeleteCommand stakeHolderDeleteCommand)
        {
            await _mediator.Send(stakeHolderDeleteCommand);

            return NoContent();
        }
    }
}
