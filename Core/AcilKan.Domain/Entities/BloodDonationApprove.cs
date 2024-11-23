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

        // Kan talebi bilgisi
        public int BloodDontaionId { get; set; }
        public BloodDontaion BloodDontaion { get; set; }

        // Talebi oluşturan kullanıcı (Kan ihtiyacını bildiren kişi)
        public int RequestCreatorId { get; set; }
        public AppUser RequestCreator { get; set; }

        // Bağışı yapan kullanıcı (Kan veren kişi)
        public int DonorId { get; set; }
        public AppUser Donor { get; set; }
    }
}
