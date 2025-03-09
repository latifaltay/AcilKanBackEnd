using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Results.UserInformationResults
{
    public class GetHomePageChartByUserIdQueryResult
    {
        public int DonationCount { get; set; }
        public string NextDonationDate { get; set; }
        public string LastDonationDate { get; set; }
    }
}
