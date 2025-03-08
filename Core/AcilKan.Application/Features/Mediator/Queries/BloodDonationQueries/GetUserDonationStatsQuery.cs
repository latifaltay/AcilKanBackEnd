using AcilKan.Application.Features.Mediator.Results.BloodDonationResults;
using MediatR;

namespace AcilKan.Application.Features.Mediator.Queries.BloodDonationQueries
{
    public class GetUserDonationStatsQuery : IRequest<GetUserDonationStatsQueryResult>
    {
        public int UserId { get; set; }
    }
}
