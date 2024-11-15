using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Domain.Entities
{
    public class BloodDonationApprove
    {
        public int Id { get; set; }
        public bool Approve { get; set; }
        public int BloodDonationId { get; set; }
        public BloodDontaion BloodDonation { get; set; }
    }
}
