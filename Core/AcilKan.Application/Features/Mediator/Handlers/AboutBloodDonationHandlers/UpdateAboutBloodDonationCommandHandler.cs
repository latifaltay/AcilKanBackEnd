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
    public class UpdateAboutBloodDonationCommandHandler(IRepository<AboutBloodDonation> _repository) : IRequestHandler<UpdateAboutBloodDonationCommand>
    {
        public async Task Handle(UpdateAboutBloodDonationCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            value.ImageUrl = request.ImageUrl;
            await _repository.UpdateAsync(value);
        }
    }
}
