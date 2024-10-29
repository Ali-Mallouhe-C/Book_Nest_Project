using BookNest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookNest.Infrastructure.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.Id);

            builder.ToTable("Users");

            builder.HasIndex(u => u.Email).IsUnique();

            //Configure the relation between role and user
            builder.HasOne(u => u.Role)
                        .WithMany()
                        .HasForeignKey(u => u.RoleId)
                        .HasConstraintName("FK_Role_User_RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
