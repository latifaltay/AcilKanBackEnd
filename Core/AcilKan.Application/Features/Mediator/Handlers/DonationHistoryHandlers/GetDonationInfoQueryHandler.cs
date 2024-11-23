using AcilKan.Application.Features.Mediator.Queries.DonationHistoryQueries;
using AcilKan.Application.Features.Mediator.Results.DonationHistoryResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.DonationHistoryHandlers
{
    public class GetDonationInfoQueryHandler(IDonationHistoryService _service, IRepository<BloodDontaion> _repository) : IRequestHandler<GetDonationInfoQuery, GetDonationInfoQueryResult>
    {
        public async Task<GetDonationInfoQueryResult> Handle(GetDonationInfoQuery request, CancellationToken cancellationToken)
        {
            var userId = await _repository.GetCurrentUserIdAsync();

            var (totalDonations, lastDonationDate) = await _service.GetDonationInfoByUserIdAsync(userId);

            var nextDonationDate = lastDonationDate.HasValue ? lastDonationDate.Value.AddMonths(3) : (DateTime?)null;

            return new GetDonationInfoQueryResult
            {
                TotalDonation = totalDonations,
                LastDonationDate = lastDonationDate ?? DateTime.MinValue,
                NextDonationDate = nextDonationDate ?? DateTime.MinValue
            };
        }
    }
}
