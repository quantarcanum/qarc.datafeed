using MediatR;
using Qarc.DataFeed.Core.Application.SharedKernel;
using Qarc.DataFeed.Core.Domain.Model;

namespace Qarc.DataFeed.Core.Application.AddAggregatedData.Commands
{
    public class AddBarsHandler : IRequestHandler<AddBarsCommand, Unit>
    {
        private readonly IRepository<Bar> _repository;

        public AddBarsHandler(IRepository<Bar> repository)
        {
            this._repository = repository;
        }

        public async Task<Unit> Handle(AddBarsCommand request, CancellationToken cancellationToken)
        {
            await this._repository.CreateManyAsync(request.batch);

            return Unit.Value;
        }
    }
}
