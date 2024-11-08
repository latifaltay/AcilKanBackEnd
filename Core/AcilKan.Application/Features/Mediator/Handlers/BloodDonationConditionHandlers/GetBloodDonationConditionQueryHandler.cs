using AcilKan.Application.Features.Mediator.Queries.BloodDonationConditionQueries;
using AcilKan.Application.Features.Mediator.Results.BloodDonationConditionResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.BloodDonationConditionHandlers
{
    public class GetBloodDonationConditionQueryHandler(IRepository<BloodDonationCondition> _repository) : IRequestHandler<GetBloodDonationConditionQuery, List<GetBloodDonationConditionQueryResult>>
    {
        public async Task<List<GetBloodDonationConditionQueryResult>> Handle(GetBloodDonationConditionQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBloodDonationConditionQueryResult
            {
                Id = x.Id,
                Title = x.Title,
            }).ToList();
        }
    }
}
