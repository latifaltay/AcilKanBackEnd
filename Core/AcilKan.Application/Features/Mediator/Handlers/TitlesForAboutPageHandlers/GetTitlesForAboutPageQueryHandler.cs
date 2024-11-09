using AcilKan.Application.Features.Mediator.Queries.TitlesForAboutPageQueries;
using AcilKan.Application.Features.Mediator.Results.TitlesForAboutPageResults;
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
    public class GetTitlesForAboutPageQueryHandler(IRepository<TitlesForAboutPage> _repository) : IRequestHandler<GetTitlesForAboutPageQuery, List<GetTitlesForAboutPageQueryResult>>
    {
        public async Task<List<GetTitlesForAboutPageQueryResult>> Handle(GetTitlesForAboutPageQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            return value.Select(x => new GetTitlesForAboutPageQueryResult
            {
                Id = x.Id,
                Title = x.Title,
            }).ToList();
        }
    }
}
