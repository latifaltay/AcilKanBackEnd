using AcilKan.Application.Features.Mediator.Commands.TitlesForAboutPageCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.TitlesForAboutPageHandlers
{
    public class CreateTitlesForAboutPageCommandHandler(IRepository<TitlesForAboutPage> _repository) : IRequestHandler<CreateTitlesForAboutPageCommand>
    {
        public async Task Handle(CreateTitlesForAboutPageCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new TitlesForAboutPage 
            {
                Title = request.Title,
            });
        }
    }
}
