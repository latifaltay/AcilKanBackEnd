using AcilKan.Application.Features.Mediator.Results.DistrictResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.DistrictQueries
{
    public class GetHospitalsByDistrictIdQuery(int id) : IRequest<List<GetHospitalsByDistrictIdQueryResult>>
    {
        public int Id { get; set; } = id;
    }
}
