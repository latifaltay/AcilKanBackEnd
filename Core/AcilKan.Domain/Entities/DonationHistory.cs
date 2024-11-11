using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Domain.Entities
{
    public class DonationHistory
    {
        public int Id { get; set; }
        public DateTime DonationDate { get; set; }
        public string HopitalId { get; set; }
        public Hospital Hospital { get; set; }
        public int DonationStatusId { get; set; }
        public DonationStatus DonationStatus { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }

    }
}
