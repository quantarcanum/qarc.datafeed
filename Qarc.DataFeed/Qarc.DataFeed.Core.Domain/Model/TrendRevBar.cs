using Qarc.DataFeed.Core.Domain.SharedKernel;

namespace Qarc.DataFeed.Core.Domain.Model
{
    public class TrendRevBar : IEntity
    {
        public string Id { get; set; }
        public Bar Bar { get; set; }
        public int TrendTicks { get; set; }
        public int ReversalTicks { get; set; }
    }
}
