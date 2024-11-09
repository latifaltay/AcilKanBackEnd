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
    public class GetMissionByIdQueryHandler(IRepository<Mission> _repository) : IRequestHandler<GetMissionByIdQuery, GetMissionByIdQueryResult>
    {
        public async Task<GetMissionByIdQueryResult> Handle(GetMissionByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetMissionByIdQueryResult
            {
                Id = value.Id,
                Title = value.Title,
                Description = value.Description,
            };
        }
    }
}
