using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Domain.Enums
{
    public enum BloodGroupType
    {
        [Description("A RH +")]
        APositive = 1,

        [Description("A RH -")]
        ANegative = 2,

        [Description("B RH +")]
        BPositive = 3,

        [Description("B RH -")]
        BNegative = 4,

        [Description("AB RH +")]
        ABPositive = 5,

        [Description("AB RH -")]
        ABNegative = 6,

        [Description("0 RH +")]
        OPositive = 7,

        [Description("0 RH -")]
        ONegative = 8
    }
}
