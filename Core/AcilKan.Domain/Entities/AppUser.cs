using AcilKan.Domain.Enums;
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
        public BloodGroupType BloodGroup { get; set; } // Enum
        public bool Gender { get; set; }
        public bool? IsOnline { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime BirthDate { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public int DistrictId { get; set; }
        public District District { get; set; }


        // UserName'ı Email ile eşitleme (username kullanmadığım için maili username gibi kullanıyorum)
        public override string UserName
        {
            get => Email;  // Email'i UserName olarak kullanıyoruz
            set => base.UserName = value;
        }
    }
}
