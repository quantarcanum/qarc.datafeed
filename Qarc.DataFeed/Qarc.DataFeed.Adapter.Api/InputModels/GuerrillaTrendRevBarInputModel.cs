using Qarc.DataFeed.Core.Domain.Model;

namespace Qarc.DataFeed.Adapter.Api.InputModels
{
    public class GuerrillaTrendRevBarInputModel
    {
        public string Instrument { get; set; }
        public string Exchange { get; set; }
        public decimal TickValue { get; set; }
        public decimal TickSize { get; set; }
        public int TrendTicks { get; set; }
        public int ReversalTicks { get; set; }
        public DateTime Time { get; set; }
        public DateTime LastTime { get; set; }
        public bool IsBomb { get; set; }
        public bool IsBrokenPivot { get; set; }
        public bool IsPivot { get; set; }
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
}
