using Qarc.DataFeed.Core.Domain.SharedKernel;

namespace Qarc.DataFeed.Core.Domain.Model
{
    /// <summary>
    /// TODO: 
    /// Use composition Bar nested in TrendRevBar nested in GurrillaTrendRevBar
    /// Use encapsulation for domain models!
    /// Taking this shortcut for now for avoiding the need to write a custom serializer in mongo because I want all props to be store flat.
    /// </summary>
    public class GuerrillaTrendRevBar : IEntity
    {
        /// <summary>
        /// Fix this madness with composion / builder / telescopic ctors etc
        /// </summary>
        public GuerrillaTrendRevBar(string id, string instrument, string exchange, decimal tickValue, decimal tickSize, int trendTicks, int reversalTicks, DateTime time, DateTime lastTime, bool isBomb, bool isBrokenPivot, bool isPivot, decimal open, decimal high, decimal low, decimal close, decimal volume, decimal bid, decimal ask, decimal betweens, decimal ticks, decimal oI, decimal minOI, decimal maxOI, decimal delta, decimal minDelta, decimal maxDelta, PriceVolumeInfo maxTimePriceInfo, PriceVolumeInfo maxBidPriceInfo, PriceVolumeInfo maxAskPriceInfo, PriceVolumeInfo maxTickPriceInfo, PriceVolumeInfo maxVolumePriceInfo, PriceVolumeInfo maxPositiveDeltaPriceInfo, PriceVolumeInfo maxNegativeDeltaPriceInfo, IEnumerable<PriceVolumeInfo> allPriceLevels)
        {
            Id = id;
            Instrument = instrument;
            Exchange = exchange;
            TickValue = tickValue;
            TickSize = tickSize;
            TrendTicks = trendTicks;
            ReversalTicks = reversalTicks;
            Time = time;
            LastTime = lastTime;
            IsBomb = isBomb;
            IsBrokenPivot = isBrokenPivot;
            IsPivot = isPivot;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;
            Bid = bid;
            Ask = ask;
            Betweens = betweens;
            Ticks = ticks;
            OI = oI;
            MinOI = minOI;
            MaxOI = maxOI;
            Delta = delta;
            MinDelta = minDelta;
            MaxDelta = maxDelta;
            MaxTimePriceInfo = maxTimePriceInfo;
            MaxBidPriceInfo = maxBidPriceInfo;
            MaxAskPriceInfo = maxAskPriceInfo;
            MaxTickPriceInfo = maxTickPriceInfo;
            MaxVolumePriceInfo = maxVolumePriceInfo;
            MaxPositiveDeltaPriceInfo = maxPositiveDeltaPriceInfo;
            MaxNegativeDeltaPriceInfo = maxNegativeDeltaPriceInfo;
            AllPriceLevels = allPriceLevels;
        }

        public string Id { get; set; }

        public string Instrument { get; private set; }

        public string Exchange { get; private set; }

        public decimal TickValue { get; private set; }

        public decimal TickSize { get; private set; }

        public int TrendTicks { get; private set; }

        public int ReversalTicks { get; private set; }

        public DateTime Time { get; private set; }

        public DateTime LastTime { get; private set; }

        public bool IsBomb { get; private set; }

        public bool IsBrokenPivot { get; private set; }

        public bool IsPivot { get; private set; }
        public decimal Open { get; private set; }
        public decimal High { get; private set; }
        public decimal Low { get; private set; }
        public decimal Close { get; private set; }
        public decimal Volume { get; private set; }
        public decimal Bid { get; private set; }
        public decimal Ask { get; private set; }
        public decimal Betweens { get; private set; }
        public decimal Ticks { get; private set; }
        public decimal OI { get; private set; }
        public decimal MinOI { get; private set; }
        public decimal MaxOI { get; private set; }
        public decimal Delta { get; private set; }
        public decimal MinDelta { get; private set; }
        public decimal MaxDelta { get; private set; }
        public PriceVolumeInfo MaxTimePriceInfo { get; private set; }
        public PriceVolumeInfo MaxBidPriceInfo { get; private set; }
        public PriceVolumeInfo MaxAskPriceInfo { get; private set; }
        public PriceVolumeInfo MaxTickPriceInfo { get; private set; }
        public PriceVolumeInfo MaxVolumePriceInfo { get; private set; }
        public PriceVolumeInfo MaxPositiveDeltaPriceInfo { get; private set; }
        public PriceVolumeInfo MaxNegativeDeltaPriceInfo { get; private set; }
        public IEnumerable<PriceVolumeInfo> AllPriceLevels { get; private set; }
    }
}
