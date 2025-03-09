using AcilKan.Domain.Entities;
using AcilKan.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Persistence.Context
{
    public class AcilKanContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        private readonly IConfiguration _configuration;

        public AcilKanContext(DbContextOptions<AcilKanContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }


        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutBloodDonation> AboutBloodDonations { get; set; }
        public DbSet<AboutUs> AboutUses { get; set; }
        public DbSet<ArticlesForAboutPage> ArticlesForAboutPages { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<BloodDonation> BloodDonations { get; set; }
        public DbSet<BloodRequest> BloodRequests { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }
        public DbSet<ContactPage> ContactPages { get; set; }
        public DbSet<ContactUs> ContactUses { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<DonationBenefit> DonationBenefits { get; set; }
        public DbSet<FooterAddress> FooterAddresses { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Supporter> Supporters { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<TitlesForAboutPage> TitlesForAboutPages { get; set; }
        public DbSet<Chat> Chats { get; set; }



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
            //modelBuilder.Entity<AppUserRole>().HasKey(x => new { x.RoleId, x.UserId }); //composite key

            // Varsayılan Identity tablolarını kullan 
            modelBuilder.Entity<AppUser>().ToTable("AspNetUsers");
            modelBuilder.Entity<IdentityRole<int>>().ToTable("AspNetRoles");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("AspNetUserRoles")
                .HasKey(ur => new { ur.UserId, ur.RoleId });  

            modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("AspNetUserClaims");
            modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("AspNetUserLogins")
                .HasKey(l => new { l.LoginProvider, l.ProviderKey }); 

            modelBuilder.Entity<IdentityUserToken<int>>().ToTable("AspNetUserTokens")
                .HasKey(t => new { t.UserId, t.LoginProvider, t.Name }); 

            modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("AspNetRoleClaims");



            modelBuilder.Entity<AppUser>()
                .HasOne(a => a.City)
                .WithMany(c => c.AppUsers)
                .HasForeignKey(a => a.CityId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AppUser>()
                .HasOne(u => u.District)
                .WithMany()
                .HasForeignKey(u => u.DistrictId)
                .OnDelete(DeleteBehavior.NoAction);

            // AppUser ile BloodDonation ilişkisi
            modelBuilder.Entity<BloodDonation>()
                .HasOne(bd => bd.Donor)
                .WithMany(u => u.BloodDonations)
                .HasForeignKey(bd => bd.DonorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AppUser>()
                .Property(u => u.UserName)
                .HasComputedColumnSql("[Email]"); // Email'den türetilen bir hesaplanmış kolonu belirtir


            // FromUserId ile ilişkili olan ve ToUserId ile ilişkili olan yabancı anahtarlar için NoAction ekliyoruz
            modelBuilder.Entity<Chat>()
                .HasOne(chat => chat.FromUser) // FromUserId ilişkisi
                .WithMany() // Bir kullanıcı birden fazla sohbet başlatabilir
                .HasForeignKey(chat => chat.FromUserId) // FromUserId dış anahtar
                .OnDelete(DeleteBehavior.NoAction); // Silme işlemi yapılmaz

            modelBuilder.Entity<Chat>()
                .HasOne(chat => chat.ToUser) // ToUserId ilişkisi
                .WithMany() // Bir kullanıcıya birden fazla mesaj gidebilir
                .HasForeignKey(chat => chat.ToUserId) // ToUserId dış anahtar
                .OnDelete(DeleteBehavior.NoAction); // Silme işlemi yapılmaz


            // TC Kimlik Numarası Unique Olmalı User Tablosu
            modelBuilder.Entity<AppUser>()
                .HasIndex(u => u.TC)
                .IsUnique();

            // Telefon Numarası Unique Olmalı (Identity'nin yapısını bozmadan!)
            modelBuilder.Entity<AppUser>()
                .HasIndex(u => u.PhoneNumber)
                .IsUnique();

            // ENUM'u TinyInt olarak saklamak için User Tablosu
            modelBuilder.Entity<AppUser>()
                .Property(e => e.BloodGroup)
                .HasConversion<byte>();  // ENUM değerini TINYINT olarak sakla

            // ENUM'u TinyInt olarak saklamak için BloodRequest Tablosu
            modelBuilder.Entity<BloodRequest>()
                .Property(e => e.BloodGroup)
                .HasConversion<byte>();  // ENUM değerini TINYINT olarak sakla
              // ENUM'u TinyInt olarak saklamak için BloodRequest Tablosu
            modelBuilder.Entity<BloodRequest>()
                .Property(e => e.DemandReason)
                .HasConversion<byte>();  // ENUM değerini TINYINT olarak sakla

             // ENUM'u TinyInt olarak saklamak için BloodRequest Tablosu
            modelBuilder.Entity<BloodRequest>()
                .Property(e => e.Status)
                .HasConversion<byte>();  // ENUM değerini TINYINT olarak sakla
        }
    }
}