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
            for (int i = 1; i < 3; i++)
            {
                defaultStandardsFood.Add(new FoodModel() { ProductId = i * 5 - 4, ProductType = "food", Name = "Pizza", Price = 10, Description = "Grilled Pizza Margherita", Obsolete = false, AmountInStock = 10, QuantityInPackage = 3, Image = "Grilled-Pizza-Margherita.jpg" });
                defaultStandardsFood.Add(new FoodModel() { ProductId = i * 5 - 3, ProductType = "food", Name = "Hot Dog", Price = 3, Description = "American Hot Dog", Obsolete = false, AmountInStock = 0, QuantityInPackage = 3, Image = "hot-dogs-new-yorkais.jpeg" });
                defaultStandardsFood.Add(new FoodModel() { ProductId = i * 5 - 2, ProductType = "food", Name = "Sport Drink", Price = 5, Description = "Sport Drink Powerade", Obsolete = true, AmountInStock = 0, QuantityInPackage = 3, Image= "powerade.jpg" });
                defaultStandardsFood.Add(new FoodModel() { ProductId = i * 5 - 1, ProductType = "food", Name = "Spaghetti", Price = 19, Description = "Spaghetti Bolognese", Obsolete = false, AmountInStock = 8, QuantityInPackage = 18, Image= "spaghetti.jpg" });
                defaultStandardsFood.Add(new FoodModel() { ProductId = i * 5, ProductType = "food", Name = "Scrambled Eggs", Price = 19, Description = "3 Scrambled Eggs", Obsolete = false, AmountInStock = 150, QuantityInPackage = 5, Image= "scrambled-eggs-1.jpg" });
            }
            modelBuilder.Entity<FoodModel>().HasData(defaultStandardsFood);

            // Seeding NonFoodProducts
            IList<NonFoodModel> defaultStandardsNonFood = new List<NonFoodModel>();
            for (int i = 3; i < 5; i++)
            {
                defaultStandardsNonFood.Add(new NonFoodModel() { ProductId = i * 5 - 4, ProductType = "nonfood", Name = "Booster", Price = 46, Description = "Mega fast", Obsolete = false, AmountInStock = 10, Size = "3x3", Color = "blue", Image= "funko-the-thing-560-fantastic-four-pop-marvel.jpg" });
                defaultStandardsNonFood.Add(new NonFoodModel() { ProductId = i * 5 - 3, ProductType = "nonfood", Name = "gps", Price = 31, Description = "underwater", Obsolete = false, AmountInStock = 0, Size = "10x10", Color = "orange", Image = "funko-the-thing-560-fantastic-four-pop-marvel.jpg" });
                defaultStandardsNonFood.Add(new NonFoodModel() { ProductId = i * 5 - 2, ProductType = "nonfood", Name = "Aero shirt", Price = 20, Description = "Aerodynamic", Obsolete = true, AmountInStock = 0, Size = "50x50", Color = "green", Image = "funko-the-thing-560-fantastic-four-pop-marvel.jpg" });
                defaultStandardsNonFood.Add(new NonFoodModel() { ProductId = i * 5 - 1, ProductType = "nonfood", Name = "Aero pants", Price = 20, Description = "Aerodynamic", Obsolete = false, AmountInStock = 8, Size = "3x3", Color = "white", Image = "funko-the-thing-560-fantastic-four-pop-marvel.jpg" });
                defaultStandardsNonFood.Add(new NonFoodModel() { ProductId = i * 5, ProductType = "nonfood", Name = "Bottle", Price = 9, Description = "Durable", Obsolete = false, AmountInStock = 100, Size = "5x5", Color = "black", Image = "funko-the-thing-560-fantastic-four-pop-marvel.jpg" });
            }
            modelBuilder.Entity<NonFoodModel>().HasData(defaultStandardsNonFood);


            // Seeding Roles is done in AppDbInit

            // Seeding Logins is done in AppDbInit

            // Seeding Shoppingbag not necessary since they are created upon request

        }  
    }
}
