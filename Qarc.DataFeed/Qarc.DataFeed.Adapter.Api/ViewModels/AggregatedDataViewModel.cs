using Qarc.DataFeed.Core.Domain.Model;

namespace Qarc.DataFeed.Adapter.Api.ViewModels
{
    public class AggregatedDataViewModel
    {
        public string Id { get; set; }
        public BarInfo BarInfo { get; set; }
        public Instrument Instrument { get; set; }
        public Aggregation Aggregation { get; set; }
    }
}
