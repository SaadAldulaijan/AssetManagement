using AssetManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AssetManagement.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Category> Category { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Extension> Extension { get; set; }
        public DbSet<OtherAsset> OtherAsset { get; set; }
        public DbSet<Pager> Pager { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Telephone> Telephone { get; set; }
        public DbSet<Asset> Asset { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>().ToTable("Category");
            builder.Entity<Department>().ToTable("Department");
            builder.Entity<Employee>().ToTable("Employee");
            builder.Entity<Extension>().ToTable("Extension");
            builder.Entity<OtherAsset>().ToTable("OtherAsset");
            builder.Entity<Pager>().ToTable("Pager");
            builder.Entity<SubCategory>().ToTable("SubCategory");
            builder.Entity<Telephone>().ToTable("Telephone");
            builder.Entity<Asset>().ToTable("Asset").HasKey(k => new { k.TelephoneId, k.ExtensionId });
            
        }
    }
}
