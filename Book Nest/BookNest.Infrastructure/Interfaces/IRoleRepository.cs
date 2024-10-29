using BookNest.Domain.Entities;

namespace BookNest.Infrastructure.Interfaces
{
    public interface IRoleRepository
    {
        Task<Role?> GetByIdAsync(int id);
    }
}
