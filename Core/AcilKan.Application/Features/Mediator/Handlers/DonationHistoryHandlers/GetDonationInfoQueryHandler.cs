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
    public class GetDonationInfoQueryHandler(IDonationHistoryService _service, IRepository<DonationHistory> _repository) : IRequestHandler<GetDonationInfoQuery, GetDonationInfoQueryResult>
    {
        //public async Task<GetDonationInfoQueryResult> Handle(GetDonationInfoQuery request, CancellationToken cancellationToken)
        //{
        //    var userId = await _repository.GetCurrentUserIdAsync();

        //    var value = await _service.GetAllDonationHistoryByUserIdAsync(userId);

        //    return new GetDonationInfoQueryResult 
        //    {
        //        TotalDonation = value.TotalDonations,
        //        LastDonationDate = value.
        //    };

        //}
        public Task<GetDonationInfoQueryResult> Handle(GetDonationInfoQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
