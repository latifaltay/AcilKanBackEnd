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
    public class UpdateBloodDonationApproveForDonorCommandHandler(IRepository<BloodDonationApprove> _repository) : IRequestHandler<UpdateBloodDonationApproveForDonorCommand>
    {
        public async Task Handle(UpdateBloodDonationApproveForDonorCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            value.IsDonorApproved = request.IsDonorApproved;
            await _repository.UpdateAsync(value);
        }
    }
}
