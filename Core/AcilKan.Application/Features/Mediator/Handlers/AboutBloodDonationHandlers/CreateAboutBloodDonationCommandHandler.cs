using AcilKan.Application.Features.Mediator.Commands.AboutBloodDonationCommands;
using AcilKan.Application.Features.Mediator.Commands.AboutBloodDonationCommands;
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
    public class CreateAboutBloodDonationCommandHandler(IRepository<AboutBloodDonation> _repository) : IRequestHandler<CreateAboutBloodDonationCommand>
    {
        public async Task Handle(CreateAboutBloodDonationCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AboutBloodDonation
            {
                ImageUrl = request.ImageUrl,
            });
        }
    }
}
