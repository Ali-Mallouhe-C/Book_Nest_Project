using BookNest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookNest.Infrastructure.Configurations
{
    public class RatingConfigurations : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasKey(a => a.Id);

            builder.ToTable("Ratings");

            //Configure the relation between rating and book
            builder.HasOne(r => r.Book)
                     .WithMany(b => b.Ratings)
                     .IsRequired()
                     .HasForeignKey(r => r.BookId)
                     .OnDelete(DeleteBehavior.Cascade);

            //Configure the relation between rating and user:
            builder.HasOne(r => r.User)
                    .WithMany()
                    .HasForeignKey(r => r.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
        }
    }
}
