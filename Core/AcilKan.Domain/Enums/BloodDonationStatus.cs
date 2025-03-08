using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Domain.Enums
{
    public enum BloodDonationStatus
    {
        [Description("Bağış yapma isteği gönderildi")]
        Requested = 1,

        [Description("Bağış noktasına ulaştı")]
        ArrivedAtDonationPoint = 2,

        [Description("Sağlık sorunu nedeniyle bağış yapamadı")]
        UnableToDonateDueToHealth = 3,

        [Description("Bağış yapmaktan vazgeçti")]
        CanceledByDonor = 4,

        [Description("Başarılı bir şekilde bağış yapıldı, bağış talep edenin onayı bekleniyor")]
        CompletedByDonor = 5,

        [Description("Bağış tamamlandı")]
        ApprovedByRequester = 6,

        [Description("Kan bağışı süresi doldu")]
        Expired = 7
    }


}
