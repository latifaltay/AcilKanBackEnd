using AcilKan.Application.Features.Mediator.Results.BloodDonationConditionResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.BloodDonationConditionQueries
{
    public class GetBloodDonationConditionByIdQuery(int id) : IRequest<GetBloodDonationConditionByIdQueryResult>
    {
        public int Id { get; set; } = id;
    }
}
