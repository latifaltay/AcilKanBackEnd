using AcilKan.Application.Features.Mediator.Queries.CityQueries;
using AcilKan.Application.Features.Mediator.Results.CityResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.CityHandlers
{
    public class GetCityByIdQueryHandler(IRepository<City> _repository) : IRequestHandler<GetCityByIdQuery, GetCityByIdQueryResult>
    {
        public async Task<GetCityByIdQueryResult> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetCityByIdQueryResult 
            {
                id = value.Id,
                Name = value.Name,
            };
        }
    }
}
