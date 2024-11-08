using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Domain.Entities
{
    public class AboutBloodDonation
    {
        public int Id { get; set; }
        public Mission Mission { get; set; }
        public DonationBenefit DonationBenefit { get; set; }
        public BloodDonationCondition BloodDonationConditions { get; set; }
        public ContactForAboutPage ContactForAboutPage { get; set; }

    }
}
