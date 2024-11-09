using AcilKan.Application.Features.Mediator.Results.MissionResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.MissionQueries
{
    public class GetMissionByIdQuery(int id) : IRequest<GetMissionByIdQueryResult>
    {
        public int Id { get; set; } = id;
    }
}
