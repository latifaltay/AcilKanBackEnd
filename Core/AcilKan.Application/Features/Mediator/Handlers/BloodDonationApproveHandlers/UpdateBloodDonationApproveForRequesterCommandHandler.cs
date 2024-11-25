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
    public class UpdateBloodDonationApproveForRequesterCommandHandler(IRepository<BloodDonationApprove> _repository) : IRequestHandler<UpdateBloodDonationApproveForRequesterCommand>
    {
        public async Task Handle(UpdateBloodDonationApproveForRequesterCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            value.IsRequestCreatorApproved = request.IsRequestCreatorApproved;
            await _repository.UpdateAsync(value);
        }
    }
}
