using AcilKan.Application.Features.Mediator.Queries.CityQueries;
using AcilKan.Application.Features.Mediator.Results.CityResults;
using AcilKan.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.CityHandlers
{
    public class GetHospitalsByCityIdQueryHandler(ICityRepository _cityRepository) : IRequestHandler<GetHospitalsByCityIdQuery, List<GetHospitalsByCityIdQueryResult>>
    {
        public async Task<List<GetHospitalsByCityIdQueryResult>> Handle(GetHospitalsByCityIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _cityRepository.GetAllHospitalsByCityIdAsync(request.Id);
            return values.Select(x => new GetHospitalsByCityIdQueryResult
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }
    }
}
