using Microsoft.EntityFrameworkCore;

namespace JWTAPI.WebApi.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product>? Products { get; set; }
        public virtual DbSet<User>? User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("UserId");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductID).HasColumnName("ProductID");


                entity.Property(e => e.ProductName)
                      .HasMaxLength(100)
                      .IsUnicode(false);

                entity.Property(e => e.ProductDetails)
                      .HasMaxLength(256)
                      .IsUnicode(false);


               
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
