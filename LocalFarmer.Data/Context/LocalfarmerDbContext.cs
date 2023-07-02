using LocalFarmer.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace LocalFarmer.Data.Context
{
    public class LocalfarmerDbContext : IdentityDbContext<IdentityUser>
    {
        public LocalfarmerDbContext(DbContextOptions<LocalfarmerDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
                (
                    new IdentityRole()
                    {
                        Name = "Admin",
                        ConcurrencyStamp = "1",
                        NormalizedName = "Admin"
                    },
                    new IdentityRole()
                    {
                        Name = "User",
                        ConcurrencyStamp = "2",
                        NormalizedName = "User"
                    }
                );
        }

        public DbSet<Farmhouse> Farmhouses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
    }
}
