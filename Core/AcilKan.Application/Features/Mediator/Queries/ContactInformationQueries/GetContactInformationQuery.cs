using AcilKan.Application.Features.Mediator.Results.ContactInformationResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.ContactInformationQueries
{
    public class GetContactInformationQuery : IRequest<List<GetContactInformationQueryResult>>
    {
    }
}
