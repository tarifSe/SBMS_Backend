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
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        T? GetById(int id);
        IList<T> GetAll();
    }
}
