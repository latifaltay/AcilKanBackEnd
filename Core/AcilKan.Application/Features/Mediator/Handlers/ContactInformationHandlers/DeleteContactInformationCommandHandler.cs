using AcilKan.Application.Features.Mediator.Commands.ContactInformationCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.ContactInformationHandlers
{
    public class DeleteContactInformationCommandHandler(IRepository<ContactInformation> _repository) : IRequestHandler<DeleteContactInformationCommand>
    {
        public async Task Handle(DeleteContactInformationCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
