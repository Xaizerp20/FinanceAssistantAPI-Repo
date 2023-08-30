using FinanceAssistantAPI.Data;
using FinanceAssistantAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinanceAssistantAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        public readonly ApplicationDbContext _contextDb;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext contextDB) 
        {
            _contextDb = contextDB;

            this.dbSet = _contextDb.Set<T>();
        }

        public async Task Create(T entity)
        {
            await _contextDb.AddAsync(entity);
            await Save();
        }

        public async Task<T> Get(Expression<Func<T, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }



            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet;

           return await query.ToListAsync();
        }


        public async Task Delete(T entity)
        {
            _contextDb.Remove(entity);
            await Save();
        }


        public async Task Save()
        {
           await _contextDb.SaveChangesAsync();
        }
    }
}
