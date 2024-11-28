using Microsoft.EntityFrameworkCore;
using SBMS.DAL.Services;
using SBMS.DatabaseContexts.DatabaseContext;
using SBMS.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.DAL.Repositories
{
    public class PurchaseDetailsRepository : Repository<PurchaseDetails>, IPurchaseDetailsRepository
    {
        public PurchaseDetailsRepository(SBMSDbContext sBMSDbContext) : base(sBMSDbContext)
        {
        }

        public override async Task<List<PurchaseDetails>> GetAll()
        {
            return await base.Table.Include(c => c.Product).ToListAsync();
        }

        public override Task<PurchaseDetails?> GetById(int id)
        {
            return base.Table.Include(c => c.Product).Where(c => c.Id == id).FirstOrDefaultAsync();
        }
    }
}
