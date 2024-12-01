using AcilKan.Application.Features.Mediator.Results.BloodRequestResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.BloodRequestQueries
{
    public class GetChatByBloodRequestIdQuery(int bloodRequestId) : IRequest<GetChatByBloodRequestIdQueryResult>
    {
        public int BloodRequestId { get; set; } = bloodRequestId;
    }
}
