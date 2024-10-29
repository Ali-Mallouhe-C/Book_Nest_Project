using BookNest.Domain.Entities;
using BookNest.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace BookNest.Infrastructure.Repositories
{
    public class BookRepository : BaseRepository<Book>
    {
        private readonly BookNestDbContext _context;

        public BookRepository(BookNestDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books
                                    .Where(b => b.Id == id)
                                    .Include(b => b.Category)
                                    .Include(b => b.Author)
                                    .Include(b => b.Ratings)
                                    .FirstOrDefaultAsync();
        }
    }

}
