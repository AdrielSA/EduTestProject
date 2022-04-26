using EduTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduTest.Infrastructure.Configurations
{
    public class MatterConfigurations : IEntityTypeConfiguration<Matter>
    {
        public void Configure(EntityTypeBuilder<Matter> builder)
        {
            builder.ToTable("Matter");

            builder.Property(e => e.Id).HasColumnName("MatterId");

            builder.Property(e => e.CreationDate).HasColumnType("datetime");

            builder.Property(e => e.EndTime).HasColumnType("datetime");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.StartTime).HasColumnType("datetime");

            builder.Property(e => e.UpdateDate).HasColumnType("datetime");

            builder.HasOne(d => d.Course)
                .WithMany(p => p.Matters)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MATTER_COURSE");
        }
    }
}
