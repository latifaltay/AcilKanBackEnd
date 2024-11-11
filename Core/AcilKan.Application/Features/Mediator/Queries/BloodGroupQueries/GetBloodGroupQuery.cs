using AcilKan.Application.Features.Mediator.Results.BloodGroupResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.BloodGroupQueries
{
    public class GetBloodGroupQuery : IRequest<List<GetBloodGroupQueryResult>>
    {
    }
}
