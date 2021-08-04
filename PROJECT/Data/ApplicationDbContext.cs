
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PROJECT.Data.Models;

namespace PROJECT.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BankDetails> BankDetails { get; set; }
        public DbSet<Customer> Clients { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<MyCompany> MyCompanies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BankDetails>()
                .HasIndex(a => a.Iban)
                .IsUnique(true);


            builder.Entity<BankDetails>()
                .HasOne(a => a.Currency)
                .WithMany(a => a.BankDetails)
                .HasForeignKey(a => a.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Product>()
           .Property(a => a.BankExpenses)
           .HasColumnType("decimal");

            builder.Entity<Product>()
                .Property(a => a.CustomsExpenses)
                .HasColumnType("decimal");

            builder.Entity<Product>()
                .Property(a => a.Duty)
                .HasColumnType("decimal");

            builder.Entity<Product>()
                .Property(a => a.Price)
                .HasColumnType("decimal");

            builder.Entity<Product>()
                .Property(a => a.Quantity)
                .HasColumnType("decimal");

            builder.Entity<Product>()
                .Property(a => a.TerminalCharges)
                .HasColumnType("decimal");

            builder.Entity<Product>()
                .Property(a => a.TransportCost)
                .HasColumnType("decimal");

        

            base.OnModelCreating(builder);
        }
    }
}
