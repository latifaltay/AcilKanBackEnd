using AcilKan.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Results.UserInformationResults
{
    public class GetUserProfileInfoByUserIdQueryResult
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BloodGroupName { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string? LastDonation { get; set; }
        public int TotalDonationCount { get; set; }
    }
}
