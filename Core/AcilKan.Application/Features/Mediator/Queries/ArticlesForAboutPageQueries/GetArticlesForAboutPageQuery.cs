using AcilKan.Application.Features.Mediator.Results.ArticlesForAboutPageResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.ArticlesForAboutPageQueries
{
    public class GetArticlesForAboutPageQuery : IRequest<List<GetArticlesForAboutPageQueryResult>>
    {
    }
}
