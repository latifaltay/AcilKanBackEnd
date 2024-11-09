using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Domain.Entities
{
    public class ArticlesForAboutPage // About sayfasındaki neden kan bağışı ve kimler kan bağışlayabilir chartları
    {
        public int Id { get; set; }
        public string Article { get; set; }
        public int TitlesForAboutPageId { get; set; }
        public TitlesForAboutPage TitlesForAboutPage { get; set; }
    }
}
