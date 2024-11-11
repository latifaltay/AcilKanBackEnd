using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Domain.Entities
{
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // İlçenin ait olduğu şehir
        public int CityId { get; set; }  // ŞehirId, foreign key
        public City City { get; set; }  // Şehirle ilişkisi

        // İlçedeki hastanelerle olan ilişki
        public List<Hospital> Hospitals { get; set; }  // Bir ilçe birden fazla hastaneye sahip
    }
}
