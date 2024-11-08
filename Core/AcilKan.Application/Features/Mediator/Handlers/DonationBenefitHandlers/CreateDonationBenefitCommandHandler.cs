using AcilKan.Application.Features.Mediator.Commands.DonationBenefitCommands;
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
    public class CreateDonationBenefitCommandHandler(IRepository<DonationBenefit> _repository) : IRequestHandler<CreateDonationBenefitCommand>
    {
        public async Task Handle(CreateDonationBenefitCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new DonationBenefit 
            {
                Title = request.Title,
            });
        }
    }
}
