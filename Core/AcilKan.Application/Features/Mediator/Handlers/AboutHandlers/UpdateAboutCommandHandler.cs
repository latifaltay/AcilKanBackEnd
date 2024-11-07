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
    public class UpdateAboutCommandHandler(IRepository<About> _repository) : IRequestHandler<UpdateAboutCommand>
    {
        public async Task Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            value.Title = request.Title;    
            value.Description = request.Description;
            value.ImageUrl = request.ImageUrl;
            await _repository.UpdateAsync(value);
        }
    }
}
