using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Domain.Entities
{
    public class About
    {
        public int Id { get; set; }
        public AboutUs AboutUs { get; set; }
        public AboutBloodDonation AboutBloodDonation { get; set; }
    }
}
