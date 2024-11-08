using AcilKan.Application.Features.Mediator.Commands.FooterAddressCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class UpdateFooterAddressCommandHandler(IRepository<FooterAddress> _repository) : IRequestHandler<UpdateFooterAddressCommand>
    {
        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);


            await _repository.UpdateAsync(value);
        }
    }
}
