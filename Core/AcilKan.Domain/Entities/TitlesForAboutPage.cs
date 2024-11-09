using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Domain.Entities
{
    public class TitlesForAboutPage // About sayfasındaki neden kan bağışı ve kimler kan bağışlayabilir chartları
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<ArticlesForAboutPage> ArticlesForAboutPage { get; set; }
        public string Key { get; set; }
    }
}
