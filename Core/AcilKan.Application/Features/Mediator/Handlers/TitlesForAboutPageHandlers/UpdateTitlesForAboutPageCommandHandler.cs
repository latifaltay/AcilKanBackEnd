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
    public class UpdateTitlesForAboutPageCommandHandler(IRepository<TitlesForAboutPage> _repository) : IRequestHandler<UpdateTitlesForAboutPageCommand>
    {
        public async Task Handle(UpdateTitlesForAboutPageCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            value.Title = request.Title;

            await _repository.UpdateAsync(value);
        }
    }
}
