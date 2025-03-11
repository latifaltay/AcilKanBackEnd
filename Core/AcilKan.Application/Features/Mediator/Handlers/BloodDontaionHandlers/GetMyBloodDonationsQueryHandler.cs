using AcilKan.Application.Features.Mediator.Queries.BloodDonationQueries;
using AcilKan.Application.Features.Mediator.Results.BloodDonationResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;

namespace AcilKan.Application.Features.Mediator.Handlers.BloodDontaionHandlers
{
    public class GetMyBloodDonationQueryHandler(IBloodDonationService _bloodDonationService, IRepository<BloodDonation> _repository) : IRequestHandler<GetMyBloodDonationsQuery, List<GetMyBloodDonationQueryResult>>
    {

        public async Task<List<GetMyBloodDonationQueryResult>> Handle(GetMyBloodDonationsQuery request, CancellationToken cancellationToken)
        {
            var userId = await _repository.GetCurrentUserIdAsync();
            var values = await _bloodDonationService.GetMyBloodDonationsAsync(userId);



            return values.Select(x => new GetMyBloodDonationQueryResult
            {
                Id = x.Id,
                DonationCompletionDate = x.DonationCompletionDate ?? null,
                DonorFullName = $"{x.Donor.Name} {x.Donor.Surname}",
                HospitalName = x.BloodRequest.Hospital.Name,
                PatientFullName = $"{x.BloodRequest.PatientName} {x.BloodRequest.PatientSurname}",
                RequesterFullName = $"{x.BloodRequest.AppUser.Name} {x.BloodRequest.AppUser.Surname}",
                Status = x.Status.ToString(),
                UnitsDonated = x.UnitsDonated,

                // **Tarih Alanları**
                RequestedDonationDate = x.RequestedDonationDate,
                ArrivalDate = x.ArrivalDate,
                ApprovalDate = x.ApprovalDate,
                LastUpdatedDate = x.LastUpdatedDate,

                RejectedReason = x.RejectedReason,
                Notes = x.Notes,

                // **BloodRequest Bilgileri (Doğrudan DTO içinde alanları tek tek ekledik)**
                BloodRequestExpiryDate = x.BloodRequest.ExpiryDate, // Talebin son süresi
                BloodRequestRequiredUnits = x.BloodRequest.RequiredUnits, // Kaç ünite kan lazım?
                BloodRequestBloodGroup = x.BloodRequest.BloodGroup.ToString(), // Kan grubu
                BloodRequestCreationDate = x.BloodRequest.RequestDate // Talebin oluşturulma tarihi
            }).ToList();

        }

    }
}
