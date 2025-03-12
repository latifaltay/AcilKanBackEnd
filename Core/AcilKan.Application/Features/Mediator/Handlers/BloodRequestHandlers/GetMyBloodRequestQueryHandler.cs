using AcilKan.Application.DTOs.BloodDonation;
using AcilKan.Application.Extensions;
using AcilKan.Application.Features.Mediator.Queries.BloodRequestQueries;
using AcilKan.Application.Features.Mediator.Results.BloodDonationResults;
using AcilKan.Application.Features.Mediator.Results.BloodRequestResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using AcilKan.Domain.Enums;
using MediatR;

namespace AcilKan.Application.Features.Mediator.Handlers.BloodRequestHandlers
{
    public class GetMyBloodRequestQueryHandler : IRequestHandler<GetMyBloodRequestQuery, List<GetBloodRequestQueryWithDonorsResult>>
    {
        private readonly IBloodRequestService _service;
        private readonly IRepository<BloodRequest> _repository;
        public GetMyBloodRequestQueryHandler(IBloodRequestService service, IRepository<BloodRequest> repository )
        {
            _service = service;
            _repository = repository;
        }

        public async Task<List<GetBloodRequestQueryWithDonorsResult>> Handle(GetMyBloodRequestQuery request, CancellationToken cancellationToken)
        {
            var userId = await _repository.GetCurrentUserIdAsync();
            if (userId == 0)
                throw new Exception("Kullanıcı kimliği alınamadı.");

            var values = await _service.GetBloodRequestsByUserIdAsync(userId);
            if (values == null || !values.Any())
                return new List<GetBloodRequestQueryWithDonorsResult>(); // Boş liste döndür

            return values.Select(x => new GetBloodRequestQueryWithDonorsResult
            {
                RequestId = x.Id,
                RequesterId = x.RequesterId,
                HospitalId = x.HospitalId,
                RequesterFullName = x.AppUser != null ? $"{x.AppUser.Name} {x.AppUser.Surname}" : "Bilinmiyor",
                IsIndependentDonation = x.IsIndependentDonation,
                BloodGroupName = x.BloodGroup.GetDescription(),
                RequiredUnits = x.RequiredUnits,
                PatientFullName = $"{x.PatientName} {x.PatientSurname}",
                RequestDate = x.RequestDate,
                ExpiryDate = x.ExpiryDate,
                HospitalName = x.Hospital?.Name ?? "Bilinmiyor",
                City = x.Hospital?.District?.City?.Name ?? "Bilinmiyor",
                District = x.Hospital?.District?.Name ?? "Bilinmiyor",
                Donations = x.Donations != null
            ? x.Donations
                .Where(d => d.IsActive) // **IsActive == true olmayanları filtrele**
                .Select(d => new GetDonorForRequester
                {
                    BloodDonationId = d.Id,
                        DonorId=d.DonorId,
                        DonorFullName = d.Donor != null ? $"{d.Donor.Name} {d.Donor.Surname}" : "Bilinmiyor",
                        UnitsDonated = d.UnitsDonated,
                        RequestedDonationDate = d.RequestedDonationDate,
                        ArrivalDate = d.ArrivalDate,
                        DonationCompletionDate = d.DonationCompletionDate,
                        ApprovalDate = d.ApprovalDate,
                        Status = d.Status.ToString(),
                        RejectedReason = d.RejectedReason,
                    }).ToList()
                    : new List<GetDonorForRequester>()
            }).ToList();
        }

    }

}
