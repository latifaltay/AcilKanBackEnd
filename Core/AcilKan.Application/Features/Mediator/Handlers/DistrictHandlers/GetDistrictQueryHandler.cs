using AcilKan.Application.Features.Mediator.Queries.DistrictQueries;
using AcilKan.Application.Features.Mediator.Results.DistrictResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.DistrictHandlers
{
    public class GetDistrictQueryHandler(IRepository<District> _repository) : IRequestHandler<GetDistrictQuery, List<GetDistrictQueryResult>>
    {
        public async Task<List<GetDistrictQueryResult>> Handle(GetDistrictQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetDistrictQueryResult 
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }
    }
}
