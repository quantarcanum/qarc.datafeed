using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Qarc.DataFeed.Adapter.Api.InputModels;
using Qarc.DataFeed.Adapter.Api.ViewModels;
using Qarc.DataFeed.Core.Application.AddAggregatedData.Commands;
using Qarc.DataFeed.Core.Application.AddAggregatedData.Queries;
using Qarc.DataFeed.Core.Domain.Model;

namespace Qarc.DataFeed.Adapter.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AtasAggregatedDataController : ControllerBase
    {
        private readonly ILogger<AtasAggregatedDataController> _logger;
        private readonly ISender _senderMediator;
        private readonly IMapper _mapper;

        public AtasAggregatedDataController(ILogger<AtasAggregatedDataController> logger, ISender senderMediator, IMapper mapper)
        {
            _logger = logger;
            _senderMediator = senderMediator;
            _mapper = mapper;
        }

        [HttpPost(Name = "AggregatedDataBatch"), DisableRequestSizeLimit, RequestFormLimits(MultipartBodyLengthLimit = Int32.MaxValue, ValueLengthLimit = Int32.MaxValue)]
        public async Task<IActionResult> PostBatch([FromBody] IEnumerable<AggregatedDataInputModel> values)
        {
            try
            {
                var models = this._mapper.Map<IEnumerable<Bar>>(values);
                var result = await this._senderMediator.Send(new AddBarsCommand(models));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " " + ex.StackTrace);
            }
        }

        [HttpPost(Name = "AggregatedData")]
        public async Task<IActionResult> Post([FromBody] AggregatedDataInputModel value)
        {
            try
            {
                var model = this._mapper.Map<Bar>(value);
                var result = await this._senderMediator.Send(new AddBarCommand(model));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " " + ex.StackTrace);
            }
        }

        [HttpGet(Name = "GetBars")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await this._senderMediator.Send(new GetBarsQuery());

                if (result == null)
                {
                    return NotFound();
                }

                var viewModel = this._mapper.Map<IEnumerable<AggregatedDataViewModel>>(result);

                return Ok(viewModel);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
