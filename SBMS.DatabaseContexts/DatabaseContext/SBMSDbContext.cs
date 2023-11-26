using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SBMS.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.DatabaseContexts.DatabaseContext
{
    public class SBMSDbContext : DbContext
    {
        public SBMSDbContext(DbContextOptions<SBMSDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseDetails> PurchaseDetails { get; set; }











        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=DESKTOP-JS570QN\\SQLEXPRESS;Database=SBMS_Db;Trusted_Connection=True;TrustServerCertificate=True");
        //    }
        //}
    }
}
