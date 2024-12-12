using AcilKan.Application.Features.Mediator.Results.UserProfileResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.UserProfileQueries
{
    public class GetUserProfileInfoByUserIdQuery() : IRequest<GetUserProfileInfoByUserIdQueryResult>
    {
    }
}
 