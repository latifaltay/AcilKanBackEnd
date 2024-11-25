using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Domain.Entities
{
    public class BloodDonation
    {
        public int Id { get; set; }
        public int DonorId { get; set; }
        public DateTime DonationDate { get; set; }
        public int BloodRequestId { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; }

        public BloodRequest BloodRequest { get; set; }
        public AppUser Donor { get; set; }
    }
}
