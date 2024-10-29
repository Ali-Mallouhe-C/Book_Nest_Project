using BookNest.Domain.Entities;
using BookNest.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace BookNest.Infrastructure.Repositories
{
    public class BranchRepository : BaseRepository<Branch>
    {
        private readonly BookNestDbContext _context;

        public BranchRepository(BookNestDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Branch?> GetByIdAsync(int id)
        {
            return await _context.Branches
                                    .Include(r => r.Employees)
                                    .FirstOrDefaultAsync(b => b.Id == id);
        }
    }

}
