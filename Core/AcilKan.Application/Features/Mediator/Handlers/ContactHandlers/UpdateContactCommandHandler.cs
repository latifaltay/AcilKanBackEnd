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
    public class UpdateContactCommandHandler(IRepository<ContactPage> _repository) : IRequestHandler<UpdateContactCommand>
    {
        public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            value.PhoneNumber = request.PhoneNumber;
            value.Email = request.Email;
            value.Message = request.Message;
            value.Name = request.Name;
            await _repository.UpdateAsync(value);
        }
    }
}
