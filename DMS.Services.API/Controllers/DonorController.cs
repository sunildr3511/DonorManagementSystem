﻿using DMS.Services.Application.Features;
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

        [HttpGet("{id}", Name = "GetDonorById")]
        public async Task<ActionResult<DonorDetailVM>> GetDonorById(int id)
        {
            var pole = await _mediator.Send(new GetDonorDetailQuery { Id = id });

            return Ok(pole);
        }
    }
}
