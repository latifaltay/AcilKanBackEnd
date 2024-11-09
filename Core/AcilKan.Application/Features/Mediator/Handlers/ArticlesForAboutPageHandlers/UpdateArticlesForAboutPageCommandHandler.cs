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
    public class UpdateArticlesForAboutPageCommandHandler(IRepository<ArticlesForAboutPage> _repository) : IRequestHandler<UpdateArticlesForAboutPageCommand>
    {
        public async Task Handle(UpdateArticlesForAboutPageCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            value.Article = request.Article;

            await _repository.UpdateAsync(value);
        }
    }
}
