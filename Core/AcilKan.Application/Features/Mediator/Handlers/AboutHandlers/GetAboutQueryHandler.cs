using AcilKan.Application.Features.Mediator.Queries.AboutQueries;
using AcilKan.Application.Features.Mediator.Results.AboutResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler(IRepository<About> _repository) : IRequestHandler<GetAboutQuery, GetAboutQueryResult>
    {
        public async Task<GetAboutQueryResult> Handle(GetAboutQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAboutQueryResult
            {
                Id = x.Id,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Title = x.Title,
            }).FirstOrDefault();
        }
    }
}
