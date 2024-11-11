using AcilKan.Application.Features.Mediator.Results.BloodRequestResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.BloodRequestQueries
{
    public class GetBloodRequestByIdQuery(int id) : IRequest<GetBloodRequestByIdQueryResult>
    {
        public int Id { get; set; } = id;
    }
}
