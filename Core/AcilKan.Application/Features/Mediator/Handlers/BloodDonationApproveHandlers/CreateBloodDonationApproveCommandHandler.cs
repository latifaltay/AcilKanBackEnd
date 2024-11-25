using AcilKan.Application.Features.Mediator.Commands.BloodDonationApproveCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.BloodDonationApproveHandlers
{
    public class CreateBloodDonationApproveCommandHandler(IRepository<BloodDonationApprove> _repository) : IRequestHandler<CreateBloodDonationApproveCommand>
    {
        public async Task Handle(CreateBloodDonationApproveCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new BloodDonationApprove
            {
                BloodDontaionId = request.BloodDontaionId,
                DonorId = request.DonorId,
                RequestCreatorId = request.RequestCreatorId,
                IsDonorApproved = null,
                IsRequestCreatorApproved = null,
            });
        }
    }
}
