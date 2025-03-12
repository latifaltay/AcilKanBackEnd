using AcilKan.Domain.Entities;
using AcilKan.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Results.BloodDonationResults
{
    public class GetMyBloodDonationQueryResult
    {
        public int Id { get; set; }
        public DateTime? DonationCompletionDate { get; set; }
        public string DonorFullName { get; set; }
        public string HospitalName { get; set; }
        public string PatientFullName { get; set; }
        public string RequesterFullName { get; set; }
        public string Status { get; set; }
        public int? UnitsDonated { get; set; } // kaç Ünivte Bağışlandı

        // **Tarih Alanları**
        public DateTime RequestedDonationDate { get; set; } = DateTime.UtcNow; // Bağış isteği oluşturulma tarihi
        public DateTime? ArrivalDate { get; set; } // Bağışçının bağış noktasına ulaştığı tarih
        public DateTime? ApprovalDate { get; set; } // Bağış talep edenin bağışı onayladığı tarih
        public DateTime? LastUpdatedDate { get; set; }  // En son güncelleme tarihi

        public string? RejectedReason { get; set; } // Bağış başarısız olduysa neden?
        public string? Notes { get; set; } // Ekstra açıklamalar
        public BloodRequest BloodRequest { get; set; } // ✅ Artık komple nesne dönüyor

        // **BloodRequest İçin Ayrı Alanlar**
        public DateTime? BloodRequestExpiryDate { get; set; } // Talebin son süresi
        public int BloodRequestRequiredUnits { get; set; } // Kaç ünite kan lazım?
        public string BloodRequestBloodGroup { get; set; } // Kan grubu
        public DateTime BloodRequestCreationDate { get; set; } // Talebin oluşturulma tarihi

    }
}
