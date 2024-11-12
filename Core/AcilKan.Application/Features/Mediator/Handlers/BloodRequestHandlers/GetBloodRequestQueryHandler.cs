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
    public class GetBloodRequestQueryHandler(IRepository<BloodRequest> _repository) : IRequestHandler<GetBloodRequestQuery, List<GetBloodRequestQueryResult>>
    {
        public async Task<List<GetBloodRequestQueryResult>> Handle(GetBloodRequestQuery request, CancellationToken cancellationToken)
        {

            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBloodRequestQueryResult
            {
                Id = x.Id,
                AppUserId = x.AppUserId,
                BloodGroupId = x.BloodGroupId,
                CreatedDate = x.CreatedDate,
                HospitalId = x.HospitalId,
                IsActive = x.IsActive,
                PatientName = x.PatientName,
                PatientSurname = x.PatientSurname,
            }).ToList();
        }
    }
}
