using BookNest.Domain.Entities;
using BookNest.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace BookNest.Infrastructure.Repositories
{
    public class ReservationRepository : BaseRepository<Reservation>
    {
        private readonly BookNestDbContext _context;

        public ReservationRepository(BookNestDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Reservation?> GetByIdAsync(int id)
        {
            return await _context.Reservations
                                    .Where(r => r.Id == id)
                                    .Include(r => r.Book)
                                    .Include(r => r.User)
                                    .Include(r => r.Branch)
                                    .FirstOrDefaultAsync();
        }
    }
}