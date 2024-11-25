using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Results.BloodDonationApproveResults
{
    public class GetBloodDonationApproveByRequesterIdQueryResult
    {
        public bool? IsRequestCreatorApproved { get; set; } // Request creator'ın onayı
    }
}
