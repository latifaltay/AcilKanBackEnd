﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Domain.Entities
{
    public class DonationBenefit // hatalı Kullanılmayacak About sayfasındaki neden kan bağışı alanı
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Article { get; set; }
    }
}
