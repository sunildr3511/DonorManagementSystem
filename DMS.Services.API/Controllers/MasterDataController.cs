﻿using DMS.Services.Application.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DMS.Services.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MasterDataController : Controller
    {
        private readonly IMediator _mediator;
        public MasterDataController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllMasterData")]
        public async Task<ActionResult<MasterDataListVM>> GetAllMasterData()
        {
            var result = await _mediator.Send(new MasterDataListQuery());

            return Ok(result);
        }
    }
}
