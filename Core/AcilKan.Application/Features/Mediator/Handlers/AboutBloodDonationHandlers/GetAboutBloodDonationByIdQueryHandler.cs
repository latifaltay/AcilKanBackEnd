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
    public class GetAboutBloodDonationByIdQueryHandler(IRepository<AboutBloodDonation> _repository) : IRequestHandler<GetAboutBloodDonationByIdQuery, GetAboutBloodDonationByIdQueryResult>
    {
        public async Task<GetAboutBloodDonationByIdQueryResult> Handle(GetAboutBloodDonationByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetAboutBloodDonationByIdQueryResult
            {
                Id = value.Id,
                ImageUrl = value.ImageUrl,
            };
        }
    }
}
