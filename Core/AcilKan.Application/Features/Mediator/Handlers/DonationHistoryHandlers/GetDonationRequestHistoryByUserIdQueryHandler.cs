using AcilKan.Application.Features.Mediator.Queries.DonationHistoryQueries;
using AcilKan.Application.Features.Mediator.Results.DonationHistoryResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.DonationHistoryHandlers
{
    public class GetDonationRequestHistoryByUserIdQueryHandler(IRepository<BloodDontaion> _repository, IDonationHistoryService _service) : IRequestHandler<GetDonationRequestHistoryByUserIdQuery, List<GetDonationRequestHistoryByUserIdQueryResult>>
    {
        public async Task<List<GetDonationRequestHistoryByUserIdQueryResult>> Handle(GetDonationRequestHistoryByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userId = await _repository.GetCurrentUserIdAsync();

            var values = await _service.GetRequestDonationsByUserIdAsync(userId);

            return values.Select(x => new GetDonationRequestHistoryByUserIdQueryResult
            {
                Id = x.Id,
                PatientFullName = x.PatientName + ' ' + x.PatientSurname,
                CreatedDate = x.DonationDate,
                Location = x.Hospital.Name,
                Status = x.DonationStatus.Status,
            }).ToList();
        }
    }
}
