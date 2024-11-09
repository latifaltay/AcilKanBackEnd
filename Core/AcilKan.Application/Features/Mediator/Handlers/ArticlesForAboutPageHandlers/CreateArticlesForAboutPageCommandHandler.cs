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
    public class CreateArticlesForAboutPageCommandHandler(IRepository<ArticlesForAboutPage> _repository) : IRequestHandler<CreateArticlesForAboutPageCommand>
    {
        public async Task Handle(CreateArticlesForAboutPageCommand request, CancellationToken cancellationToken)
        {
            var value = new ArticlesForAboutPage
            {
                Article = request.Article,
                TitlesForAboutPageId = request.TitleId,
            };
            await _repository.CreateAsync(value);
        }
    }
}
