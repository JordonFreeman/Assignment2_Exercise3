using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using OrderManagement.RazorWeb.Models;

namespace OrderManagement.RazorWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Suppress the warning about pending model changes
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Item
            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(i => i.ItemID);
                entity.ToTable("Item"); // Exact match to database table

                entity.Property(i => i.ItemName)
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();

                entity.Property(i => i.Size)
                    .HasColumnType("nvarchar(50)");

                entity.Property(i => i.UnitPrice)
                    .HasColumnType("decimal(18, 2)")
                    .IsRequired();

                entity.Property(i => i.StockQuantity)
                    .IsRequired();

                entity.Property(i => i.Description)
                    .HasColumnType("nvarchar(500)");
            });

            // Configure Agent
            modelBuilder.Entity<Agent>(entity =>
            {
                entity.HasKey(a => a.AgentID);
                entity.ToTable("Agent"); // Exact match to database table

                entity.Property(a => a.AgentName)
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();

                entity.Property(a => a.Address)
                    .HasColumnType("nvarchar(200)")
                    .IsRequired();

                entity.Property(a => a.ContactNumber)
                    .HasColumnType("nvarchar(20)");

                entity.Property(a => a.Email)
                    .HasColumnType("nvarchar(100)");
            });

            // Configure Order - try without brackets
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.OrderID);

                // Try without brackets
                entity.ToTable("Order");

                entity.Property(o => o.OrderDate)
                    .IsRequired();

                entity.Property(o => o.Status)
                    .HasColumnType("nvarchar(20)");

                entity.Property(o => o.TotalAmount)
                    .HasColumnType("decimal(18, 2)")
                    .IsRequired();

                // Configure relationship with Agent
                entity.HasOne(o => o.Agent)
                    .WithMany(a => a.Orders) // Bidirectional relationship
                    .HasForeignKey(o => o.AgentID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure OrderDetail
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(od => od.Id);
                entity.ToTable("OrderDetail"); // Exact match to database table
                entity.Property(od => od.Id).HasColumnName("ID"); // Match the actual column name

                entity.Property(od => od.Quantity)
                    .IsRequired();

                entity.Property(od => od.UnitAmount)
                    .HasColumnType("decimal(18, 2)")
                    .IsRequired();

                entity.Property(od => od.TotalAmount)
                    .HasColumnType("decimal(18, 2)")
                    .IsRequired();

                // Configure relationship with Item
                entity.HasOne(od => od.Item)
                    .WithMany(i => i.OrderDetails) // Bidirectional relationship
                    .HasForeignKey(od => od.ItemID)
                    .OnDelete(DeleteBehavior.Restrict);

                // Configure relationship with Order
                entity.HasOne(od => od.Order)
                    .WithMany(o => o.OrderDetails) // Bidirectional relationship
                    .HasForeignKey(od => od.OrderID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserID);
                entity.ToTable("Users"); // This one is plural in the database

                entity.Property(u => u.UserName)
                    .HasColumnType("nvarchar(50)")
                    .IsRequired();

                entity.Property(u => u.Password)
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();

                entity.Property(u => u.Email)
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();

                entity.Property(u => u.IsLocked)
                    .HasDefaultValue(false);

                entity.Property(u => u.Role)
                    .HasColumnType("nvarchar(20)")
                    .HasDefaultValue("User");

                entity.Property(u => u.LastLogin);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}