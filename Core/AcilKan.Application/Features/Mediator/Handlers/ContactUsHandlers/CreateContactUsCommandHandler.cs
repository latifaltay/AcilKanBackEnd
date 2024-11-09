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
    public class CreateContactUsCommandHandler(IRepository<ContactUs> _repository) : IRequestHandler<CreateContactUsCommand>
    {
        public async Task Handle(CreateContactUsCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new ContactUs
            {
                Name = request.Name,
                Surname = request.Surname,
                Subject = request.Subject,
                Email = request.Email,
                Message = request.Message,
                PhoneNumber = request.PhoneNumber,
                SendDate = request.SendDate = DateTime.Now,
            });
        }
    }
}
