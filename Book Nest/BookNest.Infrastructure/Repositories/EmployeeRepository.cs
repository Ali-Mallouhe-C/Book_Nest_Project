using BookNest.Domain.Entities;
using BookNest.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace BookNest.Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        private readonly BookNestDbContext _context;

        public EmployeeRepository(BookNestDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees
                                    .Include(e => e.Branch)
                                    .FirstOrDefaultAsync(e => e.Id == id);
        }
    }

}