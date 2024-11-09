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
    public class CreateContactInformationCommandHandler(IRepository<ContactInformation> _repository) : IRequestHandler<CreateContactInformationCommand>
    {
        public async Task Handle(CreateContactInformationCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new ContactInformation 
            {
                Title = request.Title,
                Address = request.Address,
                Mail = request.Mail,
                Phone = request.Phone,
            });
        }
    }
}
