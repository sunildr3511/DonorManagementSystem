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

        [HttpPost("add", Name = "AddStakeHolder")]
        public async Task<ActionResult> AddStakeHolder([FromBody] StakeHolderCreateCommand stakeHolderCreateCommand)
        {
            await _mediator.Send(stakeHolderCreateCommand);

            return NoContent();
        }

        [HttpDelete("delete", Name = "DeleteStakeHolder")]
        public async Task<ActionResult> DeleteStakeHolder(int id)
        {
            await _mediator.Send(new StakeHolderDeleteCommand { Id=id});

            return NoContent();
        }

        [HttpPut("update", Name = "UpdateStakeHolder")]
        public async Task<ActionResult> UpdateStakeHolder([FromBody] StakeHolderUpdateCommand stakeHolderUpdateCommand)
        {
            await _mediator.Send(stakeHolderUpdateCommand);

            return NoContent();
        }
    }
}
