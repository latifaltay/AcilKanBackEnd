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
    public class DeleteTitlesForAboutPageCommandHandler(IRepository<TitlesForAboutPage> _repository) : IRequestHandler<DeleteTitlesForAboutPageCommand>
    {
        async Task IRequestHandler<DeleteTitlesForAboutPageCommand>.Handle(DeleteTitlesForAboutPageCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
