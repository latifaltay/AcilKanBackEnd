using AcilKan.Application.Features.Mediator.Queries.ArticlesForAboutPageQueries;
using AcilKan.Application.Features.Mediator.Queries.TitlesForAboutPageQueries;
using AcilKan.Application.Features.Mediator.Results.ArticlesForAboutPageResults;
using AcilKan.Application.Features.Mediator.Results.TitlesForAboutPageResults;
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
    public class GetArticlesForAboutPageQueryHandler(IRepository<ArticlesForAboutPage> _repository) : IRequestHandler<GetArticlesForAboutPageQuery, List<GetArticlesForAboutPageQueryResult>>
    {
        public async Task<List<GetArticlesForAboutPageQueryResult>> Handle(GetArticlesForAboutPageQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            return value.Select(x => new GetArticlesForAboutPageQueryResult
            {
                Id = x.Id,
                Article = x.Article,
            }).ToList();
        }
    }
}
