using AcilKan.Application.Features.Mediator.Queries.BannerQueries;
using AcilKan.Application.Features.Mediator.Results.BannerResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler(IRepository<Banner> _repository) : IRequestHandler<GetBannerQuery, List<GetBannerQueryResult>>
    {
        public async Task<List<GetBannerQueryResult>> Handle(GetBannerQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();

            return values.Select(x => new GetBannerQueryResult
            {
                Id = x.Id,
                Description = x.Description,
                Title = x.Title,
            }).ToList();
        }
    }
}
