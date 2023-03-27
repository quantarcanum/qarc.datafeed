using AutoMapper;
using Qarc.DataFeed.Adapter.Api.InputModels;
using Qarc.DataFeed.Adapter.Api.ViewModels;
using Qarc.DataFeed.Core.Domain.Model;

namespace Qarc.DataFeed.Adapter.Api.Mapper
{
    public class BarProfile : Profile
    {
        public BarProfile()
        {
            CreateMap<AggregatedDataInputModel, Bar>();
            CreateMap<Bar, AggregatedDataViewModel>();
        }
    }
}
