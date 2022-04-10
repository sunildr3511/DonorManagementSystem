using DMS.Services.Application.Features;
using DMS.Services.Domain.Entities;
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
    public class ProposalController : Controller
    {
        private readonly IMediator _mediator;
        public ProposalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("addfus", Name = "Addfus")]
        public async Task<ActionResult> Addfus([FromBody] FUSProposalCreateCommad fUSProposalCreateCommad)
        {
            await _mediator.Send(fUSProposalCreateCommad);

            return NoContent();
        }

        [HttpGet("getfusByDonorId", Name = "GetfusByDonorId")]
        public async Task<ActionResult<DonorBasedProposalVM>> GetfamilyUnitSponsorByDonorId(int donorId)
        {
            var results = await _mediator.Send(new GetDonorBasedFUSProposalQuery { DonorId = donorId });

            return Ok(results);
        }

        [HttpPut("updatefusById", Name = "UpdatefusById")]
        public async Task<ActionResult> UpdateFamilyUnitSponsorById([FromBody] FUSProposalUpdateCommad fUSProposalUpdateCommad)
        {
            await _mediator.Send(fUSProposalUpdateCommad);

            return NoContent();
        }

        [HttpDelete("deletefusById", Name = "DeletefusById")]
        public async Task<ActionResult> DeleteFamilyUnitSponsorById(int id)
        {
            await _mediator.Send(new FUSProposalDeleteCommad { Id = id });

            return NoContent();
        }

        [HttpGet("getfusById", Name = "GetfusById")]
        public async Task<ActionResult<FUSProposalDetailVM>> GetFamilyUnitSponsorById(int proposalId)
        {
            var result = await _mediator.Send(new GetFUSProposalDetailQuery { ProposalId = proposalId });

            return Ok(result);
        }

        [HttpGet("getBudgetInfoByCenterLocationId", Name = "GetBudgetInfoByCenterLocationId")]
        public async Task<ActionResult<List<BudgetInfoBasedOnCenterVM>>> GetBudgetInfoByCenterLocationId(int locationId, int centerId, string proposalName)
        {
            var result = await _mediator.Send(new BudgetInfoBasedOnCenterQuery { LocationId = locationId, CenterId = centerId, ProposalName = proposalName });

            return Ok(result);
        }

        [HttpPost("addNonfus", Name = "AddNonfus")]
        public async Task<ActionResult> AddNonfus([FromBody] NonFusProposalCreateCommand nonFusProposalCreateCommand)
        {
            await _mediator.Send(nonFusProposalCreateCommand);

            return NoContent();
        }

        [HttpGet("getNonfusByDonorId", Name = "GetNonfusByDonorId")]
        public async Task<ActionResult<DonorBasedProposalVM>> GetNonFusByDonorId(int donorId)
        {
            var results = await _mediator.Send(new GetDonorBasedNonFusProposalQuery { DonorId = donorId });

            return Ok(results);
        }
    }
}
