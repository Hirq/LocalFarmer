﻿using LocalFarmer.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LocalFarmer.Data.Context
{
    public class LocalfarmerDbContext : IdentityDbContext<IdentityUser>
    {
        public LocalfarmerDbContext(DbContextOptions<LocalfarmerDbContext> options)
            : base(options)
        {

        }

        public DbSet<Farmhouse> Farmhouses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
    }
}
