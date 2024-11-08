using AcilKan.Application.Features.Mediator.Queries.SupporterQueries;
using AcilKan.Application.Features.Mediator.Results.SupporterResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.SupporterHandlers
{
    public class GetSupporterQueryHandler(IRepository<Supporter> _repository) : IRequestHandler<GetSupporterQuery, List<GetSupporterQueryResult>>
    {
        public async Task<List<GetSupporterQueryResult>> Handle(GetSupporterQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            return value.Select(x => new GetSupporterQueryResult
            {
                Id = x.Id,
                Title = x.CompanyName,
                ImageUrl = x.ImageUrl,

            }).ToList();
        }
    }
}
