using BookNest.Domain.Entities;
using BookNest.Infrastructure.DbContexts;

namespace BookNest.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(BookNestDbContext context) : base(context)
        {
        }
    }

}
