using AcilKan.Application.Features.Mediator.Queries.AboutBloodDonationQueries;
using AcilKan.Application.Features.Mediator.Results.AboutBloodDonationResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.AboutBloodDonationHandlers
{
    public class GetAboutBloodDonationQueryHandler(IRepository<AboutBloodDonation> _repository) : IRequestHandler<GetAboutBloodDonationQuery, List<GetAboutBloodDonationQueryResult>>
    {
        public async Task<List<GetAboutBloodDonationQueryResult>> Handle(GetAboutBloodDonationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAboutBloodDonationQueryResult
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
            }).ToList();
        }
    }
}
