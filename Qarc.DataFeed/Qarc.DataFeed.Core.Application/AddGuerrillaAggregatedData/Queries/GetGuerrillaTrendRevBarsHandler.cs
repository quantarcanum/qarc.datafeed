using MediatR;
using Qarc.DataFeed.Core.Application.SharedKernel;
using Qarc.DataFeed.Core.Domain.Model;

namespace Qarc.DataFeed.Core.Application.AddGuerrillaAggregatedData.Queries
{
    public class GetGuerrillaTrendRevBarsHandler : IRequestHandler<GetGuerrillaTrendRevBarsQuery, IEnumerable<GuerrillaTrendRevBar>>
    {
        private readonly IRepository<GuerrillaTrendRevBar> _repository;

        public GetGuerrillaTrendRevBarsHandler(IRepository<GuerrillaTrendRevBar> repository)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<GuerrillaTrendRevBar>> Handle(GetGuerrillaTrendRevBarsQuery request, CancellationToken cancellationToken)
        {
            return (IEnumerable<GuerrillaTrendRevBar>)await this._repository.GetAllAsync();
        }
    }
}
