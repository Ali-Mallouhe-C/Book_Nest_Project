using BookNest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookNest.Infrastructure.Configurations
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(b => b.Salary)
            .HasColumnType("decimal(18,2)");

            builder.ToTable("Employees");

            //Configure the relation between Employee and User:
            builder.HasOne(e => e.User)
                    .WithOne()
                    .HasForeignKey<Employee>(e => e.UserId)
                    .HasConstraintName("FK_User_Employee_UserId")
                    .OnDelete(DeleteBehavior.Cascade);

            //Configure the relation between Employee and Branch:
            builder.HasOne(e => e.Branch)
                    .WithMany(b => b.Employees)
                    .HasForeignKey(e => e.BranchId)
                    .HasConstraintName("FK_Branch_Employee_BranchId")
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
