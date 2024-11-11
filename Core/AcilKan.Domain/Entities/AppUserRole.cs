using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Domain.Entities
{
    public class AppUserRole 
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
