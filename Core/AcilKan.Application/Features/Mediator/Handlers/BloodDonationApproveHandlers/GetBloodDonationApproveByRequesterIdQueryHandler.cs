using AcilKan.Application.Features.Mediator.Queries.BloodDontaionApproveQueries;
using AcilKan.Application.Features.Mediator.Results.BloodDonationApproveResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.BloodDonationApproveHandlers
{
    public class GetBloodDonationApproveByRequesterIdQueryHandler(IBloodDonationApproveService _service, IRepository<BloodDonationApprove> _repository) : IRequestHandler<GetBloodDonationApproveByRequesterIdQuery, List<GetBloodDonationApproveByRequesterIdQueryResult>>
    {
        public async Task<List<GetBloodDonationApproveByRequesterIdQueryResult>> Handle(GetBloodDonationApproveByRequesterIdQuery request, CancellationToken cancellationToken)
        {
            var userId = await _repository.GetCurrentUserIdAsync();
            var values = await _service.GetBloodDonationApprovesByRequesterIdAsync(userId);
            return values.Select(x => new GetBloodDonationApproveByRequesterIdQueryResult
            {
                IsRequestCreatorApproved = x.IsRequestCreatorApproved,
            }).ToList();
        }
    }
}
