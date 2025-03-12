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
    public class GetBloodRequestQueryHandler(IBloodRequestService _service)
        : IRequestHandler<GetBloodRequestQuery, List<GetBloodRequestQueryResult>>
    {
        public async Task<List<GetBloodRequestQueryResult>> Handle(GetBloodRequestQuery request, CancellationToken cancellationToken)
        {
            var values = await _service.GetBloodRequestsAsync();

            var filteredRequests = values
                .Select(x => new
                {
                    BloodRequest = x,
                    AdjustedRequiredUnits = x.RequiredUnits - x.Donations
                        .Where(d => (d.Status == BloodDonationStatus.CompletedByDonor || d.Status == BloodDonationStatus.ApprovedByRequester) && d.IsActive)
                        .Sum(d => d.UnitsDonated ?? 0) // Aktif bağış yapılan üniteyi düş
                })
                .Where(x => x.AdjustedRequiredUnits > 0) // 0 veya altına düşenleri filtrele
                .Select(x => new GetBloodRequestQueryResult
                {
                    RequestId = x.BloodRequest.Id,
                    RequesterId = x.BloodRequest.RequesterId,
                    HospitalId = x.BloodRequest.HospitalId,
                    RequesterFullName = $"{x.BloodRequest.AppUser.Name} {x.BloodRequest.AppUser.Surname}",
                    IsIndependentDonation = x.BloodRequest.IsIndependentDonation,
                    BloodGroupName = x.BloodRequest.BloodGroup.GetDescription(),
                    RequiredUnits = x.AdjustedRequiredUnits, // Güncellenmiş RequiredUnits kullanılıyor
                    PatientFullName = $"{x.BloodRequest.PatientName} {x.BloodRequest.PatientSurname}",
                    RequestDate = x.BloodRequest.RequestDate,
                    HospitalName = x.BloodRequest.Hospital.Name,
                    City = x.BloodRequest.Hospital.District.City.Name,
                    District = x.BloodRequest.Hospital.District.Name
                })
                .ToList();

      
            return filteredRequests;
        }

    }
}
