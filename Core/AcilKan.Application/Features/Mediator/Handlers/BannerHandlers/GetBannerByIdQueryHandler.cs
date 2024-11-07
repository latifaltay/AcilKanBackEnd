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
    public class GetBannerByIdQueryHandler(IRepository<Banner> _repository) : IRequestHandler<GetBannerByIdQuery, GetBannerByIdQueryResult>
    {
        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetBannerByIdQueryResult 
            {
                Id = value.Id,
                Description = value.Description,
                Title = value.Title,
            };
        }
    }
}
