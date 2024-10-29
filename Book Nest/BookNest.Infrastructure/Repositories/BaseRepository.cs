using BookNest.Infrastructure.DbContexts;
using BookNest.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookNest.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly BookNestDbContext _context;

        public BaseRepository(BookNestDbContext context)
        {
            _context = context;
        }

        //Return a list of entities: 
        public  async Task<IEnumerable<TEntity>> GetAsync(int pageNumber = 1, int pageSize = 10)
        {
            return await _context
                          .Set<TEntity>()
                          .AsNoTracking()
                          .OrderBy(e => EF.Property<int>(e, "Id"))
                          .Skip((pageNumber -1) * pageSize)
                          .Take(pageSize)
                          .ToListAsync();
        }

        //return an entity by id with the related data: 
        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            var response = await _context.Set<TEntity>()
                                            .FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
            return response;
        }
        
        //adding an entity to the data base then reurn the added entity:
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var response = await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return response.Entity;
        }

        //Updating an entity then return the updated entity:
        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
                return; 
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity?> DeleteAsync(int id)
        {
            var response = await _context.Set<TEntity>().FindAsync(id);

            if (response == null)
                return null;

            _context.Set<TEntity>().Remove(response);
            await _context.SaveChangesAsync();
            return response;
        }
        
        public async Task<TEntity?> GetByPropertyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context
                            .Set<TEntity>()
                            .FirstOrDefaultAsync(expression);
        }
    }
}