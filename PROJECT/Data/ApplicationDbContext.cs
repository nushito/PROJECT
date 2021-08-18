
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
        public DbSet<ProductSupplier> ProductSuppliers { get; set; }
        public DbSet<ProductCustomer> ProductCustomers { get; set; }
        public DbSet<ProductSpecification> ProductSpecifications { get; set; }
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

            builder.Entity<ProductSpecification>()
           .Property(a => a.BankExpenses)
           .HasColumnType("decimal");

            builder.Entity<ProductSpecification>()
                .Property(a => a.CustomsExpenses)
                .HasColumnType("decimal");

            builder.Entity<ProductSpecification>()
                .Property(a => a.Duty)
                .HasColumnType("decimal");

            builder.Entity<ProductSpecification>()
                .Property(a => a.Price)
                .HasColumnType("decimal");

            builder.Entity<ProductSpecification>()
                .Property(a => a.Cubic)
                .HasColumnType("decimal");

            builder.Entity<ProductSpecification>()
                .Property(a => a.TerminalCharges)
                .HasColumnType("decimal");

            builder.Entity<ProductSpecification>()
                .Property(a => a.TransportCost)
                .HasColumnType("decimal");

            builder.Entity<ProductSpecification>()
                .Property(a => a.CostPrice)
                .HasColumnType("decimal");

            builder.Entity<ProductSpecification>()
                .Property(a => a.Income)
                .HasColumnType("decimal");

            builder.Entity<ProductSpecification>()
                .Property(a => a.SoldPrice)
                .HasColumnType("decimal");

            builder.Entity<ProductSupplier>()
                    .HasKey(a => new { a.ProductId, a.SupplierId });

            builder.Entity<ProductCustomer>()
                    .HasKey(a => new { a.ProductId, a.CustomerId });

            builder.Entity<ProductInvoice>()
                   .HasKey(a => new { a.ProductId, a.InvoiceId });

            builder.Entity<Document>()
                .Property(a => a.SubTotal)
                .HasColumnType("decimal");

            builder.Entity<Document>()
                .Property(a => a.Total)
                .HasColumnType("decimal");

            builder.Entity<Purchase>()
                .HasOne(a => a.Supplier)
                .WithMany(a => a.Purchases)
                .HasForeignKey(a => a.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
