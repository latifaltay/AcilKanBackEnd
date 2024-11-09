using AcilKan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Persistence.Context
{
    public class AcilKanContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AcilKanContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("sqlcon");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutBloodDonation> AboutBloodDonations { get; set; }
        public DbSet<AboutUs> AboutUses { get; set; }
        public DbSet<ArticlesForAboutPage> ArticlesForAboutPages { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }
        public DbSet<ContactPage> ContactPages { get; set; }
        public DbSet<ContactUs> ContactUses { get; set; }
        public DbSet<DonationBenefit> DonationBenefits { get; set; }
        public DbSet<FooterAddress> FooterAddresses { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Supporter> Supporters { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<TitlesForAboutPage> TitlesForAboutPages { get; set; }

    }
}
