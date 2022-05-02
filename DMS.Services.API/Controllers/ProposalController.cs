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
        public async Task<ActionResult> Addfus([FromBody] FusProposalCreateCommad fUSProposalCreateCommad)
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
        public async Task<ActionResult> UpdateFamilyUnitSponsorById([FromBody] FusProposalUpdateCommad fUSProposalUpdateCommad)
        {
            await _mediator.Send(fUSProposalUpdateCommad);

            return NoContent();
        }

        [HttpDelete("deletefusById", Name = "DeletefusById")]
        public async Task<ActionResult> DeleteFamilyUnitSponsorById(int id)
        {
            await _mediator.Send(new FusProposalDeleteCommad { Id = id });

            return NoContent();
        }

        [HttpGet("getfusById", Name = "GetfusById")]
        public async Task<ActionResult<FusProposalDetailVM>> GetFamilyUnitSponsorById(int proposalId)
        {
            var result = await _mediator.Send(new GetFusProposalDetailQuery { ProposalId = proposalId });

            return Ok(result);
        }

        [HttpGet("getBudgetInfoByCenterLocationId", Name = "GetBudgetInfoByCenterLocationId")]
        public async Task<ActionResult<List<BudgetInfoBasedOnCenterVM>>> GetBudgetInfoByCenterLocationId(int locationId, int centerId, int purposeId)
        {
            var result = await _mediator.Send(new BudgetInfoBasedOnCenterQuery { LocationId = locationId, CenterId = centerId, PurposeId = purposeId });

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

        [HttpGet("getNonfusById", Name = "GetNonfusById")]
        public async Task<ActionResult<NonFusProposalDetailVM>> GetNonFusById(int proposalId)
        {
            var result = await _mediator.Send(new GetNonFusProposalDetailQuery { ProposalId = proposalId });

            return Ok(result);
        }

        [HttpPut("updateNonfusById", Name = "UpdateNonfusById")]
        public async Task<ActionResult> UpdateNonFusById([FromBody] NonFusProposalUpdateCommand nonFusProposalUpdateCommand)
        {
            await _mediator.Send(nonFusProposalUpdateCommand);

            return NoContent();
        }

        [HttpDelete("deleteNonfusById", Name = "DeleteNonfusById")]
        public async Task<ActionResult> DeleteNonFusById(int id)
        {
            await _mediator.Send(new NonFusProposalDeleteCommad { Id = id });

            return NoContent();
        }

        [HttpGet("getAllPurposesByDonorId", Name = "GetAllPurposesByDonorId")]
        public async Task<ActionResult<DonorBasedProposalVM>> GetAllPurposesByDonorId(int donorId)
        {
            var results = await _mediator.Send(new GetDonorBasedProposalQuery { DonorId = donorId });

            return Ok(results);
        }

        [HttpPut("updateProposlaByIdAndType", Name = "UpdateProposalByIdAndType")]
        public async Task<ActionResult> UpdateProposalByIdAndType([FromBody] ProposalUpdateCommand proposalUpdateCommad)
        {
            await _mediator.Send(proposalUpdateCommad);

            return NoContent();
        }

        [HttpDelete("deleteProposalByIdAndType", Name = "DeleteProposalByIdAndType")]
        public async Task<ActionResult> DeleteProposalByIdAndType(int id, int typeId)
        {
            await _mediator.Send(new ProposalDeleteCommad { Id = id, ProposalTypeId=typeId});

            return NoContent();
        }
    }
}
