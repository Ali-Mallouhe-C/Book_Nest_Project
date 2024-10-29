using BookNest.Domain.Entities;
using BookNest.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace BookNest.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        private readonly BookNestDbContext _context;

        public CategoryRepository(BookNestDbContext context) : base(context)
        {
            _context = context;
        }

        public override Task<Category?> GetByIdAsync(int id)
        {
            return _context.Categories
                            .Include(c => c.Books)
                            .FirstOrDefaultAsync(c => c.Id == id);
        }
    }

}
