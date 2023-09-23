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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(SBMSDbContext sBMSDbContext) : base(sBMSDbContext)
        {
        }


        public override async Task<List<Product>> GetAll()
        {
            return await base.Table.Include(c => c.Category).ToListAsync();
        }
        public override Task<Product?> GetById(int id)
        {
            return base.Table.Include(c=>c.Category).Where(c=>c.Id == id).FirstOrDefaultAsync();
        }
    }
}
