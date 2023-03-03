using MediatR;
using Qarc.DataFeed.Core.Domain.Model;

namespace Qarc.DataFeed.Core.Application.AddGuerrillaAggregatedData.Queries
{
    public record class GetGuerrillaTrendRevBarByIdQuery(string id) : IRequest<GuerrillaTrendRevBar>;
}
