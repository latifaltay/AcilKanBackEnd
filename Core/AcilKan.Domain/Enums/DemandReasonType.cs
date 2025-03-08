using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Domain.Enums
{
    public enum DemandReasonType
    {
        [Description("Acil Ameliyat")]
        EmergencySurgery = 1,

        [Description("Trafik Kazası")]
        TrafficAccident = 2,

        [Description("Doğum Sonrası")]
        PostpartumHemorrhage = 3,

        [Description("Kanser Tedavisi")]
        CancerTreatment = 4,

        [Description("Organ Nakli")]
        OrganTransplant = 5,

        [Description("Anemi veya Talasemi")]
        AnemiaOrThalassemia = 6,

        [Description("Diyaliz Tedavisi")]
        DialysisTreatment = 7,

        [Description("Yanık Hastaları")]
        BurnPatients = 8,

        [Description("Yoğun Bakım Hastaları")]
        IntensiveCarePatients = 9,

        [Description("Diğer")]
        Other = 99
    }

}
