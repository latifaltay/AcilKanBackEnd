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
    public class CreateBloodDonationConditionCommandHandler(IRepository<BloodDonationCondition> _repository) : IRequestHandler<CreateBloodDonationConditionCommand>
    {
        public async Task Handle(CreateBloodDonationConditionCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new BloodDonationCondition 
            {
                Title = request.Title,
            });
        }
    }
}
