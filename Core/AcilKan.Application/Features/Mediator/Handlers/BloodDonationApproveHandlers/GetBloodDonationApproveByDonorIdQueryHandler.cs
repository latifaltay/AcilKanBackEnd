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
    public class GetBloodDonationApproveByDonorIdQueryHandler(IBloodDonationApproveService _service, IRepository<BloodDonationApprove> _repository) : IRequestHandler<GetBloodDonationApproveByDonorIdQuery, List<GetBloodDonationApproveByDonorIdQueryResult>>
    {
        public async Task<List<GetBloodDonationApproveByDonorIdQueryResult>> Handle(GetBloodDonationApproveByDonorIdQuery request, CancellationToken cancellationToken)
        {
            var donorId = await _repository.GetCurrentUserIdAsync();
            var values = await _service.GetBloodDonationApprovesByDonorIdAsync(donorId);
            return values.Select(x => new GetBloodDonationApproveByDonorIdQueryResult 
            {
                IsDonorApproved = x.IsDonorApproved,
            }).ToList();
        }
    }
}
