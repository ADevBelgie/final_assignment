using final_assignment.Common.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace final_assignment.DAL.Data.DB
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<FoodModel> FoodProducts { get; set; }
        public DbSet<NonFoodModel> NonFoodProducts { get; set; }
        public DbSet<ShoppingBagModel> ShoppingBags { get; set; }
        public DbSet<ShoppingItemModel> ShoppingItems { get; set; }

        public DbSet<LoginModel> Logins { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Products
            modelBuilder.Entity<ProductModel>()
                .HasKey(b => b.ProductId);
            modelBuilder.Entity<ProductModel>()
                .HasDiscriminator(b => b.ProductType);
            modelBuilder.Entity<ProductModel>()
                .Property(e => e.ProductType)
                .HasMaxLength(200)
                .HasColumnName("product_type");
            modelBuilder.Entity<ProductModel>()
                .HasDiscriminator<string>("Category")
                .HasValue<ProductModel>("blog_base")
                .HasValue<FoodModel>("QuantityInPackage")
                .HasValue<NonFoodModel>("Size")
                .HasValue<NonFoodModel>("Color");

            // Logins
            modelBuilder.Entity<LoginModel>()
                .HasKey(l => new {
                    l.LoginId
                });
            modelBuilder.Entity<LoginModel>()
               .HasAlternateKey(l => new { l.UserName });
            modelBuilder.Entity<LoginModel>() // one on one relation shoppingbag
              .HasOne(spb => spb.ShoppingBag)
              .WithOne(l => l.Login)
              .HasForeignKey<LoginModel>(l => l.ShoppingBagId);

            //Shopping Bag
            modelBuilder.Entity<ShoppingBagModel>()
               .HasKey(spb => new { spb.ShoppingBagId });
            modelBuilder.Entity<ShoppingBagModel>() // one on one relation Login
               .HasOne(l => l.Login)
               .WithOne(spb => spb.ShoppingBag)
               .HasForeignKey<ShoppingBagModel>(spb => spb.LoginId);
            modelBuilder.Entity<ShoppingBagModel>() // one on many relation shoppingitem
               .HasMany(spb => spb.Items)
               .WithOne(spi => spi.ShoppingBag)
               .HasForeignKey(spi => spi.ShoppingBagId);

            //Shopping Item
            modelBuilder.Entity<ShoppingItemModel>()
               .HasKey(spi => new { spi.ID });
            modelBuilder.Entity<ShoppingItemModel>()
               .HasOne(spi => spi.ShoppingBag)
               .WithMany(spb => spb.Items)
               .HasForeignKey(spi => spi.ShoppingBagId);
            modelBuilder.Entity<ShoppingItemModel>()
               .HasOne(spi => spi.Product);

            // Seeding
            // Seeding FoodProducts
            IList<FoodModel> defaultStandardsFood = new List<FoodModel>();
            for (int i = 1; i < 3; i++)
            {
                defaultStandardsFood.Add(new FoodModel() { ProductId = i * 5 - 4, ProductType = "food", Name = "Pizza", Price = 50, Description = "Jummy food", Obsolete = false, AmountInStock = 10, QuantityInPackage = 3 });
                defaultStandardsFood.Add(new FoodModel() { ProductId = i * 5 - 3, ProductType = "food", Name = "Flies", Price = 32, Description = "Bug food", Obsolete = false, AmountInStock = 0, QuantityInPackage = 3 });
                defaultStandardsFood.Add(new FoodModel() { ProductId = i * 5 - 2, ProductType = "food", Name = "Dog Crunch", Price = 19, Description = "Dog food", Obsolete = true, AmountInStock = 0, QuantityInPackage = 3 });
                defaultStandardsFood.Add(new FoodModel() { ProductId = i * 5 - 1, ProductType = "food", Name = "Jelly", Price = 19, Description = "Fatty food", Obsolete = false, AmountInStock = 8, QuantityInPackage = 18 });
                defaultStandardsFood.Add(new FoodModel() { ProductId = i * 5, ProductType = "food", Name = "Choco", Price = 19, Description = "Chocolate food", Obsolete = false, AmountInStock = 150, QuantityInPackage = 5 });
            }
            modelBuilder.Entity<FoodModel>().HasData(defaultStandardsFood);

            // Seeding NonFoodProducts
            IList<NonFoodModel> defaultStandardsNonFood = new List<NonFoodModel>();
            for (int i = 3; i < 5; i++)
            {
                defaultStandardsNonFood.Add(new NonFoodModel() { ProductId = i * 5 - 4, ProductType = "nonfood", Name = "Booster", Price = 46, Description = "Mega fast", Obsolete = false, AmountInStock = 10, Size = "3x3", Color = "blue" });
                defaultStandardsNonFood.Add(new NonFoodModel() { ProductId = i * 5 - 3, ProductType = "nonfood", Name = "gps", Price = 31, Description = "underwater", Obsolete = false, AmountInStock = 0, Size = "10x10", Color = "orange" });
                defaultStandardsNonFood.Add(new NonFoodModel() { ProductId = i * 5 - 2, ProductType = "nonfood", Name = "Aero shirt", Price = 20, Description = "Aerodynamic", Obsolete = true, AmountInStock = 0, Size = "50x50", Color = "green" });
                defaultStandardsNonFood.Add(new NonFoodModel() { ProductId = i * 5 - 1, ProductType = "nonfood", Name = "Aero pants", Price = 20, Description = "Aerodynamic", Obsolete = false, AmountInStock = 8, Size = "3x3", Color = "white" });
                defaultStandardsNonFood.Add(new NonFoodModel() { ProductId = i * 5, ProductType = "nonfood", Name = "Bottle", Price = 9, Description = "Durable", Obsolete = false, AmountInStock = 100, Size = "5x5", Color = "black" });
            }
            modelBuilder.Entity<NonFoodModel>().HasData(defaultStandardsNonFood);

            // Seeding Logins
            IList<LoginModel> defaultUsers = new List<LoginModel>();
            defaultUsers.Add(new LoginModel() { LoginId = 1, ShoppingBagId = 1, UserName = "admin1", Role = "admin", Password = "admin" });
            defaultUsers.Add(new LoginModel() { LoginId = 2, ShoppingBagId = 2, UserName = "arthur", Role = "normal", Password = "arthur" });
            modelBuilder.Entity<LoginModel>().HasData(defaultUsers);

            // Seeding Shoppingbag for above users
            IList<ShoppingBagModel> defaultBags = new List<ShoppingBagModel>();
            defaultBags.Add(new ShoppingBagModel() { ShoppingBagId = 1, LoginId = 1, TimeCreated = System.DateTime.Now });
            defaultBags.Add(new ShoppingBagModel() { ShoppingBagId = 2, LoginId = 2, TimeCreated = System.DateTime.Now });
            modelBuilder.Entity<ShoppingBagModel>().HasData(defaultBags);
        }  
    }
}
