﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Universeauto.Models;

#nullable disable

namespace Universeauto.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230801092932_AddAutoClassForClassAuto")]
    partial class AddAutoClassForClassAuto
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Universeauto.Models.AutoClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<long?>("CarId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("AutoClass");
                });

            modelBuilder.Entity("Universeauto.Models.Car", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<string>("GovNomber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Universeauto.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Universeauto.Models.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Universeauto.Models.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Car")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("CustomerPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("DateAdded")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DateFinish")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DateStart")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Universeauto.Models.OrderLine", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<decimal?>("PriceCustomer")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PriceEmployee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("Universeauto.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("CategoryId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("RetailPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Universeauto.Models.AutoClass", b =>
                {
                    b.HasOne("Universeauto.Models.Car", null)
                        .WithMany("ClassAuto")
                        .HasForeignKey("CarId");
                });

            modelBuilder.Entity("Universeauto.Models.Car", b =>
                {
                    b.HasOne("Universeauto.Models.Customer", "Customer")
                        .WithMany("Cars")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Universeauto.Models.Order", b =>
                {
                    b.HasOne("Universeauto.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Universeauto.Models.OrderLine", b =>
                {
                    b.HasOne("Universeauto.Models.Order", "order")
                        .WithMany("Lines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Universeauto.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("order");
                });

            modelBuilder.Entity("Universeauto.Models.Product", b =>
                {
                    b.HasOne("Universeauto.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Universeauto.Models.Car", b =>
                {
                    b.Navigation("ClassAuto");
                });

            modelBuilder.Entity("Universeauto.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Universeauto.Models.Customer", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("Universeauto.Models.Order", b =>
                {
                    b.Navigation("Lines");
                });
#pragma warning restore 612, 618
        }
    }
}
