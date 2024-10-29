using BookNest.Domain.Entities;
using BookNest.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace BookNest.Infrastructure.Repositories
{
    public class AuthorRepository : BaseRepository<Author>
    {
        private readonly BookNestDbContext _context;

        public AuthorRepository(BookNestDbContext context) : base(context)
        {
            _context = context;
        }

        public override Task<Author?> GetByIdAsync(int id)
        {
            return _context.Authors
                            .Where (a => a.Id == id)
                            .Include(a => a.Books)
                            .FirstOrDefaultAsync();
        }
    }

}
