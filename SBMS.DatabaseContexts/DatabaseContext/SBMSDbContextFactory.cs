using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.DatabaseContexts.DatabaseContext
{
    public class SBMSDbContextFactory : IDesignTimeDbContextFactory<SBMSDbContext>
    {
        public SBMSDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SBMSDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-JS570QN\\SQLEXPRESS;Database=SBMS_Db;Trusted_Connection=True;TrustServerCertificate=True");

            return new SBMSDbContext(optionsBuilder.Options);
        }
    }
}
