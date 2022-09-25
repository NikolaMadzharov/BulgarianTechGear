using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BulgarianTechGear.Data
{
    using BulgarianTechGear.Data.Models;

    public class BulgarianTechGearDbContext : IdentityDbContext
    {
        public BulgarianTechGearDbContext(DbContextOptions<BulgarianTechGearDbContext> options)
            : base(options)
        {
        }

        public DbSet<MobilePhone> MobilePhones { get; set; }
        public DbSet<MobilePhoneBrand> MobilePhoneBrands { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MobilePhone>().HasOne(m => m.MobilePhoneBrand).WithMany(m => m.MobilePhones)
                .HasForeignKey(m => m.MobilePhoneBrandId).OnDelete(DeleteBehavior.Restrict);

          

            base.OnModelCreating(builder);
        }

    }
}