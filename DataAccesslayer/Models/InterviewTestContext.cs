using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace DataAccesslayer.Models
{
    public partial class InterviewTestContext : DbContext
    {
        public InterviewTestContext()
        {
        }

        public InterviewTestContext(DbContextOptions<InterviewTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Location> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().
                                SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("InterviewTestDBConnectionString");
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ClosedDate)
                    .HasColumnType("date")
                    .HasColumnName("closedDate");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.DepartmentId)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("departmentId");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.LocationId)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("locationId");

                entity.Property(e => e.PostedDate)
                    .HasColumnType("date")
                    .HasColumnName("postedDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("fk_did");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("fk_lid");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasColumnType("numeric(6, 0)")
                    .HasColumnName("zip");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
