using AcilKan.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Domain.Entities
{
    public class BloodDonation
    {
        public int Id { get; set; }
        public int BloodRequestId { get; set; } // Hangi bağış talebine yapıldı?
        public int DonorId { get; set; } // Bağış yapan kişi
        public int? UnitsDonated { get; set; } = 1; // Kaç ünite bağışladı?

        // **Tarih Alanları**
        public DateTime RequestedDonationDate { get; set; } = DateTime.UtcNow; // Bağış isteği oluşturulma tarihi
        public DateTime? ArrivalDate { get; set; } // Bağışçının bağış noktasına ulaştığı tarih
        public DateTime? DonationCompletionDate { get; set; } // Bağış işleminin tamamlandığı tarih
        public DateTime? ApprovalDate { get; set; } // Bağış talep edenin bağışı onayladığı tarih
        public DateTime? LastUpdatedDate { get; set; }  // En son güncelleme tarihi

        public BloodDonationStatus Status { get; set; } = BloodDonationStatus.Requested; // Varsayılan: Talep gönderildi

        public string? RejectedReason { get; set; } // Bağış başarısız olduysa neden?
        public string? Notes { get; set; } // Ekstra açıklamalar
        public bool IsActive { get; set; } = true; // Aktif mi?

        [ForeignKey(nameof(BloodRequestId))]
        public BloodRequest BloodRequest { get; set; }

        [ForeignKey(nameof(DonorId))]
        public AppUser Donor { get; set; } // Bağış yapan kullanıcı
    }
}
