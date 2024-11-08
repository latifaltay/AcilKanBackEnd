using AcilKan.Application.Features.Mediator.Queries.BloodDonationConditionQueries;
using AcilKan.Application.Features.Mediator.Results.BannerResults;
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
    public class GetBloodDonationConditionByIdQueryHandler(IRepository<BloodDonationCondition> _repository) : IRequestHandler<GetBloodDonationConditionByIdQuery, GetBloodDonationConditionByIdQueryResult>
    {
        public async Task<GetBloodDonationConditionByIdQueryResult> Handle(GetBloodDonationConditionByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetBloodDonationConditionByIdQueryResult
            {
                Id = value.Id,
                Title = value.Title,
            };
        }
    }
}
