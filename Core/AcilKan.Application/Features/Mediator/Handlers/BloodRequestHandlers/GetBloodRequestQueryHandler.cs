using AcilKan.Application.Extensions;
using AcilKan.Application.Features.Mediator.Queries.BloodRequestQueries;
using AcilKan.Application.Features.Mediator.Results.BloodRequestResults;
using AcilKan.Application.Interfaces;
using MediatR;

namespace AcilKan.Application.Features.Mediator.Handlers.BloodRequestHandlers
{
    public class GetBloodRequestQueryHandler(IBloodRequestService _service)
        : IRequestHandler<GetBloodRequestQuery, List<GetBloodRequestQueryResult>>
    {
        public async Task<List<GetBloodRequestQueryResult>> Handle(GetBloodRequestQuery request, CancellationToken cancellationToken)
        {
            var values = await _service.GetBloodRequestsAsync();

            return values.Select(x => new GetBloodRequestQueryResult
            {
                Id = x.Id,
                AppUserFullName = $"{x.AppUser.Name} {x.AppUser.Surname}", // ✅ Daha okunaklı string formatlama
                BloodGroupName = x.BloodGroup.GetDescription(), // ✅ Enum description almak için
                City = x.Hospital.District.City.Name,
                District = x.Hospital.District.Name,
                HospitalName = x.Hospital.Name,
                CreatedDate = x.RequestDate,
                IsActive = x.IsActive,
                PatientFullName = $"{x.PatientName} {x.PatientSurname}",
                Status = x.Status.ToString(), // ✅ Enum string'e çevrildi
            }).ToList();
        }
    }
}
