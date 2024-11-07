using AcilKan.Application.Features.Mediator.Commands.ContactCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler(IRepository<Contact> _repository) : IRequestHandler<CreateContactCommand>
    {
        public async Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Contact
            {
                Name = request.Name,
                Email = request.Email,
                Message = request.Message,
                PhoneNumber = request.PhoneNumber,
                SendDate = request.SendDate = DateTime.Now,
            });
        }
    }
}
