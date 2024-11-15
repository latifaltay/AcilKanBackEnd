﻿using AcilKan.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Persistence.Context
{
    public class AcilKanContext : IdentityDbContext<AppUser, AppRole, int>
    {
        private readonly IConfiguration _configuration;

        public AcilKanContext(DbContextOptions<AcilKanContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutBloodDonation> AboutBloodDonations { get; set; }
        public DbSet<AboutUs> AboutUses { get; set; }
        public DbSet<AppUserRole> UserRoles { get; set; }
        public DbSet<ArticlesForAboutPage> ArticlesForAboutPages { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<BloodDonationApprove> BloodDonationApproves { get; set; }
        public DbSet<BloodDontaion> BloodDontaions { get; set; }
        public DbSet<BloodGroup> BloodGroups { get; set; }
        public DbSet<BloodRequest> BloodRequests { get; set; }
        public DbSet<BloodRequestApprove> BloodRequestApproves { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }
        public DbSet<ContactPage> ContactPages { get; set; }
        public DbSet<ContactUs> ContactUses { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<DonationBenefit> DonationBenefits { get; set; }
        public DbSet<DonationHistory> DonationHistories { get; set; }
        public DbSet<DonationStatus> DonationStatuses { get; set; }
        public DbSet<FooterAddress> FooterAddresses { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Supporter> Supporters { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<TitlesForAboutPage> TitlesForAboutPages { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("sqlcon");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUserRole>().HasKey(x => new { x.RoleId, x.UserId }); //composite key

            modelBuilder.Ignore<IdentityUserLogin<int>>();
            modelBuilder.Ignore<IdentityUserToken<int>>();
            modelBuilder.Ignore<IdentityUserClaim<int>>();
            modelBuilder.Ignore<IdentityRoleClaim<int>>();
            modelBuilder.Ignore<IdentityUserRole<int>>();

            //modelBuilder.Entity<BloodRequest>()
            //    .HasOne(br => br.City)
            //    .WithMany()
            //    .HasForeignKey(br => br.CityId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<BloodRequest>()
            //    .HasOne(br => br.District)
            //    .WithMany()
            //    .HasForeignKey(br => br.DistrictId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<BloodRequest>()
            //    .HasOne(br => br.Hospital)
            //    .WithMany()
            //    .HasForeignKey(br => br.HospitalId)
            //    .OnDelete(DeleteBehavior.NoAction);

        }



    }
}
