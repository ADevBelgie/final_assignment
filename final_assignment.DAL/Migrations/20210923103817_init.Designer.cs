﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using final_assignment.DAL.Data.DB;

namespace final_assignment.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210923103817_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("final_assignment.Common.Models.LoginModel", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RememberLogin")
                        .HasColumnType("bit");

                    b.Property<string>("ReturnUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShoppingBagId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginId");

                    b.HasAlternateKey("UserName");

                    b.ToTable("Logins");

                    b.HasData(
                        new
                        {
                            LoginId = 1,
                            Password = "admin",
                            RememberLogin = false,
                            Role = "admin",
                            ShoppingBagId = 0,
                            UserName = "admin1"
                        },
                        new
                        {
                            LoginId = 2,
                            Password = "arthur",
                            RememberLogin = false,
                            Role = "normal",
                            ShoppingBagId = 0,
                            UserName = "arthur"
                        });
                });

            modelBuilder.Entity("final_assignment.Common.Models.ProductModel", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AmountInStock")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Obsolete")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("ProductType")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("product_type");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Category").HasValue("blog_base");
                });

            modelBuilder.Entity("final_assignment.Common.Models.ShoppingBagModel", b =>
                {
                    b.Property<int>("ShoppingBagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LoginId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("ShoppingBagId");

                    b.HasIndex("LoginId")
                        .IsUnique();

                    b.ToTable("ShoppingBags");

                    b.HasData(
                        new
                        {
                            ShoppingBagId = 1,
                            LoginId = 1,
                            TimeCreated = new DateTime(2021, 9, 23, 13, 38, 17, 494, DateTimeKind.Local).AddTicks(4322)
                        },
                        new
                        {
                            ShoppingBagId = 2,
                            LoginId = 2,
                            TimeCreated = new DateTime(2021, 9, 23, 13, 38, 17, 495, DateTimeKind.Local).AddTicks(2820)
                        });
                });

            modelBuilder.Entity("final_assignment.Common.Models.ShoppingItemModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ShoppingBagId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShoppingBagId");

                    b.ToTable("ShoppingItems");
                });

            modelBuilder.Entity("final_assignment.Common.Models.FoodModel", b =>
                {
                    b.HasBaseType("final_assignment.Common.Models.ProductModel");

                    b.Property<int>("QuantityInPackage")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("QuantityInPackage");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            AmountInStock = 10,
                            Description = "Jummy food",
                            Name = "Pizza",
                            Obsolete = false,
                            Price = 50m,
                            ProductType = "food",
                            QuantityInPackage = 3
                        },
                        new
                        {
                            ProductId = 2,
                            AmountInStock = 0,
                            Description = "Bug food",
                            Name = "Flies",
                            Obsolete = false,
                            Price = 32m,
                            ProductType = "food",
                            QuantityInPackage = 3
                        },
                        new
                        {
                            ProductId = 3,
                            AmountInStock = 0,
                            Description = "Dog food",
                            Name = "Dog Crunch",
                            Obsolete = true,
                            Price = 19m,
                            ProductType = "food",
                            QuantityInPackage = 3
                        },
                        new
                        {
                            ProductId = 4,
                            AmountInStock = 8,
                            Description = "Fatty food",
                            Name = "Jelly",
                            Obsolete = false,
                            Price = 19m,
                            ProductType = "food",
                            QuantityInPackage = 18
                        },
                        new
                        {
                            ProductId = 5,
                            AmountInStock = 150,
                            Description = "Chocolate food",
                            Name = "Choco",
                            Obsolete = false,
                            Price = 19m,
                            ProductType = "food",
                            QuantityInPackage = 5
                        },
                        new
                        {
                            ProductId = 6,
                            AmountInStock = 10,
                            Description = "Jummy food",
                            Name = "Pizza",
                            Obsolete = false,
                            Price = 50m,
                            ProductType = "food",
                            QuantityInPackage = 3
                        },
                        new
                        {
                            ProductId = 7,
                            AmountInStock = 0,
                            Description = "Bug food",
                            Name = "Flies",
                            Obsolete = false,
                            Price = 32m,
                            ProductType = "food",
                            QuantityInPackage = 3
                        },
                        new
                        {
                            ProductId = 8,
                            AmountInStock = 0,
                            Description = "Dog food",
                            Name = "Dog Crunch",
                            Obsolete = true,
                            Price = 19m,
                            ProductType = "food",
                            QuantityInPackage = 3
                        },
                        new
                        {
                            ProductId = 9,
                            AmountInStock = 8,
                            Description = "Fatty food",
                            Name = "Jelly",
                            Obsolete = false,
                            Price = 19m,
                            ProductType = "food",
                            QuantityInPackage = 18
                        },
                        new
                        {
                            ProductId = 10,
                            AmountInStock = 150,
                            Description = "Chocolate food",
                            Name = "Choco",
                            Obsolete = false,
                            Price = 19m,
                            ProductType = "food",
                            QuantityInPackage = 5
                        });
                });

            modelBuilder.Entity("final_assignment.Common.Models.NonFoodModel", b =>
                {
                    b.HasBaseType("final_assignment.Common.Models.ProductModel");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Color");

                    b.HasData(
                        new
                        {
                            ProductId = 11,
                            AmountInStock = 10,
                            Description = "Mega fast",
                            Name = "Booster",
                            Obsolete = false,
                            Price = 46m,
                            ProductType = "nonfood",
                            Color = "blue",
                            Size = "3x3"
                        },
                        new
                        {
                            ProductId = 12,
                            AmountInStock = 0,
                            Description = "underwater",
                            Name = "gps",
                            Obsolete = false,
                            Price = 31m,
                            ProductType = "nonfood",
                            Color = "orange",
                            Size = "10x10"
                        },
                        new
                        {
                            ProductId = 13,
                            AmountInStock = 0,
                            Description = "Aerodynamic",
                            Name = "Aero shirt",
                            Obsolete = true,
                            Price = 20m,
                            ProductType = "nonfood",
                            Color = "green",
                            Size = "50x50"
                        },
                        new
                        {
                            ProductId = 14,
                            AmountInStock = 8,
                            Description = "Aerodynamic",
                            Name = "Aero pants",
                            Obsolete = false,
                            Price = 20m,
                            ProductType = "nonfood",
                            Color = "white",
                            Size = "3x3"
                        },
                        new
                        {
                            ProductId = 15,
                            AmountInStock = 100,
                            Description = "Durable",
                            Name = "Bottle",
                            Obsolete = false,
                            Price = 9m,
                            ProductType = "nonfood",
                            Color = "black",
                            Size = "5x5"
                        },
                        new
                        {
                            ProductId = 16,
                            AmountInStock = 10,
                            Description = "Mega fast",
                            Name = "Booster",
                            Obsolete = false,
                            Price = 46m,
                            ProductType = "nonfood",
                            Color = "blue",
                            Size = "3x3"
                        },
                        new
                        {
                            ProductId = 17,
                            AmountInStock = 0,
                            Description = "underwater",
                            Name = "gps",
                            Obsolete = false,
                            Price = 31m,
                            ProductType = "nonfood",
                            Color = "orange",
                            Size = "10x10"
                        },
                        new
                        {
                            ProductId = 18,
                            AmountInStock = 0,
                            Description = "Aerodynamic",
                            Name = "Aero shirt",
                            Obsolete = true,
                            Price = 20m,
                            ProductType = "nonfood",
                            Color = "green",
                            Size = "50x50"
                        },
                        new
                        {
                            ProductId = 19,
                            AmountInStock = 8,
                            Description = "Aerodynamic",
                            Name = "Aero pants",
                            Obsolete = false,
                            Price = 20m,
                            ProductType = "nonfood",
                            Color = "white",
                            Size = "3x3"
                        },
                        new
                        {
                            ProductId = 20,
                            AmountInStock = 100,
                            Description = "Durable",
                            Name = "Bottle",
                            Obsolete = false,
                            Price = 9m,
                            ProductType = "nonfood",
                            Color = "black",
                            Size = "5x5"
                        });
                });

            modelBuilder.Entity("final_assignment.Common.Models.ShoppingBagModel", b =>
                {
                    b.HasOne("final_assignment.Common.Models.LoginModel", "Login")
                        .WithOne("ShoppingBag")
                        .HasForeignKey("final_assignment.Common.Models.ShoppingBagModel", "LoginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Login");
                });

            modelBuilder.Entity("final_assignment.Common.Models.ShoppingItemModel", b =>
                {
                    b.HasOne("final_assignment.Common.Models.ProductModel", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("final_assignment.Common.Models.ShoppingBagModel", "ShoppingBag")
                        .WithMany("Items")
                        .HasForeignKey("ShoppingBagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ShoppingBag");
                });

            modelBuilder.Entity("final_assignment.Common.Models.LoginModel", b =>
                {
                    b.Navigation("ShoppingBag");
                });

            modelBuilder.Entity("final_assignment.Common.Models.ShoppingBagModel", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
