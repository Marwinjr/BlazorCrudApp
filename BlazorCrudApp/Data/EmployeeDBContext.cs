using BlazorCrudApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorCrudApp.Data
{
    public partial class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext()
        {

        }

        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
            : base(options) { }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Designation)
                .HasMaxLength(10)
                .IsUnicode(false);

                entity.Property(e => e.EmployeeGovtId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EmployeeGovtID");

                entity.Property(e => e.EmployeeName)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");


            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
