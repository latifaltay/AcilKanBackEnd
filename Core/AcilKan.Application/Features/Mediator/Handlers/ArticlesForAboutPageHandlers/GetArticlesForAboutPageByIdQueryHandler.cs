using AcilKan.Application.Features.Mediator.Queries.ArticlesForAboutPageQueries;
using AcilKan.Application.Features.Mediator.Results.ArticlesForAboutPageResults;
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
    public class GetArticlesForAboutPageByIdQueryHandler(IRepository<ArticlesForAboutPage> _repository) : IRequestHandler<GetArticlesForAboutPageByIdQuery, GetArticlesForAboutPageByIdQueryResult>
    {
        public async Task<GetArticlesForAboutPageByIdQueryResult> Handle(GetArticlesForAboutPageByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetArticlesForAboutPageByIdQueryResult
            {
                Id = value.Id,
                Article = value.Article,
            };
        }
    }
}
