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
    public class GetBloodDonationApproveQueryHandler(IRepository<BloodDonationApprove> _repository) : IRequestHandler<GetBloodDonationApproveForAdminQuery, List<GetBloodDonationApproveForAdminQueryResult>>
    {
        public async Task<List<GetBloodDonationApproveForAdminQueryResult>> Handle(GetBloodDonationApproveForAdminQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBloodDonationApproveForAdminQueryResult 
            {
                IsDonorApproved = x.IsDonorApproved,
                IsRequestCreatorApproved = x.IsRequestCreatorApproved,
            }).ToList();
        }
    }
}
