using DMS.Services.Application.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<ActionResult<DonorVM>> AddDonor([FromBody] DonorCreateCommand donorCreateCommand)
        {
            var id = await _mediator.Send(donorCreateCommand);

            return Ok(id);
        }

        [HttpPost("addDocument", Name = "AddDocument")]
        public async Task<ActionResult<int>> AddDocument([FromForm] DonorDocumentCreateCommand donorDocumentCreateCommand)
        {
            var id = await _mediator.Send(donorDocumentCreateCommand);

            return Ok(id);
        }

        [HttpGet("allDonors", Name = "GetAllDonors")]
        public async Task<ActionResult<List<DonorListVM>>> GetAllDonors()
        {
            var result = await _mediator.Send(new DonorListQuery());

            return Ok(result);

        }
    }
}
