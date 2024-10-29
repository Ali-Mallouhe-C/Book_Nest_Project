using BookNest.Domain.Entities;
using BookNest.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace BookNest.Infrastructure.Repositories
{
    public class RatingRepository : BaseRepository<Rating>
    {
        private readonly BookNestDbContext _context;

        public RatingRepository(BookNestDbContext context) : base(context)
        {
            _context = context;
        }

        //cheack if there is a rating with this userId, bookId ==> update it ?? add new 
        public override async Task<Rating> AddAsync(Rating entity)
        {
            var existingRating = await _context.Rating
                                                .FirstOrDefaultAsync(r => r.UserId == entity.UserId && r.BookId == entity.BookId);
        
            if (existingRating is not null)
            {
                existingRating.Star = entity.Star;
                existingRating.FeedBack = entity.FeedBack;
            }
            else
            {
                var rating = new Rating()
                {
                    Star = entity.Star,
                    FeedBack = entity.FeedBack,
                    UserId = entity.UserId ,
                    BookId = entity.BookId
                };
                await _context.AddAsync(rating);
            }
            await _context.SaveChangesAsync();
            return entity;
        }
    }

}
