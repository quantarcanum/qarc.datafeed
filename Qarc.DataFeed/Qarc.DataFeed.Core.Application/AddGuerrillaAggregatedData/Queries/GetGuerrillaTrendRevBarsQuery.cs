using MediatR;
using Qarc.DataFeed.Core.Domain.Model;

namespace Qarc.DataFeed.Core.Application.AddGuerrillaAggregatedData.Queries
{
    public record class GetGuerrillaTrendRevBarsQuery : IRequest<IEnumerable<GuerrillaTrendRevBar>>;
}
