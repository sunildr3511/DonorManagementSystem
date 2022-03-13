using DMS.Services.Application.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DMS.Services.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CentreDataController : Controller
    {
        private readonly IMediator _mediator;
        public CentreDataController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("locationId", Name = "GetCentresByLocation")]
        public async Task<ActionResult<CentreDataVM>> GetCentresByLocation([FromQuery] int locationId)
        {
            var result = await _mediator.Send(new CentreDataListQuery { Id = locationId });

            return Ok(result);
        }
    }
}
