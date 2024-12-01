using AcilKan.Domain.Entities;
using AcilKan.Domain.Enums;
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
        public DbSet<BloodDonation> BloodDontaions { get; set; }
        public DbSet<BloodGroup> BloodGroups { get; set; }
        public DbSet<BloodRequest> BloodRequests { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }
        public DbSet<ContactPage> ContactPages { get; set; }
        public DbSet<ContactUs> ContactUses { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<DonationBenefit> DonationBenefits { get; set; }
        public DbSet<BloodDonation> DonationHistories { get; set; }
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
            modelBuilder.Entity<AppUserRole>().HasKey(x => new { x.RoleId, x.UserId }); //composite key

            modelBuilder.Ignore<IdentityUserLogin<int>>();
            modelBuilder.Ignore<IdentityUserToken<int>>();
            modelBuilder.Ignore<IdentityUserClaim<int>>();
            modelBuilder.Ignore<IdentityRoleClaim<int>>();
            modelBuilder.Ignore<IdentityUserRole<int>>();

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


            //modelBuilder.Entity<AppUser>()
            //    .Property(u => u.UserName)
            //    .HasDefaultValueSql("Email"); // Email ile eşleşmesini sağlıyoruz.

            //// Email alanının benzersiz olmasını sağlıyoruz
            //modelBuilder.Entity<AppUser>()
            //    .HasIndex(u => u.Email)
            //    .IsUnique();

            // Kan grubu enumunu string olarak veritabanında tutmak
            modelBuilder.Entity<BloodRequest>()
                .Property(b => b.BloodGroup)
                .HasConversion(
                    v => v.ToString(),  // Enum'ı string olarak saklama
                    v => (BloodGroupType)Enum.Parse(typeof(BloodGroupType), v)  // String'i Enum'a dönüştürme
                );

            modelBuilder.Entity<AppUser>()
                .Property(u => u.UserName)
                .HasComputedColumnSql("[Email]"); // Email'den türetilen bir hesaplanmış kolonu belirtir


            modelBuilder.Entity<BloodDonationApprove>()
                .HasOne(bda => bda.Donor) // BloodDonationApprove tablosundaki Donor ile ilişki
                .WithMany() // AppUser tablosunda bir koleksiyon yok
                .HasForeignKey(bda => bda.DonorId) // Foreign Key tanımı
                .OnDelete(DeleteBehavior.NoAction); // Cascade Delete yerine NoAction kullan

            modelBuilder.Entity<BloodDonationApprove>()
                .HasOne(bda => bda.RequestCreator) // BloodDonationApprove tablosundaki Donor ile ilişki
                .WithMany() // AppUser tablosunda bir koleksiyon yok
                .HasForeignKey(bda => bda.RequestCreatorId) // Foreign Key tanımı
                .OnDelete(DeleteBehavior.NoAction); // Cascade Delete yerine NoAction kullan


            modelBuilder.Entity<BloodDonation>()
                .HasOne(bda => bda.Donor) // BloodDonationApprove tablosundaki Donor ile ilişki
                .WithMany() // AppUser tablosunda bir koleksiyon yok
                .HasForeignKey(bda => bda.DonorId) // Foreign Key tanımı
                .OnDelete(DeleteBehavior.NoAction); // Cascade Delete yerine NoAction kullan


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


        }



    }
}
