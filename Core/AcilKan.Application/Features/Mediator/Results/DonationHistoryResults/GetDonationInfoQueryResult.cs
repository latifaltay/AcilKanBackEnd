using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Results.DonationHistoryResults
{
    public class GetDonationInfoQueryResult
    {
        public int TotalDonation { get; set; }
        public DateTime LastDonationDate { get; set; }
        public DateTime NextDonationDate { get; set; }
    }
}
