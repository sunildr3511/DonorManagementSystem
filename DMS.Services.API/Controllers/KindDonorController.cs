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
    public class KindDonorController : Controller
    {
        private readonly IMediator _mediator;
        public KindDonorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("delete", Name = "DeleteKindDonor")]
        public async Task<ActionResult> DeleteKindDonor([FromBody] KindDonorDeleteCommand kindDonorDeleteCommand)
        {
            await _mediator.Send(kindDonorDeleteCommand);

            return NoContent();
        }

        [HttpPost("add", Name = "AddKindDonor")]
        public async Task<ActionResult<DonorVM>> AddKindDonor([FromBody] KindDonorCreateCommand kindDonorCreateCommand)
        {
            var id = await _mediator.Send(kindDonorCreateCommand);

            return Ok(id);
        }
    }
}
