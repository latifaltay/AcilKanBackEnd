using AcilKan.Application.Features.Mediator.Results.DonationBenefitResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.DonationBenefitQueries
{
    public class GetDonationBenefitQuery : IRequest<List<GetDonationBenefitQueryResult>>
    {
    }
}
