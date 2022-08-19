using FluentApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentApi.EntityConfigurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(255);
        builder.HasOne(x => x.Cover)
            .WithOne(x => x.Course)
            .HasForeignKey<Cover>(x => x.CourseId);
        builder.HasOne(x => x.Author)
            .WithMany(x => x.Courses);
        builder.HasMany(x => x.Tags)
            .WithMany(x => x.Courses)
            .UsingEntity(x => x.ToTable("CourseTags"));
    }
}