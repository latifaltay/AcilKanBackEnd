using AcilKan.Application.Features.Mediator.Queries.BloodGroupQueries;
using AcilKan.Application.Features.Mediator.Results.BloodGroupResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.BloodGroupHandlers
{
    public class GetBloodGroupQueryHandler(IRepository<BloodGroup> _repository) : IRequestHandler<GetBloodGroupQuery, List<GetBloodGroupQueryResult>>
    {
        public async Task<List<GetBloodGroupQueryResult>> Handle(GetBloodGroupQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBloodGroupQueryResult 
            {
                Id = x.Id,
                GroupName = x.GroupName,
            }).ToList();
        }
    }
}
