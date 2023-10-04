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
    public abstract class Manager<T> : IManager<T> where T : class
    {
        private readonly IRepository<T> _repository;
        public Manager(IRepository<T> repository)
        {
            _repository= repository;
        }

        public virtual async Task<bool> Add(T entity)
        {
            return await _repository.Add(entity);
        }
        public virtual async Task<bool> Update(T entity)
        {
            return await _repository.Update(entity);
        }

        public virtual async Task<bool> Delete(T entity)
        {
            return await _repository.Delete(entity);
        }

        public virtual async Task<T?> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _repository.GetAll();
        }

    }
}
