using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Domain.Entities
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Hastanenin ait olduğu ilçe
        public int DistrictId { get; set; }  // İlçeId, foreign key
        public District District { get; set; }  // İlçeyle ilişkisi
    }
}
