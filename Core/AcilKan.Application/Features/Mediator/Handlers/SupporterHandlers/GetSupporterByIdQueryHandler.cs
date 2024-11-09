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
    public class GetSupporterByIdQueryHandler(IRepository<Supporter> _repository) : IRequestHandler<GetSupporterByIdQuery, GetSupporterByIdQueryResult>
    {
        public async Task<GetSupporterByIdQueryResult> Handle(GetSupporterByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetSupporterByIdQueryResult
            {
                Id = value.Id,
                ImageUrl = value.ImageUrl,
                CompanyName = value.CompanyName
            };
        }
    }
}
