using MediatR;
using Qarc.DataFeed.Core.Application.SharedKernel;
using Qarc.DataFeed.Core.Domain.Model;

namespace Qarc.DataFeed.Core.Application.AddGuerrillaAggregatedData.Commands
{
    public class AddGuerrillaTrendRevBarsHandler : IRequestHandler<AddGuerrillaTrendRevBarsCommand, Unit>
    {
        private readonly IRepository<GuerrillaTrendRevBar> _repository;

        public AddGuerrillaTrendRevBarsHandler(IRepository<GuerrillaTrendRevBar> repository)
        {
            this._repository = repository;
        }

        public async Task<Unit> Handle(AddGuerrillaTrendRevBarsCommand request, CancellationToken cancellationToken)
        {
            await this._repository.CreateManyAsync(request.batch);

            return Unit.Value;
        }
    }
}
