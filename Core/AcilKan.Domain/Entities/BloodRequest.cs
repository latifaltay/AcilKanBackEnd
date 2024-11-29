using AcilKan.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Domain.Entities
{
    public class BloodRequest
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public int HospitalId { get; set; }
        public BloodGroupType BloodGroup { get; set; } // Enum
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public DateTime RequestDate { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; }
        public Hospital Hospital { get; set; }
        public AppUser AppUser { get; set; }
    }
}
