using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.DTOs.BloodDonation
{
   public class GetDonorForRequester
    {
        public int BloodDonationId { get; set; }
        public int DonorId { get; set; }
        public int? UnitsDonated { get; set; }
        public DateTime RequestedDonationDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public DateTime? DonationCompletionDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string Status { get; set; }
        public string? RejectedReason { get; set; }
        public string DonorFullName { get; set; }
    }
}
