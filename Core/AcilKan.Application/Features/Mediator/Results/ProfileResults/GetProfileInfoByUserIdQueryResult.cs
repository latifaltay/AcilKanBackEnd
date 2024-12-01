using AcilKan.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Results.ProfileResults
{
    public class GetProfileInfoByUserIdQueryResult
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BloodGroup { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public DateTime LastDonation { get; set; }
        public int TotalDonationCount { get; set; }
    }
}
