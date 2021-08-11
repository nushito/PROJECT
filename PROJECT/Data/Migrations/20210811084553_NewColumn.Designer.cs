﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PROJECT.Data;

namespace PROJECT.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210811084553_NewColumn")]
    partial class NewColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InvoiceProduct", b =>
                {
                    b.Property<int>("InvoicesId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.HasKey("InvoicesId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("InvoiceProduct");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PROJECT.Data.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("PROJECT.Data.Models.BankDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<string>("Iban")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.Property<string>("Swift")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("Iban")
                        .IsUnique()
                        .HasFilter("[Iban] IS NOT NULL");

                    b.HasIndex("SupplierId");

                    b.ToTable("BankDetails");
                });

            modelBuilder.Entity("PROJECT.Data.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MyCompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MyCompanyId");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("PROJECT.Data.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("EIK")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("RepresentativePerson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VAT")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("ProductId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("PROJECT.Data.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MyCompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("MyCompanyId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("PROJECT.Data.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("PROJECT.Data.Models.MyCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Eik")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RepresentativePerson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VAT")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("MyCompanies");
                });

            modelBuilder.Entity("PROJECT.Data.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("MyCompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("MyCompanyId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PROJECT.Data.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DocumentId")
                        .HasColumnType("int");

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.HasIndex("OrderId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PROJECT.Data.Models.ProductCustomer", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "CustomerId");

                    b.ToTable("ProductCustomers");
                });

            modelBuilder.Entity("PROJECT.Data.Models.ProductInvoice", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "InvoiceId");

                    b.ToTable("ProductInvoice");
                });

            modelBuilder.Entity("PROJECT.Data.Models.ProductSpecification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("BankExpenses")
                        .HasColumnType("decimal");

                    b.Property<decimal>("Cubic")
                        .HasColumnType("decimal");

                    b.Property<decimal>("CustomsExpenses")
                        .HasColumnType("decimal");

                    b.Property<decimal>("Duty")
                        .HasColumnType("decimal");

                    b.Property<int>("Pieces")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("TerminalCharges")
                        .HasColumnType("decimal");

                    b.Property<decimal>("TransportCost")
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductSpecifications");
                });

            modelBuilder.Entity("PROJECT.Data.Models.ProductSupplier", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "SupplierId");

                    b.ToTable("ProductSuppliers");
                });

            modelBuilder.Entity("PROJECT.Data.Models.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvoiceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SipplierId")
                        .HasColumnType("int");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("PROJECT.Data.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BankDetailId")
                        .HasColumnType("int");

                    b.Property<string>("Eik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("RepresentativePerson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SupplierAddressId")
                        .HasColumnType("int");

                    b.Property<string>("VAT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BankDetailId");

                    b.HasIndex("SupplierAddressId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("ProductPurchase", b =>
                {
                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("PurchasesId")
                        .HasColumnType("int");

                    b.HasKey("ProductsId", "PurchasesId");

                    b.HasIndex("PurchasesId");

                    b.ToTable("ProductPurchase");
                });

            modelBuilder.Entity("ProductSupplier", b =>
                {
                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("SuppliersId")
                        .HasColumnType("int");

                    b.HasKey("ProductsId", "SuppliersId");

                    b.HasIndex("SuppliersId");

                    b.ToTable("ProductSupplier");
                });

            modelBuilder.Entity("InvoiceProduct", b =>
                {
                    b.HasOne("PROJECT.Data.Models.Invoice", null)
                        .WithMany()
                        .HasForeignKey("InvoicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PROJECT.Data.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PROJECT.Data.Models.BankDetails", b =>
                {
                    b.HasOne("PROJECT.Data.Models.MyCompany", "Company")
                        .WithMany("BankDetails")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PROJECT.Data.Models.Currency", "Currency")
                        .WithMany("BankDetails")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PROJECT.Data.Models.Supplier", null)
                        .WithMany("BankDetails")
                        .HasForeignKey("SupplierId");

                    b.Navigation("Company");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("PROJECT.Data.Models.Currency", b =>
                {
                    b.HasOne("PROJECT.Data.Models.MyCompany", null)
                        .WithMany("Currencies")
                        .HasForeignKey("MyCompanyId");
                });

            modelBuilder.Entity("PROJECT.Data.Models.Customer", b =>
                {
                    b.HasOne("PROJECT.Data.Models.Address", "ClientAddress")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PROJECT.Data.Models.Product", null)
                        .WithMany("Customers")
                        .HasForeignKey("ProductId");

                    b.Navigation("ClientAddress");
                });

            modelBuilder.Entity("PROJECT.Data.Models.Document", b =>
                {
                    b.HasOne("PROJECT.Data.Models.Customer", "Client")
                        .WithMany("Invoices")
                        .HasForeignKey("ClientId");

                    b.HasOne("PROJECT.Data.Models.MyCompany", null)
                        .WithMany("Invoices")
                        .HasForeignKey("MyCompanyId");

                    b.HasOne("PROJECT.Data.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId");

                    b.Navigation("Client");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("PROJECT.Data.Models.Invoice", b =>
                {
                    b.HasOne("PROJECT.Data.Models.Customer", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("PROJECT.Data.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId");

                    b.Navigation("Client");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("PROJECT.Data.Models.MyCompany", b =>
                {
                    b.HasOne("PROJECT.Data.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("PROJECT.Data.Models.Order", b =>
                {
                    b.HasOne("PROJECT.Data.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");

                    b.HasOne("PROJECT.Data.Models.MyCompany", "MyCompany")
                        .WithMany("Orders")
                        .HasForeignKey("MyCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("MyCompany");
                });

            modelBuilder.Entity("PROJECT.Data.Models.Product", b =>
                {
                    b.HasOne("PROJECT.Data.Models.Document", null)
                        .WithMany("Products")
                        .HasForeignKey("DocumentId");

                    b.HasOne("PROJECT.Data.Models.Order", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("PROJECT.Data.Models.ProductSpecification", b =>
                {
                    b.HasOne("PROJECT.Data.Models.Product", null)
                        .WithMany("ProductSpecifications")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("PROJECT.Data.Models.Purchase", b =>
                {
                    b.HasOne("PROJECT.Data.Models.Supplier", "Supplier")
                        .WithMany("Purchases")
                        .HasForeignKey("SupplierId");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("PROJECT.Data.Models.Supplier", b =>
                {
                    b.HasOne("PROJECT.Data.Models.BankDetails", "BankDetail")
                        .WithMany()
                        .HasForeignKey("BankDetailId");

                    b.HasOne("PROJECT.Data.Models.Address", "SupplierAddress")
                        .WithMany()
                        .HasForeignKey("SupplierAddressId");

                    b.Navigation("BankDetail");

                    b.Navigation("SupplierAddress");
                });

            modelBuilder.Entity("ProductPurchase", b =>
                {
                    b.HasOne("PROJECT.Data.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PROJECT.Data.Models.Purchase", null)
                        .WithMany()
                        .HasForeignKey("PurchasesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductSupplier", b =>
                {
                    b.HasOne("PROJECT.Data.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PROJECT.Data.Models.Supplier", null)
                        .WithMany()
                        .HasForeignKey("SuppliersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PROJECT.Data.Models.Currency", b =>
                {
                    b.Navigation("BankDetails");
                });

            modelBuilder.Entity("PROJECT.Data.Models.Customer", b =>
                {
                    b.Navigation("Invoices");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PROJECT.Data.Models.Document", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PROJECT.Data.Models.MyCompany", b =>
                {
                    b.Navigation("BankDetails");

                    b.Navigation("Currencies");

                    b.Navigation("Invoices");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PROJECT.Data.Models.Order", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PROJECT.Data.Models.Product", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("ProductSpecifications");
                });

            modelBuilder.Entity("PROJECT.Data.Models.Supplier", b =>
                {
                    b.Navigation("BankDetails");

                    b.Navigation("Purchases");
                });
#pragma warning restore 612, 618
        }
    }
}
