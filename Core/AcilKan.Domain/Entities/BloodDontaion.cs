using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Domain.Entities
{
    public class BloodDontaion
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BloodRequestId { get; set; }
        public BloodRequest BloodRequest { get; set; }
    }
}
