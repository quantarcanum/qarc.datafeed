using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qarc.DataFeed.Adapter.Api.ViewModels;
using Qarc.DataFeed.Core.Application.AddGuerrillaAggregatedData.Queries;

namespace Qarc.DataFeed.Adapter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtasAggregatedDataController : ControllerBase
    {
        [HttpGet(Name = "test")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok("test succedded");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
