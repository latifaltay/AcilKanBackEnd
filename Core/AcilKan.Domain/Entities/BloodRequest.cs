using AcilKan.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcilKan.Domain.Entities
{
    public class BloodRequest
    {
        public int Id { get; set; }
        public int RequesterId { get; set; } // Talep Eden Kullanıcı
        public int HospitalId { get; set; } // Hastanın Yattığı Hastane
        public bool IsIndependentDonation { get; set; } // Bağımsız bağış mümkün mü?
        [Column(TypeName = "tinyint")]  // ENUM değerini tinyint olarak sakla
        public BloodGroupType BloodGroup { get; set; } // Kan Grubu Enum
        public int RequiredUnits { get; set; } // Kaç ünite kan gerekiyor?
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public int? PatientAge { get; set; } // Hasta yaşı
        public bool? PatientGender { get; set; } // Hasta cinsiyeti (Erkek: true, Kadın: false)
        
        [Column(TypeName = "tinyint")]  // ENUM değerini tinyint olarak sakla
        public DemandReasonType? DemandReason { get; set; } // Talep Sebebi   

        public bool IsActive { get; set; } // Aktif mi?

        [Column(TypeName = "tinyint")]  // ENUM değerini tinyint olarak sakla
        public BloodRequestStatus Status { get; set; } = BloodRequestStatus.Requested;
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
        public DateTime? ExpiryDate { get; set; } = DateTime.UtcNow.AddHours(24);
        public DateTime? CompletionDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(HospitalId))]
        public Hospital Hospital { get; set; }

        [ForeignKey(nameof(RequesterId))]
        public AppUser AppUser { get; set; }

        // Bağış yapanların listesi (1'e çok ilişki)
        public List<BloodDonation> Donations { get; set; } = new();

    }
}
