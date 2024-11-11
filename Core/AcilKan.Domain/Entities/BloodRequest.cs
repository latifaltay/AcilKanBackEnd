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
        //public int CityId { get; set; }
        //public int DistrictId { get; set; }
        public int HospitalId { get; set; }

        //public City City { get; set; }
        //public District District { get; set; }
        public Hospital Hospital { get; set; }
    }
}
