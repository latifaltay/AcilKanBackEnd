﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Results.BloodRequestResults
{
    public class GetBloodRequestByIdQueryResult
    {
        public int Id { get; set; }
        public string AppUserFullName { get; set; }
        public string BloodGroupName { get; set; }       
        public string HospitalName { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
    }
}