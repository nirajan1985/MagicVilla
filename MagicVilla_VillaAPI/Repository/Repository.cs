using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbset;


        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbset= db.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await dbset.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true)
        {
            IQueryable<T> query = dbset;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, int pageSize = 0, int pageNumber = 1)
        {
            IQueryable<T> query = dbset;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if(pageSize> 0)
            {
                if (pageSize > 100)
                {
                    pageSize= 100;
                }
                query=query.Skip(pageSize*(pageNumber-1)).Take(pageSize);
                //pageSize=5
                // Skip 5*(1-1). Take(5), Skip 0 Take 5
                //Skip 5(2-1). Take(5), Skip 5 Take 5
            }
            return await query.ToListAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            dbset.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        
    }
}
