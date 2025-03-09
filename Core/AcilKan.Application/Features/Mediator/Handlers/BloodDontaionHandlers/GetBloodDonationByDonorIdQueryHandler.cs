using AcilKan.Application.Features.Mediator.Queries.BloodDonationQueries;
using AcilKan.Application.Features.Mediator.Results.BloodDonationResults;
using AcilKan.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.BloodDontaionHandlers
{
    public class GetBloodDonationByDonorIdQueryHandler(IBloodDonationService _service) : IRequestHandler<GetBloodDonationByDonorIdQuery, List<GetBloodDonationByDonorIdQueryResult>>
    {
        public async Task<List<GetBloodDonationByDonorIdQueryResult>> Handle(GetBloodDonationByDonorIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _service.GetBloodDonationsByDonorIdAsync(request.Id);

            return values.Select(x => new GetBloodDonationByDonorIdQueryResult
            {
                Id = x.Id,
                DonationDate = x.DonationCompletionDate ?? null, 
                DonorFullName = $"{x.Donor.Name} {x.Donor.Surname}", 
                HospitalName = x.BloodRequest.Hospital.Name,
                PatientFullName = $"{x.BloodRequest.PatientName} {x.BloodRequest.PatientSurname}",
                RequesterFullName = $"{x.BloodRequest.AppUser.Name} {x.BloodRequest.AppUser.Surname}",
                Status = x.Status.ToString(), 
            }).ToList();

        }
    }
}
