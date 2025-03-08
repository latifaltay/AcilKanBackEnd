using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Results.BloodDonationResults
{
    public class GetUserDonationStatsQueryResult
    {
        public int TotalDonations { get; set; } // Toplam bağış
        public string LastDonationAgo { get; set; } // Son bağış ne zaman yapıldı?
        public string NextDonationIn { get; set; } // Ne zaman tekrar bağış yapabilir?
    }
}
