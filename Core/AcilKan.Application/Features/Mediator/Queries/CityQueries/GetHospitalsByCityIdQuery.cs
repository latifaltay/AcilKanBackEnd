using AcilKan.Application.Features.Mediator.Results.CityResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.CityQueries
{
    public class GetHospitalsByCityIdQuery(int id) : IRequest<List<GetHospitalsByCityIdQueryResult>>
    {
        public int Id { get; set; } = id;
    }
}
