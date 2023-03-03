using MediatR;
using Qarc.DataFeed.Core.Application.SharedKernel;
using Qarc.DataFeed.Core.Domain.Model;

namespace Qarc.DataFeed.Core.Application.AddGuerrillaAggregatedData.Commands
{
    public class AddGuerrillaTrendRevBarHandler : IRequestHandler<AddGuerrillaTrendRevBarCommand, GuerrillaTrendRevBar>
    {
        private readonly IRepository<GuerrillaTrendRevBar> _repository;

        public AddGuerrillaTrendRevBarHandler(IRepository<GuerrillaTrendRevBar> repository)
        {
            this._repository = repository;
        }

        public async Task<GuerrillaTrendRevBar> Handle(AddGuerrillaTrendRevBarCommand request, CancellationToken cancellationToken)
        {
            await this._repository.CreateAsync(request.model);

            return request.model;
        }
    }
}
