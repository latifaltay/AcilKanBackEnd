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
    public class GetTitlesForAboutPageByIdQueryHandler(IRepository<TitlesForAboutPage> _repository) : IRequestHandler<GetTitlesForAboutPageByIdQuery, GetTitlesForAboutPageByIdQueryResult>
    {
        public async Task<GetTitlesForAboutPageByIdQueryResult> Handle(GetTitlesForAboutPageByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetTitlesForAboutPageByIdQueryResult
            {
                Id = value.Id,
                Title = value.Title,
            };
        }
    }
}
