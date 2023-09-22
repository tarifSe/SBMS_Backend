using Microsoft.EntityFrameworkCore;
using SBMS.DAL.Services;
using SBMS.DatabaseContexts.DatabaseContext;

namespace SBMS.DAL.Repositories
{
    //This is generic class
    public abstract class Repository<T>:IRepository<T> where T:class
    {
        private readonly SBMSDbContext _context;
        public Repository(SBMSDbContext sBMSDbContext)
        {
            _context = sBMSDbContext;
        }
        public DbSet<T> Table { 
            get 
            { 
                return _context.Set<T>();
            } 
        }

        public virtual bool Add(T entity)
        {
            Table.Add(entity);
            return _context.SaveChanges() > 0;
        }

        public virtual bool Update(T entity)
        {
            Table.Update(entity);
            return _context.SaveChanges() > 0;
        }

        public virtual bool Delete(T entity)
        {
            Table.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public virtual T? GetById(int id)
        {
            return Table.Find(id);
        }

        public virtual IList<T> GetAll()
        {
            return Table.ToList();
        }
    }
}
