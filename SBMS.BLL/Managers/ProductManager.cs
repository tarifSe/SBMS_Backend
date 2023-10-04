using SBMS.BLL.Services;
using SBMS.DAL.Services;
using SBMS.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.BLL.Managers
{
    public class ProductManager : Manager<Product>, IProductManager
    {
        public ProductManager(IProductRepository repository) : base(repository)
        {
        }
    }
}
