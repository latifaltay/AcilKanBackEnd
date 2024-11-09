using AcilKan.Application.Features.Mediator.Results.ContactUsResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.ContactUsQueries
{
    public class GetContactUsQuery : IRequest<List<GetContactUsQueryResult>>
    {
    }
}
