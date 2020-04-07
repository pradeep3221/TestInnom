using Microsoft.EntityFrameworkCore;

namespace TestInnom.Product.DataModels.Models
{
    public partial class TestInnomDBContext : DbContext
    {
        public TestInnomDBContext()
        {
        }

        public TestInnomDBContext(DbContextOptions<TestInnomDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProductDto> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=TestInnomDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDto>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Color).HasMaxLength(15);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Size).HasMaxLength(5);

                entity.Property(e => e.ValidFrom).HasColumnType("datetime2(0)");

                entity.Property(e => e.ValidTo).HasColumnType("datetime2(0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
