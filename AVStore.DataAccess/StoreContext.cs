using AVStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AVStore.DataAccess
{
    public class StoreContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<DetailType> DetailTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Localhost\\SQLEXPRESS;Database=AVStore;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(x =>
            {
                x.ToTable("Products");
                x.HasKey(p => p.Id)
                    .HasName("PK_Products");

                x.Property(p => p.Id)
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                x.Property(p => p.Description)
                    .HasMaxLength(4000);

                x.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(1000);

                x.Property(p => p.Price)
                    .IsRequired();

                x.Property(p => p.InStock)
                    .IsRequired();
            });

            modelBuilder.Entity<ProductDetail>(x =>
            {
                x.ToTable("ProductDetails");
                x.HasKey(pd => new { pd.ProductId, pd.DetailId })
                    .HasName("PK_ProductDetails");

                x.HasOne(pd => pd.Product)
                    .WithMany(p => p.ProductDetails)
                    .HasForeignKey(pd => pd.ProductId)
                    .HasConstraintName("FK_ProductDetails_Products");

                x.HasOne(pd => pd.Detail)
                    .WithMany(d => d.ProductDetails)
                    .HasForeignKey(pd => pd.DetailId)
                    .HasConstraintName("FK_ProductDetails_Details");
            });

            modelBuilder.Entity<Detail>(x =>
            {
                x.ToTable("Details");
                x.HasKey(d => d.Id)
                    .HasName("PK_Details");

                x.Property(d => d.Id)
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                x.Property(d => d.Value)
                    .IsRequired();

                x.Property(d => d.Key)
                    .IsRequired()
                    .HasMaxLength(100);

                x.HasOne(d => d.Type)
                    .WithMany(dt => dt.Details)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Details_DetailTypes");
            });

            modelBuilder.Entity<DetailType>(x =>
            {
                x.ToTable("DetailTypes");
                x.HasKey(dt => dt.Id)
                    .HasName("PK_DetailTypes");
                    
                x.Property(dt => dt.Id)
                    .IsRequired()
                    .ValueGeneratedNever();

                x.Property(dt => dt.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                x.Ignore(dt => dt.ValueType);
            });

            modelBuilder.Entity<Order>(x =>
            {
                x.ToTable("Orders");
                x.HasKey(o => o.Id)
                    .HasName("PK_Orders");

                x.Property(o => o.Id)
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd();

                x.Property(o => o.OrderCost)
                    .IsRequired();

                x.HasMany(o => o.OrderLines)
                    .WithOne(ol => ol.Order)
                    .HasForeignKey(ol => ol.OrderId)
                    .HasConstraintName("FK_Orders_OrderLines");
            });

            modelBuilder.Entity<OrderLine>(x =>
            {
                x.ToTable("OrderLines");
                x.HasKey(ol => ol.Id)
                    .HasName("PK_OrderLines");

                x.Property(ol => ol.Count)
                    .IsRequired();

                x.Ignore(ol => ol.LineCost);

                x.HasOne(ol => ol.Product)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(ol => ol.ProductId)
                    .HasConstraintName("FK_OrderLines_Products");
            });

            modelBuilder.Entity<Customer>(x =>
            {
                x.ToTable("Customers");
                x.HasKey(c => c.Id)
                    .HasName("PK_Customers");

                x.Property(c => c.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                x.Property(c => c.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
                
                x.Ignore(c => c.Name);
            });

            modelBuilder.Entity<CustomerAccount>(x =>
            {
                x.ToTable("CustomerAccounts");
                x.HasKey(pd => new { pd.CustomerId, pd.AccountId })
                    .HasName("PK_CustomerAccounts");

                x.HasOne(ca => ca.Customer)
                    .WithMany(c => c.Accounts)
                    .HasForeignKey(ca => ca.CustomerId)
                    .HasConstraintName("FK_CustomerAccounts_Customers");

                x.HasOne(ca => ca.Account)
                    .WithMany(a => a.Owners)
                    .HasForeignKey(ca => ca.AccountId)
                    .HasConstraintName("FK_CustomerAccounts_Accounts");
            });

            modelBuilder.Entity<Account>(x =>
            {
                x.ToTable("Accounts");
                x.HasKey(a => a.Id)
                    .HasName("PK_Accounts");

                x.Property(a => a.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                x.Property(a => a.Balance)
                    .IsRequired();

                x.Property(a => a.Overdraft)
                    .IsRequired();

                x.HasMany(a => a.Orders)
                    .WithOne(o => o.Account)
                    .HasForeignKey(a => a.AccountId)
                    .HasConstraintName("FK_Accounts_Orders");
            });
        }
    }
}
