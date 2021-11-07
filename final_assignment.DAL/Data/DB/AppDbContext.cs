using final_assignment.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace final_assignment.DAL.Data.DB
{
    public class AppDbContext: IdentityDbContext<LoginModel, RoleModel, string>  
    {   

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
           
        }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<FoodModel> FoodProducts { get; set; }
        public DbSet<NonFoodModel> NonFoodProducts { get; set; }
        public DbSet<ShoppingBagModel> ShoppingBags { get; set; }
        public DbSet<ShoppingItemModel> ShoppingItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // For enabling IdentityUser

            // Products
            modelBuilder.Entity<ProductModel>(product =>
            { 
                product.HasKey(b => b.ProductId);

                product.HasDiscriminator(b => b.ProductType);

                product.Property(e => e.ProductType)
                    .HasMaxLength(200)
                    .HasColumnName("product_type");

                product.HasDiscriminator<string>("Category")
                .HasValue<ProductModel>("blog_base")
                .HasValue<FoodModel>("QuantityInPackage")
                .HasValue<NonFoodModel>("Size")
                .HasValue<NonFoodModel>("Color");
            });

            // https://docs.microsoft.com/en-us/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-5.0
            // Logins
            modelBuilder.Entity<LoginModel>(login =>
            {
                login.HasOne(spb => spb.ShoppingBag)// one on one relation shoppingbag
                  .WithOne(l => l.Login)
                  .HasForeignKey<LoginModel>(l => l.ShoppingBagId);
            });

            // Each User can have many entries in the UserRole join table

            //Shopping Bag
            modelBuilder.Entity<ShoppingBagModel>(shoppingBag =>
            { 
                shoppingBag.HasKey(spb => new { spb.ShoppingBagId });

                shoppingBag.HasOne(l => l.Login) // one on one relation Login
                   .WithOne(spb => spb.ShoppingBag)
                   .HasForeignKey<ShoppingBagModel>(spb => spb.LoginId);

                shoppingBag.HasMany(spb => spb.Items)  // one on many relation shoppingitem
                   .WithOne(spi => spi.ShoppingBag)
                   .HasForeignKey(spi => spi.ShoppingBagId);
            });

            //Shopping Item
            modelBuilder.Entity<ShoppingItemModel>(shoppingItem =>
            {
                shoppingItem.HasKey(spi => new { spi.ID });

                shoppingItem.HasOne(spi => spi.ShoppingBag)
                   .WithMany(spb => spb.Items)
                   .HasForeignKey(spi => spi.ShoppingBagId);

                shoppingItem.HasOne(spi => spi.Product);
            });

            // Seeding
            // Seeding FoodProducts
            IList<FoodModel> defaultStandardsFood = new List<FoodModel>();
            defaultStandardsFood.Add(new FoodModel() { ProductId = 1, ProductType = "food", Name = "High Potency Magnesium", Price = 30, Description = "", Obsolete = false, AmountInStock = 0, QuantityInPackage = 3, Image = "High Potency Magnesium.jpg" });
            defaultStandardsFood.Add(new FoodModel() { ProductId = 2, ProductType = "food", Name = "Sport Drink", Price = 5, Description = "Sport Drink Powerade", Obsolete = true, AmountInStock = 0, QuantityInPackage = 3, Image = "powerade.jpg" });
            defaultStandardsFood.Add(new FoodModel() { ProductId = 3, ProductType = "food", Name = "Shake for Weight Loss", Price = 19, Description = "", Obsolete = false, AmountInStock = 8, QuantityInPackage = 18, Image = "Shake for Weight Loss.jpg" });
            defaultStandardsFood.Add(new FoodModel() { ProductId = 4, ProductType = "food", Name = "Nutritional Drink Mix", Price = 10, Description = "3 Eggs worth of eggwhite", Obsolete = false, AmountInStock = 150, QuantityInPackage = 5, Image = "Nutritional Drink Mix.jpg" });
            defaultStandardsFood.Add(new FoodModel() { ProductId = 5, ProductType = "food", Name = "Protein Bar Pack", Price = 13.4M, Description = "200G Protein", Obsolete = false, AmountInStock = 10, QuantityInPackage = 3, Image = "Protein Bar Pack.jpg" });
            defaultStandardsFood.Add(new FoodModel() { ProductId = 6, ProductType = "food", Name = "Multigrain Energy Bars", Price = 16, Description = "", Obsolete = false, AmountInStock = 10, QuantityInPackage = 3, Image = "Multigrain Energy Bars.jpg" });
            defaultStandardsFood.Add(new FoodModel() { ProductId = 7, ProductType = "food", Name = "Health & Nutrition Drink", Price = 11, Description = "", Obsolete = false, AmountInStock = 10, QuantityInPackage = 3, Image = "Health & Nutrition Drink.jpg" });
            defaultStandardsFood.Add(new FoodModel() { ProductId = 8, ProductType = "food", Name = "Oats with Almonds Biscuits", Price = 8, Description = "", Obsolete = false, AmountInStock = 10, QuantityInPackage = 3, Image = "Oats with Almonds Biscuits.jpg" });



            modelBuilder.Entity<FoodModel>().HasData(defaultStandardsFood);

            // Seeding NonFoodProducts
            IList<NonFoodModel> defaultStandardsNonFood = new List<NonFoodModel>();
            defaultStandardsNonFood.Add(new NonFoodModel() { ProductId = 100, ProductType = "nonfood", Name = "Hiking Backpack", Price = 129.9M, Description = "Mega fast Hiking Backpack", Obsolete = false, AmountInStock = 10, Size = "3x3", Color = "blue", Image = "hiking backpack.jpg" });
            defaultStandardsNonFood.Add(new NonFoodModel() { ProductId = 101, ProductType = "nonfood", Name = "Portable Tent", Price = 165, Description = "2 Person tent for your outdoor adventures", Obsolete = false, AmountInStock = 0, Size = "10x10", Color = "orange", Image = "portable tent.jpg" });
            defaultStandardsNonFood.Add(new NonFoodModel() { ProductId = 102, ProductType = "nonfood", Name = "GPS Smartwatch", Price = 200, Description = "", Obsolete = true, AmountInStock = 0, Size = "50x50", Color = "green", Image = "gps smartwatch.jpg" });
            defaultStandardsNonFood.Add(new NonFoodModel() { ProductId = 103, ProductType = "nonfood", Name = "Running Shoes ", Price = 99, Description = "Aerodynamic", Obsolete = false, AmountInStock = 8, Size = "3x3", Color = "white", Image = "running shoes.jpg" });
            defaultStandardsNonFood.Add(new NonFoodModel() { ProductId = 104, ProductType = "nonfood", Name = "Fit Track Pants", Price = 40, Description = "Durable", Obsolete = false, AmountInStock = 100, Size = "5x5", Color = "black", Image = "fit track pants.jpg" });
            defaultStandardsNonFood.Add(new NonFoodModel() { ProductId = 105, ProductType = "nonfood", Name = "Badminton Racket", Price = 92, Description = "Durable and lightweight", Obsolete = false, AmountInStock = 100, Size = "5x5", Color = "black", Image = "badminton racquet.jpg" });
            defaultStandardsNonFood.Add(new NonFoodModel() { ProductId = 106, ProductType = "nonfood", Name = "Roller Wheel", Price = 30, Description = "For your abs", Obsolete = false, AmountInStock = 100, Size = "5x5", Color = "black", Image = "Roller Wheel.jpg" });
            defaultStandardsNonFood.Add(new NonFoodModel() { ProductId = 107, ProductType = "nonfood", Name = "Yoga and Exercise Mat", Price = 35, Description = "For those late night stretches", Obsolete = false, AmountInStock = 100, Size = "5x5", Color = "black", Image = "Yoga and Exercise Mat.jpg" });
            defaultStandardsNonFood.Add(new NonFoodModel() { ProductId = 108, ProductType = "nonfood", Name = "Folding Treadmill", Price = 999, Description = "", Obsolete = false, AmountInStock = 100, Size = "5x5", Color = "black", Image = "Folding Treadmill.jpg" });
            modelBuilder.Entity<NonFoodModel>().HasData(defaultStandardsNonFood);


            // Seeding Roles is done in AppDbInit

            // Seeding Logins is done in AppDbInit

            // Seeding Shoppingbag not necessary since they are created upon request

        }  
    }
}
