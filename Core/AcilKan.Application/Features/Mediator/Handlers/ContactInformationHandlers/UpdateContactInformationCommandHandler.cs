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
    public class UpdateContactInformationCommandHandler(IRepository<ContactInformation> _repository) : IRequestHandler<UpdateContactInformationCommand>
    {
        public async Task Handle(UpdateContactInformationCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            value.Title = request.Title;
            value.Phone = request.Phone;
            value.Address = request.Address;
            value.Mail = request.Mail;
            await _repository.UpdateAsync(value);
        }
    }
}
