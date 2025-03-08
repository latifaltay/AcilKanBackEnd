using AcilKan.Application.Features.Mediator.Commands.BloodDontaionCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using AcilKan.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.BloodDontaionHandlers
{
    public class CreateBloodDontaionCommandHandler(IRepository<BloodDonation> _repository) : IRequestHandler<CreateBloodDontaionCommand>
    {
        
        public async Task Handle(CreateBloodDontaionCommand request, CancellationToken cancellationToken)
        {
            var userId = await _repository.GetCurrentUserIdAsync();

            await _repository.CreateAsync(new BloodDonation 
            {
                // Sorulacak
                BloodRequestId = request.BloodRequestId,
                RequestedDonationDate = DateTime.Now,
                DonorId = userId,
                IsActive = true,
                Status = BloodDonationStatus.Requested
            });
        }
    }
}
