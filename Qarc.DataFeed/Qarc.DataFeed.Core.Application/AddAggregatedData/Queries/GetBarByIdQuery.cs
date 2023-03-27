using MediatR;
using Qarc.DataFeed.Core.Domain.Model;

namespace Qarc.DataFeed.Core.Application.AddAggregatedData.Queries
{
    public record class GetBarByIdQuery(string id) : IRequest<Bar>;
}
