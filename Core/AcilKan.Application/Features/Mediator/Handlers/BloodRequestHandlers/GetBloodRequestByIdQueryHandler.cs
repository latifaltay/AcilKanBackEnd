using AcilKan.Application.Features.Mediator.Queries.BloodRequestQueries;
using AcilKan.Application.Features.Mediator.Results.BloodRequestResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.BloodRequestHandlers
{
    public class GetBloodRequestByIdQueryHandler(IBloodRequestService _service) : IRequestHandler<GetBloodRequestByIdQuery, GetBloodRequestByIdQueryResult>
    {

        public async Task<GetBloodRequestByIdQueryResult> Handle(GetBloodRequestByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _service.GetBloodRequestWithDetailsByIdAsync(request.Id);
            return new GetBloodRequestByIdQueryResult 
            {
                Id = value.Id,
                AppUserFullName = value.AppUser.Name + " " + value.AppUser.Surname,
                BloodGroupName = value.BloodGroup.GroupName,
                City = value.Hospital.District.City.Name,
                District = value.Hospital.District.Name,
                HospitalName = value.Hospital.Name,
                CreatedDate = value.CreatedDate,
                IsActive = value.IsActive,
                PatientFullName = value.PatientName + " " + value.PatientSurname,
            };
        }
    }
}