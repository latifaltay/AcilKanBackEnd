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
    public class GetCityQueryHandler(IRepository<City> _repository) : IRequestHandler<GetCityQuery, List<GetCityQueryResult>>
    {
        public async Task<List<GetCityQueryResult>> Handle(GetCityQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCityQueryResult 
            {
                id = x.Id,
                Name = x.Name,
            }).ToList();
        }
    }
}
