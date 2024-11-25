using AcilKan.Application.Features.Mediator.Results.BloodDonationApproveResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Queries.BloodDontaionApproveQueries
{
    public class GetBloodDonationApproveForAdminQuery : IRequest<List<GetBloodDonationApproveForAdminQueryResult>>
    {
    }
}
