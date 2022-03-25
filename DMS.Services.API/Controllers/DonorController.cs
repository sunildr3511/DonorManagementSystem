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

        [HttpPost("addDonorProfile", Name = "AddDonorProfile")]
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

        [HttpPost("addKindDonor", Name = "AddKindDonor")]
        public async Task<ActionResult<DonorVM>> AddKindDonor([FromBody] KindDonorCreateCommand kindDonorCreateCommand)
        {
            var id = await _mediator.Send(kindDonorCreateCommand);

            return Ok(id);
        }

        [HttpGet("getDonorById", Name = "GetDonorById")]
        public async Task<ActionResult<DonorDetailVM>> GetDonorById(int id, int donorTypeId)
        {
            var pole = await _mediator.Send(new GetDonorDetailQuery { Id = id, DonorTypeId= donorTypeId });

            return Ok(pole);
        }

        [HttpDelete("delete", Name = "DeleteDonor")]
        public async Task<ActionResult> DeleteDonor([FromBody] DonorDeleteCommand donorDeleteCommand)
        {
            await _mediator.Send(donorDeleteCommand);

            return NoContent();
        }

        [HttpDelete("deleteKindDonor", Name = "DeleteKindDonor")]
        public async Task<ActionResult> DeleteKindDonor([FromBody] KindDonorDeleteCommand kindDonorDeleteCommand)
        {
            await _mediator.Send(kindDonorDeleteCommand);

            return NoContent();
        }

    }
}
