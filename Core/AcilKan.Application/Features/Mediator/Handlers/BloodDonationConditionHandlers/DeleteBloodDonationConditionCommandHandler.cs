using AcilKan.Application.Features.Mediator.Commands.BloodDonationConditionCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.BloodDonationConditionHandlers
{
    public class DeleteBloodDonationConditionCommandHandler(IRepository<BloodDonationCondition> _repository) : IRequestHandler<DeleteBloodDonationConditionCommand>
    {
        public async Task Handle(DeleteBloodDonationConditionCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
