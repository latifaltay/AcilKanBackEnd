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
    public class DeleteDonationBenefitCommandHandler(IRepository<DonationBenefit> _repository) : IRequestHandler<DeleteDonationBenefitCommand>
    {
        async Task IRequestHandler<DeleteDonationBenefitCommand>.Handle(DeleteDonationBenefitCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
