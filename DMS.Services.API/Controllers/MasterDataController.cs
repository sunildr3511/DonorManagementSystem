using DMS.Services.Application.Features;
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

        [HttpPost("add", Name = "AddMasterData")]
        public async Task<ActionResult> AddMasterData([FromBody] MasterDataCreateCommand masterDataCreateCommand)
        {
            await _mediator.Send(masterDataCreateCommand);

            return NoContent();
        }

        [HttpPut("update", Name = "UpdateMasterData")]
        public async Task<ActionResult> UpdateMasterData([FromBody] MasterDataUpdateCommand masterDataUpdateCommand)
        {
            await _mediator.Send(masterDataUpdateCommand);

            return NoContent();
        }

        [HttpDelete("delete", Name = "DeleteMasterData")]
        public async Task<ActionResult> DeleteMasterData(int id)
        {
            await _mediator.Send(new MasterDataDeleteCommand { Id = id });

            return NoContent();
        }

    }
}
