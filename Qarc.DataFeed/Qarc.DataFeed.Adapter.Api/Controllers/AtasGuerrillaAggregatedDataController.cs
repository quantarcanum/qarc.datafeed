using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Qarc.DataFeed.Adapter.Api.InputModels;
using Qarc.DataFeed.Adapter.Api.ViewModels;
using Qarc.DataFeed.Core.Application.AddGuerrillaAggregatedData.Commands;
using Qarc.DataFeed.Core.Application.AddGuerrillaAggregatedData.Queries;
using Qarc.DataFeed.Core.Domain.Model;

namespace Qarc.DataFeed.Adapter.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AtasGuerrillaAggregatedDataController : ControllerBase
    {
        private readonly ILogger<AtasGuerrillaAggregatedDataController> _logger;
        private readonly ISender _senderMediator;
        private readonly IMapper _mapper;

        public AtasGuerrillaAggregatedDataController(ILogger<AtasGuerrillaAggregatedDataController> logger, ISender senderMediator, IMapper mapper)
        {
            _logger = logger;
            _senderMediator = senderMediator;
            _mapper = mapper;
        }

        [HttpPost(Name = "GuerrillaDataBatch"), DisableRequestSizeLimit, RequestFormLimits(MultipartBodyLengthLimit = Int32.MaxValue, ValueLengthLimit = Int32.MaxValue)]
        public async Task<IActionResult> PostBatch([FromBody] IEnumerable<GuerrillaTrendRevBarInputModel> values)
        {
            try
            {
                var models = this._mapper.Map<IEnumerable<GuerrillaTrendRevBar>>(values);
                var result = await this._senderMediator.Send(new AddGuerrillaTrendRevBarsCommand(models));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " " + ex.StackTrace);
            }
        }

        [HttpPost(Name = "GuerrillaData")]
        public async Task<IActionResult> Post([FromBody] GuerrillaTrendRevBarInputModel value)
        {
            try
            {
                var model = this._mapper.Map<GuerrillaTrendRevBar>(value);
                var result = await this._senderMediator.Send(new AddGuerrillaTrendRevBarCommand(model));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " " + ex.StackTrace);
            }
        }

        [HttpGet(Name = "GetGuerrillaBars")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await this._senderMediator.Send(new GetGuerrillaTrendRevBarsQuery());

                if (result == null)
                {
                    return NotFound();
                }

                var viewModel = this._mapper.Map<IEnumerable<GuerrillaTrendRevBarViewModel>>(result);

                return Ok(viewModel);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }


}
