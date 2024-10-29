using BookNest.Domain.Entities;
using BookNest.Infrastructure.DbContexts;
using BookNest.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookNest.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly BookNestDbContext _context;

        public RoleRepository(BookNestDbContext context)
        {
            _context = context;
        }
        public async Task<Role?> GetByIdAsync(int id)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
