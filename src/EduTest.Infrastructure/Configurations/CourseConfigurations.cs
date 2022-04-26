using EduTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduTest.Infrastructure.Configurations
{
    public class CourseConfigurations : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course");

            builder.Property(e => e.Id).HasColumnName("CourseId");

            builder.Property(e => e.CreationDate).HasColumnType("datetime");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.UpdateDate).HasColumnType("datetime");
        }
    }
}
