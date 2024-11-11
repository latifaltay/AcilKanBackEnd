using AcilKan.Application.Features.Mediator.Queries.CityQueries;
using AcilKan.Application.Features.Mediator.Results.CityResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.CityHandlers
{
    public class GetDistrictsByCityIdQueryHandler(ICityService _cityRepository) : IRequestHandler<GetDistrictsByCityIdQuery, List<GetDistrictsByCityIdQueryResult>>
    {
        public async Task<List<GetDistrictsByCityIdQueryResult>> Handle(GetDistrictsByCityIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _cityRepository.GetAllDistrictsByCityIdAsync(request.Id);
            return values.Select(x => new GetDistrictsByCityIdQueryResult 
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }
    }
}
