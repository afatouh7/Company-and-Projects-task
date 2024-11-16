using CompanyBranchCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyBranchInfrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Branch> Branches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasOne(c => c.Branch)
                .WithOne(b => b.Company)
                .HasForeignKey<Branch>(b => b.CompanyId);
                  modelBuilder.Entity<Branch>()
                     .HasOne(b => b.Company)
                         .WithOne(c => c.Branch) // If one-to-one
                             .HasForeignKey<Branch>(b => b.CompanyId);
    
            modelBuilder.Entity<Company>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Branch>().HasQueryFilter(b => !b.IsDeleted);
        }
    }
}
