using AcilKan.Application.Features.Mediator.Queries.AboutUsQueries;
using AcilKan.Application.Features.Mediator.Results.AboutUsResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.AboutUsHandlers
{
    public class GetAboutUsQueryHandler(IRepository<AboutUs> _repository) : IRequestHandler<GetAboutUsQuery, List<GetAboutUsQueryResult>>
    {
        public async Task<List<GetAboutUsQueryResult>> Handle(GetAboutUsQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAboutUsQueryResult 
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
            }).ToList();
        }
    }
}
