using MediatR;
using AcilKan.Application.Features.Mediator.Results.BloodDonationResults;
using System.Collections.Generic;

namespace AcilKan.Application.Features.Mediator.Queries.BloodDonationQueries
{
    public class GetMyBloodDonationsQuery : IRequest<List<GetMyBloodDonationQueryResult>>
    {
    }
}
