using AcilKan.Application.Features.Mediator.Commands.AboutCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.AboutHandlers
{
    public class DeleteAboutCommandHandler(IRepository<About> _repository) : IRequestHandler<DeleteAboutCommand>
    {
        public async Task Handle(DeleteAboutCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
