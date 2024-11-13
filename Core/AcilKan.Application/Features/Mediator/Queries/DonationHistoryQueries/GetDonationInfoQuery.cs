using AcilKan.Application.Features.Mediator.Results.DonationHistoryResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.DonationHistoryQueries
{
    public class GetDonationInfoQuery : IRequest<GetDonationInfoQueryResult>
    {
    }
}
