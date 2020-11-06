using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dbBackend.Models
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Designation> Designation { get; set; }
        public virtual DbSet<Emp> Emp { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Salary> Salary { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = LAPTOP-SOPLE7JG\\SQLEXPRESS; Database = master; Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Designation>(entity =>
            {
                entity.ToTable("designation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(400)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("emp");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Designation).HasColumnName("designation");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.JoiningDate)
                    .HasColumnName("joining_date")
                    .HasColumnType("date");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.DesignationNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Designation)
                    .HasConstraintName("FK__employee__design__1D114BD1");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("salary");

                entity.Property(e => e.Grade)
                    .HasColumnName("grade")
                    .HasMaxLength(50)
                    .IsUnicode(false);


                entity.Property(e => e.SalId).HasColumnName("salID");

                entity.Property(e => e.Structure)
                    .HasColumnName("structure")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Tax)
                    .HasColumnName("tax")
                    .HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
