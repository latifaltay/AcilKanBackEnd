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
    public class GetAboutByIdQueryHandler(IRepository<About> _repository) : IRequestHandler<GetAboutByIdQuery, GetAboutByIdQueryResult>
    {
        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetAboutByIdQueryResult 
            {
                Id = value.Id,
                Description = value.Description,
                ImageUrl = value.ImageUrl,
                Title = value.Title,
            };
        }
    }
}
