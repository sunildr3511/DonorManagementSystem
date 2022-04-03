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
    public class BudgetController : Controller
    {
        private readonly IMediator _mediator;
        public BudgetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add", Name = "AddBudget")]
        public async Task<ActionResult> AddKindDonor([FromBody] BudgetCreateCommand  budgetCreateCommand)
        {
             await _mediator.Send(budgetCreateCommand);

            return NoContent();
        }
    }
}
