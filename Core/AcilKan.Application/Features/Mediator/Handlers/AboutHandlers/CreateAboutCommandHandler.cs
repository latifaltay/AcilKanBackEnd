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
    public class CreateAboutCommandHandler(IRepository<About> _repository) : IRequestHandler<CreateAboutCommand>
    {
        public async Task Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new About 
            {
                Title = request.Title,  
                Description = request.Description,
                ImageUrl = request.ImageUrl,
            });
        }
    }
}
