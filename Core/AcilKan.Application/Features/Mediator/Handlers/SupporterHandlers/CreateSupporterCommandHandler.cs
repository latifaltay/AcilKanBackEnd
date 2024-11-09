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
    public class CreateSupporterCommandHandler(IRepository<Supporter> _repository) : IRequestHandler<CreateSupporterCommand>
    {
        public async Task Handle(CreateSupporterCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Supporter
            {
                ImageUrl = request.ImageUrl,
                CompanyName = request.CompanyName
            });
        }
    }
}
