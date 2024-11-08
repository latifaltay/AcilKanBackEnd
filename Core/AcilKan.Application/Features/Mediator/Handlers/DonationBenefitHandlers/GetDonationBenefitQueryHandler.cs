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
    public class GetDonationBenefitQueryHandler(IRepository<DonationBenefit> _repository) : IRequestHandler<GetDonationBenefitQuery, List<GetDonationBenefitQueryResult>>
    {
        public async Task<List<GetDonationBenefitQueryResult>> Handle(GetDonationBenefitQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            return value.Select(x => new GetDonationBenefitQueryResult 
            {
                Id = x.Id,
                Title = x.Title,
            }).ToList();
        }
    }
}
