using AcilKan.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Domain.Entities
{
    public class AppUser : IdentityUser<int>
    {
        [Required]
        [Column(TypeName = "char(11)")]
        public string TC { get; set; }  // 11 Haneli TC Kimlik No 
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required]
        [Column(TypeName = "tinyint")]  // ENUM değerini tinyint olarak sakla
        public BloodGroupType BloodGroup { get; set; }
        public bool Gender { get; set; }
        public bool? IsOnline { get; set; }
     
        public DateTime RegisterDate { get; set; }
        public DateTime BirthDate { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public int DistrictId { get; set; }
        public District District { get; set; }


        public override string UserName
        {
            get => Email;  
            set => base.UserName = value;
        }

        public string? RefreshToken { get; set; } 
        public DateTime? RefreshTokenExpiryTime { get; set; } 
        public List<BloodDonation> BloodDonations { get; set; }

    }
}
