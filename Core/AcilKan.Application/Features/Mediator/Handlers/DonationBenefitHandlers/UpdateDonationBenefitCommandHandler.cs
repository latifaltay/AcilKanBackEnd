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
    public class UpdateDonationBenefitCommandHandler(IRepository<DonationBenefit> _repository) : IRequestHandler<UpdateDonationBenefitCommand>
    {
        public async Task Handle(UpdateDonationBenefitCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            value.Article = request.Article;
            value.Title = request.Title;

            await _repository.UpdateAsync(value);
        }
    }
}
