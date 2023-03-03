using AutoMapper;
using Qarc.DataFeed.Adapter.Api.InputModels;
using Qarc.DataFeed.Adapter.Api.ViewModels;
using Qarc.DataFeed.Core.Domain.Model;

namespace Qarc.DataFeed.Adapter.Api.Mapper
{
    public class GuerrillaTrendRevBarProfile : Profile
    {
        public GuerrillaTrendRevBarProfile()
        {
            CreateMap<GuerrillaTrendRevBarInputModel, GuerrillaTrendRevBar>()
                .ConstructUsing(x => new GuerrillaTrendRevBar(string.Empty, x.Instrument, x.Exchange, x.TickValue, x.TickSize, x.TrendTicks, x.ReversalTicks, x.Time, x.LastTime,
                x.IsBomb, x.IsBrokenPivot, x.IsPivot, x.Open, x.High, x.Low, x.Close, x.Volume, x.Bid, x.Ask, x.Betweens, x.Ticks, x.OI, x.MinOI, x.MaxOI, x.Delta, x.MinDelta, x.MaxDelta, 
                x.MaxTimePriceInfo, 
                x.MaxBidPriceInfo,
                x.MaxAskPriceInfo, 
                x.MaxTickPriceInfo, 
                x.MaxVolumePriceInfo, 
                x.MaxPositiveDeltaPriceInfo, 
                x.MaxNegativeDeltaPriceInfo, 
                x.AllPriceLevels));
            CreateMap<GuerrillaTrendRevBar, GuerrillaTrendRevBarViewModel>();
        }
    }
}
