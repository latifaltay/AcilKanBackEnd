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
    public class GetAboutUsByIdQueryHandler(IRepository<AboutUs> _repository) : IRequestHandler<GetAboutUsByIdQuery, GetAboutUsByIdQueryResult>
    {
        public async Task<GetAboutUsByIdQueryResult> Handle(GetAboutUsByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetAboutUsByIdQueryResult 
            {
                Id = value.Id,
                Title = value.Title,
                Description = value.Description,
                ImageUrl = value.ImageUrl,
            };
        }
    }
}
