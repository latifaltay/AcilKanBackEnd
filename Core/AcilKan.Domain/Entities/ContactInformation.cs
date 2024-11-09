using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Domain.Entities
{
    public class ContactInformation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Phone { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
    }
}
