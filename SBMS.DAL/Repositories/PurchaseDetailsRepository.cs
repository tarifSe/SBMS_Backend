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
    }
}
