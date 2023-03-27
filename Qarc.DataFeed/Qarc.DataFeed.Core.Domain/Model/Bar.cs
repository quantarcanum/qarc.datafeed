using Qarc.DataFeed.Core.Domain.SharedKernel;

namespace Qarc.DataFeed.Core.Domain.Model
{
    public class Bar : IEntity
    {
        public string Id { get; set; }
        public BarInfo BarInfo { get; set; }
        public Instrument Instrument { get; set; }
        public Aggregation Aggregation { get; set; }

        public Bar()
        {
            this.BarInfo = new BarInfo();
            this.Instrument = new Instrument();
            this.Aggregation = new Aggregation();
        }
    }
}
