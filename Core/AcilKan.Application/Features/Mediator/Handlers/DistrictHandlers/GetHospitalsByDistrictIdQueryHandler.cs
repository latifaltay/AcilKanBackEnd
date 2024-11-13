using AcilKan.Application.Features.Mediator.Queries.DistrictQueries;
using AcilKan.Application.Features.Mediator.Results.DistrictResults;
using AcilKan.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.DistrictHandlers
{
    public class GetHospitalsByDistrictIdQueryHandler(IDistrictService _districtService) : IRequestHandler<GetHospitalsByDistrictIdQuery, List<GetHospitalsByDistrictIdQueryResult>>
    {
        public async Task<List<GetHospitalsByDistrictIdQueryResult>> Handle(GetHospitalsByDistrictIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _districtService.GetAllHospitalsByDistrictIdAsync(request.Id);
            return values.Select(x => new GetHospitalsByDistrictIdQueryResult 
            {
                Id = x.Id,
                HospitalName = x.Name,
            }).ToList();
        }
    }
}
