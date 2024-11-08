using AcilKan.Application.Features.Mediator.Commands.SupporterCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.SupporterHandlers
{
    public class UpdateSupporterCommandHandler(IRepository<Supporter> _repository) : IRequestHandler<UpdateSupporterCommand>
    {
        public async Task Handle(UpdateSupporterCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);


            value.CompanyName = request.Title;
            value.ImageUrl = request.ImageUrl;

            await _repository.UpdateAsync(value);
        }
    }
}
