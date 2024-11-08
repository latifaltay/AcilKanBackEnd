using AcilKan.Application.Features.Mediator.Commands.AboutUsCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.AboutUsHandlers
{
    public class DeleteAboutUsCommandHandler(IRepository<AboutUs> _repository) : IRequestHandler<DeleteAboutUsCommand>
    {
        public async Task Handle(DeleteAboutUsCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
