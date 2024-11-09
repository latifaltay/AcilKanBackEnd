using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Domain.Entities
{
    public class ContactPage
    {
        public int Id { get; set; }
        public ContactUs ContactUs { get; set; }
        public ContactInformation ContactInformation { get; set; }
    }
}
