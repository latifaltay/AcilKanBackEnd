using System.ComponentModel;

namespace AcilKan.Domain.Enums
{
    public enum BloodRequestStatus
    {
        [Description("Bağış Talep Edildi")]
        Requested = 1,

        [Description("Bağış Tamamlandı")]
        Completed = 2,

        [Description("Bağış Yönetici Tarafından İptal Edildi")]
        CanceledByAdmin = 3,

        [Description("Bağışçı Bulundu, Bekleniyor")]
        DonorFoundPending = 4,

        [Description("Bağış Süresi Doldu")]
        Expired = 5
    }

}
