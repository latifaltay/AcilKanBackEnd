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
    public class DeleteFooterAddressCommandHandler(IRepository<FooterAddress> _repository) : IRequestHandler<DeleteFooterAddressCommand>
    {
        async Task IRequestHandler<DeleteFooterAddressCommand>.Handle(DeleteFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
