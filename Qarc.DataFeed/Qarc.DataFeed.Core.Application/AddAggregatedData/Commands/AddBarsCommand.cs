using MediatR;
using Qarc.DataFeed.Core.Domain.Model;

namespace Qarc.DataFeed.Core.Application.AddAggregatedData.Commands
{
    public record class AddBarsCommand(IEnumerable<Bar> batch) : IRequest<Unit>;
}
