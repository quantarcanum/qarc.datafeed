using MediatR;
using Qarc.DataFeed.Core.Application.SharedKernel;
using Qarc.DataFeed.Core.Domain.Model;

namespace Qarc.DataFeed.Core.Application.AddAggregatedData.Commands
{
    public class AddBarHandler : IRequestHandler<AddBarCommand, Bar>
    {
        private readonly IRepository<Bar> _repository;

        public AddBarHandler(IRepository<Bar> repository)
        {
            this._repository = repository;
        }

        public async Task<Bar> Handle(AddBarCommand request, CancellationToken cancellationToken)
        {
            await this._repository.CreateAsync(request.model);

            return request.model;
        }
    }
}
