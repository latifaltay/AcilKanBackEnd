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
    public class GetDonationHistoryByUserIdQueryHandler(IRepository<DonationHistory> _repository, IDonationHistoryService _service) : IRequestHandler<GetDonationHistoryByUserIdQuery, List<GetDonationHistoryByUserIdQueryResult>>
    {
        public async Task<List<GetDonationHistoryByUserIdQueryResult>> Handle(GetDonationHistoryByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userId = await _repository.GetCurrentUserIdAsync();

            var values = await _service.GetAllDonationHistoryByUserIdAsync(userId);

            return values.Select(x => new GetDonationHistoryByUserIdQueryResult 
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
