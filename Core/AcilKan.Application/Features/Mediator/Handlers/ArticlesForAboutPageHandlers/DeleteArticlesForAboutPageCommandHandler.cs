using AcilKan.Application.Features.Mediator.Commands.ArticlesForAboutPageCommands;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.ArticlesForAboutPageHandlers
{
    public class DeleteArticlesForAboutPageCommandHandler(IRepository<ArticlesForAboutPage> _repository) : IRequestHandler<DeleteArticlesForAboutPageCommand>
    {
        async Task IRequestHandler<DeleteArticlesForAboutPageCommand>.Handle(DeleteArticlesForAboutPageCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
