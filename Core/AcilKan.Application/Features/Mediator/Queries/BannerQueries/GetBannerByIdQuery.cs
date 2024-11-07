using AcilKan.Application.Features.Mediator.Results.BannerResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.BannerQueries
{
    public class GetBannerByIdQuery(int id) : IRequest<GetBannerByIdQueryResult>
    {
        public int Id { get; set; } = id;
    }
}
