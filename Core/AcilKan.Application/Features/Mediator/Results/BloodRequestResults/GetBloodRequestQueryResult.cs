﻿using AcilKan.Application.Features.Mediator.Results.BloodDonationResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Results.BloodRequestResults
{
    public class GetBloodRequestQueryResult
    {
        public int RequestId { get; set; }
        public string RequesterFullName { get; set; }
        public int RequesterId { get; set; }
        public int HospitalId { get; set; }
        public bool IsIndependentDonation { get; set; }
        public string BloodGroupName { get; set; }
        public int RequiredUnits { get; set; }
        public string PatientFullName { get; set; }
        public DateTime RequestDate { get; set; }
        public string HospitalName { get; set; }
        public string City { get; set; }
        public string District { get; set; }
    }

}
