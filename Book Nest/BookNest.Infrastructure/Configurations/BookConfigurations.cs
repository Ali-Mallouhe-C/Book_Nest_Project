using BookNest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookNest.Infrastructure.Configurations
{
    public class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(b => b.Price)
            .HasColumnType("decimal(18,2)");

            builder.ToTable("Books");

            //Configure the relation between book and category:
            builder.HasOne(b => b.Author)
                    .WithMany(a => a.Books)
                    .IsRequired()
                    .HasForeignKey(b => b.AuthorId)
                    .HasConstraintName("FK_Author_Books_AuthorId")
                    .OnDelete(DeleteBehavior.Cascade);

            //Configure the relation between book and author:
            builder.HasOne(b => b.Category)
                    .WithMany(c => c.Books)
                    .IsRequired()
                    .HasForeignKey(b => b.AuthorId)
                    .HasConstraintName("FK_Category_Books_CategoryId")
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
