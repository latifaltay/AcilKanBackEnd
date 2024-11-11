using AcilKan.Application.Features.Mediator.Results.AppUserResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.AppUserQueries
{
    public class GetAppUserByIdQuery(int id) : IRequest<GetAppUserByIdQueryResult>
    {
        public int Id { get; set; } = id;
    }
}
