using LocalFarmer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFarmer.Data.Context
{
    public class LocalfarmerDbContext : DbContext
    {
        public LocalfarmerDbContext(DbContextOptions<LocalfarmerDbContext> options)
            : base(options)
        { 
     
        }

        public DbSet<Farmhouse> Farmhouses { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
