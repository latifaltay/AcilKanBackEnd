using AcilKan.Application.Features.Mediator.Results.UserInformationResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.UserInformationQueries
{
    public class GetHomePageChartByUserIdQuery() : IRequest<GetHomePageChartByUserIdQueryResult>
    {
    }
}
