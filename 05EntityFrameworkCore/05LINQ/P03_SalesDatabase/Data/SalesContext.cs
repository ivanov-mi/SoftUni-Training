namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class SalesContext : DbContext
    {
        public SalesContext()
        {
        }

        public SalesContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionConfig.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity
                    .Property(p => p.Name)
                    .IsUnicode(true);

                entity
                    .Property(p => p.Description)
                    .IsUnicode(true);
            });

            modelBuilder.Entity<Customer>(entity => 
            {
                entity
                    .Property(c => c.Name)
                    .IsUnicode(true);

                entity
                    .Property(c => c.Email)
                    .IsUnicode(false);

                entity
                    .Property(c => c.CreditCardNumber)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity
                    .Property(s => s.Name)
                    .IsUnicode(true);
            });
        }
    }
}
