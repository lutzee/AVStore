﻿// <auto-generated />

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AVStore.DataAccess.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AVStore.Domain.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Balance");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<decimal>("Overdraft");

                    b.HasKey("Id")
                        .HasName("PK_Accounts");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("AVStore.Domain.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id")
                        .HasName("PK_Customers");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("AVStore.Domain.Models.CustomerAccount", b =>
                {
                    b.Property<int>("CustomerId");

                    b.Property<int>("AccountId");

                    b.HasKey("CustomerId", "AccountId")
                        .HasName("PK_CustomerAccounts");

                    b.HasIndex("AccountId");

                    b.ToTable("CustomerAccounts");
                });

            modelBuilder.Entity("AVStore.Domain.Models.Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("TypeId");

                    b.Property<string>("Value")
                        .IsRequired();

                    b.HasKey("Id")
                        .HasName("PK_Details");

                    b.HasIndex("TypeId");

                    b.ToTable("Details");
                });

            modelBuilder.Entity("AVStore.Domain.Models.DetailType", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id")
                        .HasName("PK_DetailTypes");

                    b.ToTable("DetailTypes");
                });

            modelBuilder.Entity("AVStore.Domain.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<int>("CustomerId");

                    b.Property<decimal>("OrderCost");

                    b.HasKey("Id")
                        .HasName("PK_Orders");

                    b.HasIndex("AccountId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("AVStore.Domain.Models.OrderLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Count");

                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.HasKey("Id")
                        .HasName("PK_OrderLines");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("AVStore.Domain.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(4000);

                    b.Property<bool>("InStock");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<decimal>("Price");

                    b.HasKey("Id")
                        .HasName("PK_Products");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("AVStore.Domain.Models.ProductDetail", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("DetailId");

                    b.HasKey("ProductId", "DetailId")
                        .HasName("PK_ProductDetails");

                    b.HasIndex("DetailId");

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("AVStore.Domain.Models.CustomerAccount", b =>
                {
                    b.HasOne("AVStore.Domain.Models.Account", "Account")
                        .WithMany("Owners")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK_CustomerAccounts_Accounts")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AVStore.Domain.Models.Customer", "Customer")
                        .WithMany("Accounts")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_CustomerAccounts_Customers")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AVStore.Domain.Models.Detail", b =>
                {
                    b.HasOne("AVStore.Domain.Models.DetailType", "Type")
                        .WithMany("Details")
                        .HasForeignKey("TypeId")
                        .HasConstraintName("FK_Details_DetailTypes")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AVStore.Domain.Models.Order", b =>
                {
                    b.HasOne("AVStore.Domain.Models.Account", "Account")
                        .WithMany("Orders")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK_Accounts_Orders")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AVStore.Domain.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AVStore.Domain.Models.OrderLine", b =>
                {
                    b.HasOne("AVStore.Domain.Models.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_Orders_OrderLines")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AVStore.Domain.Models.Product", "Product")
                        .WithMany("OrderLines")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_OrderLines_Products")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AVStore.Domain.Models.ProductDetail", b =>
                {
                    b.HasOne("AVStore.Domain.Models.Detail", "Detail")
                        .WithMany("ProductDetails")
                        .HasForeignKey("DetailId")
                        .HasConstraintName("FK_ProductDetails_Details")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AVStore.Domain.Models.Product", "Product")
                        .WithMany("ProductDetails")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_ProductDetails_Products")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
