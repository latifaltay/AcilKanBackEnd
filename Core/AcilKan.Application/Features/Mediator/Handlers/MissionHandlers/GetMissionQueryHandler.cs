using AcilKan.Application.Features.Mediator.Queries.MissionQueries;
using AcilKan.Application.Features.Mediator.Results.MissionResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.MissionHandlers
{
    public class GetMissionQueryHandler(IRepository<Mission> _repository) : IRequestHandler<GetMissionQuery, List<GetMissionQueryResult>>
    {
        public async Task<List<GetMissionQueryResult>> Handle(GetMissionQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            return value.Select(x => new GetMissionQueryResult
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,

            }).ToList();
        }
    }
}
