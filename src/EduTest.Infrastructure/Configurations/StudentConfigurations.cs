using EduTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduTest.Infrastructure.Configurations
{
    public class StudentConfigurations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");

            builder.HasIndex(e => e.Email, "UQ_EMAIL_STUDENT")
                .IsUnique();

            builder.Property(e => e.Id).HasColumnName("StudentId");

            builder.Property(e => e.CreationDate).HasColumnType("datetime");

            builder.Property(e => e.DateOfBirth).HasColumnType("datetime");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.UpdateDate).HasColumnType("datetime");

            builder.HasOne(d => d.Course)
                .WithMany(p => p.Students)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_STUDENT_COURSE");

            builder.HasOne(d => d.Matter)
                .WithMany(p => p.Students)
                .HasForeignKey(d => d.MatterId)
                .HasConstraintName("FK_STUDENT_MATTER");
        }
    }
}
