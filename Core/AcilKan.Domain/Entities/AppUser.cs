using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Domain.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BloodGroup { get; set; }
        public bool Gender { get; set; }
        public string ImageUrl { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }
    }
}
