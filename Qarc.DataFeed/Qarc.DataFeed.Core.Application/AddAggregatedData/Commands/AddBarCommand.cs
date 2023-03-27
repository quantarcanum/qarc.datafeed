using MediatR;
using Qarc.DataFeed.Core.Domain.Model;

namespace Qarc.DataFeed.Core.Application.AddAggregatedData.Commands
{
    public record class AddBarCommand(Bar model) : IRequest<Bar>;
}
