using AcilKan.Application.Features.Mediator.Commands.ContactUsCommands;
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
    public class UpdateContactUsCommandHandler(IRepository<ContactUs> _repository) : IRequestHandler<UpdateContactUsCommand>
    {
        public async Task Handle(UpdateContactUsCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            value.Name = request.Name;
            value.Surname = request.Surname;
            value.PhoneNumber = request.PhoneNumber;
            value.Email = request.Email;
            value.Subject = request.Subject;
            value.Message = request.Message;
            await _repository.UpdateAsync(value);
        }
    }
}
