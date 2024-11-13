using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Domain.Entities
{
    public class DonationApproval
    {
        public int Id { get; set; }
        public int BloodRequestId { get; set; }   // Kan talebi referansı
        public int UserId { get; set; }           // Onaylayan kullanıcı referansı
        public bool IsApproved { get; set; }      // Onayın durumu (true: onaylandı, false: reddedildi)
        public DateTime ApprovalDate { get; set; }

        // Navigation properties
        public BloodRequest BloodRequest { get; set; }
        public AppUser User { get; set; }
    }
}
