using MediatR;
using Qarc.DataFeed.Core.Application.SharedKernel;
using Qarc.DataFeed.Core.Domain.Model;

namespace Qarc.DataFeed.Core.Application.AddGuerrillaAggregatedData.Queries
{
    internal class GetGuerrillaTrendRevBarByIdHandler : IRequestHandler<GetGuerrillaTrendRevBarByIdQuery, GuerrillaTrendRevBar>
    {
        private readonly IRepository<GuerrillaTrendRevBar> _repository;

        public GetGuerrillaTrendRevBarByIdHandler(IRepository<GuerrillaTrendRevBar> repository)
        {
            this._repository = repository;
        }

        public async Task<GuerrillaTrendRevBar> Handle(GetGuerrillaTrendRevBarByIdQuery request, CancellationToken cancellationToken)
        {
            return await this._repository.GetAsync(request.id);
        }
    }
}
