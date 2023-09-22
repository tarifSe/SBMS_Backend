using SBMS.BLL.Services;
using SBMS.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMS.BLL.Managers
{
    //This is base/generic Manager
    public class Manager<T> : IManager<T> where T : class
    {
        private readonly IRepository<T> _repository;
        public Manager(IRepository<T> repository)
        {
            _repository= repository;
        }

        public virtual bool Add(T entity)
        {
            return _repository.Add(entity);
        }
        public virtual bool Update(T entity)
        {
            return _repository.Update(entity);
        }

        public virtual bool Delete(T entity)
        {
            return _repository.Delete(entity);
        }

        public virtual T? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual IList<T> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
