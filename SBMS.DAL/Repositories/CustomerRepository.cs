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
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SBMSDbContext sBMSDbContext) : base(sBMSDbContext)
        {
        }
    }
}
