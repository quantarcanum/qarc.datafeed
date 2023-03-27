using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qarc.DataFeed.Core.Domain.Model
{
    public class BarInfo
    {
        public DateTime Time { get; set; }
        public DateTime LastTime { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal Volume { get; set; }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
        public decimal Betweens { get; set; }
        public decimal Ticks { get; set; }
        public decimal OI { get; set; }
        public decimal MinOI { get; set; }
        public decimal MaxOI { get; set; }
        public decimal Delta { get; set; }
        public decimal MinDelta { get; set; }
        public decimal MaxDelta { get; set; }

        public PriceVolumeInfo MaxTimePriceInfo { get; set; }
        public PriceVolumeInfo MaxBidPriceInfo { get; set; }
        public PriceVolumeInfo MaxAskPriceInfo { get; set; }
        public PriceVolumeInfo MaxTickPriceInfo { get; set; }
        public PriceVolumeInfo MaxVolumePriceInfo { get; set; }
        public PriceVolumeInfo MaxPositiveDeltaPriceInfo { get; set; }
        public PriceVolumeInfo MaxNegativeDeltaPriceInfo { get; set; }
        public IEnumerable<PriceVolumeInfo> AllPriceLevels { get; set; }
    }

    public class PriceVolumeInfo
    {
        public decimal Volume { get; set; }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
        public int Ticks { get; set; }
        public decimal Between { get; set; }
        public int Time { get; set; }
        public decimal Price { get; set; }
    }

}
