using AcilKan.Application.Features.Mediator.Results.ProfileResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.ProfileQueries
{
    public class GetProfileInfoByUserIdQuery(int id) : IRequest<GetProfileInfoByUserIdQueryResult>
    {
        public int UserId { get; set; } = id;
    }
}
 