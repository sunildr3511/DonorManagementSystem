using DMS.Services.Application.Features.Donor.Commands.CreateDonor;
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
    public class DonorController : Controller
    {
        private readonly IMediator _mediator;
        public DonorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add", Name = "AddDonor")]
        public async Task<ActionResult<DonorVM>> AddDonor([FromForm] DonorCreateCommand donorCreateCommand)
        {
            var id = await _mediator.Send(donorCreateCommand);

            return Ok(id);
        }
    }
}
