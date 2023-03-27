using MediatR;
using Qarc.DataFeed.Core.Application.SharedKernel;
using Qarc.DataFeed.Core.Domain.Model;

namespace Qarc.DataFeed.Core.Application.AddAggregatedData.Queries
{
    internal class GetBarByIdHandler : IRequestHandler<GetBarByIdQuery, Bar>
    {
        private readonly IRepository<Bar> _repository;

        public GetBarByIdHandler(IRepository<Bar> repository)
        {
            this._repository = repository;
        }

        public async Task<Bar> Handle(GetBarByIdQuery request, CancellationToken cancellationToken)
        {
            return await this._repository.GetAsync(request.id);
        }
    }
}
