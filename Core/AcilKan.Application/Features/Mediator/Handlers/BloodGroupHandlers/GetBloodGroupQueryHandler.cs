using AcilKan.Application.Features.Mediator.Queries.BloodGroupQueries;
using AcilKan.Application.Features.Mediator.Results.BloodGroupResults;
using AcilKan.Application.Interfaces;
using AcilKan.Domain.Entities;
using AcilKan.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcilKan.Application.Extensions;  


namespace AcilKan.Application.Features.Mediator.Handlers.BloodGroupHandlers
{
    //public class GetBloodGroupQueryHandler(IRepository<BloodGroup> _repository) : IRequestHandler<GetBloodGroupQuery, List<GetBloodGroupQueryResult>>
    //{
    //    public async Task<List<GetBloodGroupQueryResult>> Handle(GetBloodGroupQuery request, CancellationToken cancellationToken)
    //    {
    //        var values = await _repository.GetAllAsync();
    //        return values.Select(x => new GetBloodGroupQueryResult
    //        {
    //            Id = x.Id,
    //            GroupName = x.GroupName,
    //        }).ToList();
    //    }
    //}

    public class GetBloodGroupQueryHandler : IRequestHandler<GetBloodGroupQuery, List<GetBloodGroupQueryResult>>
    {
        public Task<List<GetBloodGroupQueryResult>> Handle(GetBloodGroupQuery request, CancellationToken cancellationToken)
        {
            // Enum'dan değerleri listeye çeviriyoruz
            var values = Enum.GetValues(typeof(BloodGroupType))
                             .Cast<BloodGroupType>()
                             .Select(bg => new GetBloodGroupQueryResult
                             {
                                 Id = (int)bg,
                                 GroupName = bg.GetDescription() // Enum için açıklama metnini alıyoruz
                             })
                             .ToList();

            return Task.FromResult(values);
        }
    }
}