using BookNest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookNest.Infrastructure.Configurations
{
    public class ReservationConfigurations : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(b => b.Total)
            .HasColumnType("decimal(18,2)");

            builder.ToTable("Reservations");

            //Configure the relation between reservation and user:
            builder.HasOne(r => r.User)
                    .WithMany(u => u.Reservations)
                    .HasForeignKey(r => r.UserId)
                    .OnDelete(DeleteBehavior.NoAction);

            //Configure the relation between reservation and user:
            builder.HasOne(r => r.Book)
                    .WithMany(u => u.Reservations)
                    .HasForeignKey(r => r.BookId)
                    .OnDelete(DeleteBehavior.NoAction);

            //Configure the relation between reservation and user:
            builder.HasOne(r => r.Branch)
                    .WithMany(u => u.Reservations)
                    .HasForeignKey(r => r.BranchId)
                    .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
