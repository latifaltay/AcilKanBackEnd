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
    public class UpdateBloodDonationConditionCommandHandler(IRepository<BloodDonationCondition> _repository) : IRequestHandler<UpdateBloodDonationConditionCommand>
    {
        public async Task Handle(UpdateBloodDonationConditionCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            value.Title = request.Title;

            await _repository.UpdateAsync(value);
        }
    }
}
