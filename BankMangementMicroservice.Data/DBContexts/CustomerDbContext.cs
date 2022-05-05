using BankMangementMicroservice.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace BankMangementMicroservice.Data.DBContexts
{
    public partial class CustomerDbContext : DbContext
    {
        public CustomerDbContext()
        {
        }
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomerDetail> CustomerDetail { get; set; }
        public virtual DbSet<LoanDetail> LoanDetail { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=BankManagement_DB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CustomerDetail>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId })
                    .HasName("PK_CustomerId");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LoanDetail>(entity =>
            {
                entity.HasKey(e => e.LoanId)
                    .HasName("PK_LoanId");

                entity.ToTable("LoanDetail");
              
                entity.HasOne(d => d.CustomerDetail)
                    .WithMany(p => p.LoanDeatils)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("Fk_LoanDeatil_CustomerId");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
