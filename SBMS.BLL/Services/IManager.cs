using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.BLL.Services
{
    //This is base/generic IManager
    public interface IManager<T> where T : class
    {
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<T?> GetById(int id);
        Task<List<T>> GetAll();
    }
}
