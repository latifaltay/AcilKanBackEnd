﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Domain.Entities
{
    public class Supporter // Ana sayfadaki destekleyen kurumların logolarının slider alanı
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ImageUrl { get; set; }
    }
}
