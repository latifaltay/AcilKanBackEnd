using AcilKan.Application.Features.Mediator.Results.SupporterResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.SupporterQueries
{
    public class GetSupporterQuery : IRequest<List<GetSupporterQueryResult>>
    {
    }
}
