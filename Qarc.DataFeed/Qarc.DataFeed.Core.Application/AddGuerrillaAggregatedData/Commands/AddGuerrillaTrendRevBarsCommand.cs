using MediatR;
using Qarc.DataFeed.Core.Domain.Model;

namespace Qarc.DataFeed.Core.Application.AddGuerrillaAggregatedData.Commands
{
    public record class AddGuerrillaTrendRevBarsCommand(IEnumerable<GuerrillaTrendRevBar> batch) : IRequest<Unit>;
}
