using AcilKan.Application.Features.Mediator.Queries.DonationBenefitQueries;
using AcilKan.Application.Features.Mediator.Results.DonationBenefitResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.DonationBenefitHandlers
{
    public class GetDonationBenefitByIdQueryHandler(IRepository<DonationBenefit> _repository) : IRequestHandler<GetDonationBenefitByIdQuery, GetDonationBenefitByIdQueryResult>
    {
        public async Task<GetDonationBenefitByIdQueryResult> Handle(GetDonationBenefitByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetDonationBenefitByIdQueryResult 
            {
                Id = value.Id,
                Title = value.Title,
                Article = value.Article,
            };
        }
    }
}
