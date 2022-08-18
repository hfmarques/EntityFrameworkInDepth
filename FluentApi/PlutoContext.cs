using FluentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FluentApi
{
    public class PlutoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server={server};Initial Catalog={database};Persist Security Info=False;User ID={user};Password={password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Cover> Covers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(c =>
            {
                c.Property(x => x.Name).IsRequired().HasMaxLength(255);
                c.Property(x => x.Description).IsRequired().HasMaxLength(255);
                c.HasOne(x => x.Cover)
                    .WithOne(x => x.Course)
                    .HasForeignKey<Cover>(x => x.CourseId);
                c.HasOne(x => x.Author)
                    .WithMany(x => x.Courses);
                c.HasMany(x => x.Tags)
                    .WithMany(x => x.Courses)
                    .UsingEntity(x => x.ToTable("CourseTags"));
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}