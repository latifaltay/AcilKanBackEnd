using AcilKan.Application.Features.Mediator.Queries.BloodDonationQueries;
using AcilKan.Application.Features.Mediator.Results.BloodDonationResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.BloodDontaionHandlers
{
    public class GetBloodDonationQueryHandler(IBloodDonationService _service, IRepository<BloodDonation> _repository) : IRequestHandler<GetBloodDonationQuery, List<GetBloodDonationQueryResult>>
    {
        public async Task<List<GetBloodDonationQueryResult>> Handle(GetBloodDonationQuery request, CancellationToken cancellationToken)
        {
            var values = await _service.GetBloodDonationsAsync();
            var userId = await _repository.GetCurrentUserIdAsync();
            return values.Select(x => new GetBloodDonationQueryResult
            {
                Id = x.Id,
                DonationCompletionDate = x.DonationCompletionDate ?? null, 
                DonorFullName = $"{x.Donor.Name} {x.Donor.Surname}",
                HospitalName = x.BloodRequest.Hospital.Name,
                PatientFullName = $"{x.BloodRequest.PatientName} {x.BloodRequest.PatientSurname}",
                RequesterFullName = $"{x.BloodRequest.AppUser.Name} {x.BloodRequest.AppUser.Surname}",
                Status = x.Status.ToString(), // ✅ Enum string olarak atanmalı
            }).ToList();
        }
    }
}
