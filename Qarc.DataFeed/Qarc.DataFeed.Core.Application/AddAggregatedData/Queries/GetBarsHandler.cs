using MediatR;
using Qarc.DataFeed.Core.Application.SharedKernel;
using Qarc.DataFeed.Core.Domain.Model;

namespace Qarc.DataFeed.Core.Application.AddAggregatedData.Queries
{
    public class GetBarsHandler : IRequestHandler<GetBarsQuery, IEnumerable<Bar>>
    {
        private readonly IRepository<Bar> _repository;

        public GetBarsHandler(IRepository<Bar> repository)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<Bar>> Handle(GetBarsQuery request, CancellationToken cancellationToken)
        {
            return (IEnumerable<Bar>)await this._repository.GetAllAsync();
        }
    }
}
