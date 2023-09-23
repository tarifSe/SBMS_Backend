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

        public virtual async Task<bool> Add(T entity)
        {
            await Table.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> Update(T entity)
        {
            Table.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> Delete(T entity)
        {
            Table.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual async Task<T?> GetById(int id)
        {
            return await Table.FindAsync(id);
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await Table.ToListAsync();
        }
        
    }
}
