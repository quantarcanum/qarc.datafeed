using Qarc.DataFeed.Core.Domain.Model;

namespace Qarc.DataFeed.Adapter.Api.InputModels
{
    public class AggregatedDataInputModel
    {
        public BarInfo BarInfo { get; set; }
        public Instrument Instrument { get; set; }
        public Aggregation Aggregation { get; set; }
    }
}
