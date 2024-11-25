using AcilKan.Application.Features.Mediator.Results.BloodDonationResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.BloodDonationQueries
{
    public class GetBloodDonationByDonorIdQuery(int id) : IRequest<List<GetBloodDonationByDonorIdQueryResult>>
    {
        public int Id { get; set; } = id;
    }
}
