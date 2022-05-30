using DMS.Services.Application.Features;
using DMS.Services.Application.Features.Donor;
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

        [HttpPost("add", Name = "AddDonorProfile")]
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

        [HttpGet("managerBasedAllDonors", Name = "GetManagerBasedAllDonors")]
        public async Task<ActionResult<List<DonorListVM>>> GetManagerBasedAllDonors(int loggedInUserId)
        {
            var result = await _mediator.Send(new DonorListQuery { LoggedInUserId = loggedInUserId });

            return Ok(result);

        }

        [HttpGet("getDonorById", Name = "GetDonorById")]
        public async Task<ActionResult<DonorDetailVM>> GetDonorById(int id, int donorTypeId)
        {
            var pole = await _mediator.Send(new GetDonorDetailQuery { Id = id, DonorTypeId= donorTypeId });

            return Ok(pole);
        }

        [HttpDelete("delete", Name = "DeleteDonor")]
        public async Task<ActionResult> DeleteDonor(int id)
        {
            await _mediator.Send(new DonorDeleteCommand { Id=id});

            return NoContent();
        }

        [HttpPut("update", Name = "UpdateDonor")]
        public async Task<ActionResult> UpdateDonor([FromBody] DonorUpdateCommand donorUpdateCommand)
        {
            await _mediator.Send(donorUpdateCommand);

            return NoContent();
        }


        [HttpGet("areaManagerBasedAllDonors", Name = "GetAreaManagerBasedAllDonors")]
        public async Task<ActionResult<List<AreaManagerDonorListVM>>> GetAreaManagerBasedAllDonors(int loggedInUserId)
        {
            var result = await _mediator.Send(new AreaManagerDonorListQuery { LoggedInUserId = loggedInUserId });

            return Ok(result);

        }

    }
}
