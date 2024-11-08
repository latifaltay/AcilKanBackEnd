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
    public class CreateAboutUsCommandHandler(IRepository<AboutUs> _repository) : IRequestHandler<CreateAboutUsCommand>
    {
        public async Task Handle(CreateAboutUsCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AboutUs 
            {
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                Title = request.Title,
            });
        }
    }
}
