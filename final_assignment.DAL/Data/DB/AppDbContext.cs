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
        public DbSet<FoodModel> FoodProducts { get; set; }
        public DbSet<NonFoodModel> NonFoodProducts { get; set; }
        public DbSet<LoginModel> Logins { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Logins
            modelBuilder.Entity<LoginModel>()
                .HasKey(l => new {
                    l.LoginId
                });
            modelBuilder.Entity<LoginModel>()
               .HasAlternateKey(l => new { l.UserName });

            // FoodProducts
            modelBuilder.Entity<FoodModel>()
                .HasKey(l => new {
                    l.ProductId
                });

            // NonFoodProducts
            modelBuilder.Entity<NonFoodModel>()
                .HasKey(l => new {
                    l.ProductId
                });

            // Seeding
            // Seeding FoodProducts
            IList<FoodModel> defaultStandardsFood = new List<FoodModel>();
            for (int i = 1; i < 5; i++)
            {
                defaultStandardsFood.Add(new FoodModel() { ProductId = i * 5 - 4, Name = "Pizza", Price = 50, Description = "Jummy food", Obsolete = false, AmountInStock = 10, QuantityInPackage = 3});
                defaultStandardsFood.Add(new FoodModel() { ProductId = i * 5 - 3, Name = "Flies", Price = 32, Description = "Bug food", Obsolete = false, AmountInStock = 0, QuantityInPackage = 3 });
                defaultStandardsFood.Add(new FoodModel() { ProductId = i * 5 - 2, Name = "Dog Crunch", Price = 19, Description = "Dog food", Obsolete = true, AmountInStock = 0, QuantityInPackage = 3 });
                defaultStandardsFood.Add(new FoodModel() { ProductId = i * 5 - 1, Name = "Jelly", Price = 19, Description = "Fatty food", Obsolete = false, AmountInStock = 8, QuantityInPackage = 18 });
                defaultStandardsFood.Add(new FoodModel() { ProductId = i * 5, Name = "Choco", Price = 19, Description = "Chocolate food", Obsolete = false, AmountInStock = 150, QuantityInPackage = 5 });
            }
            modelBuilder.Entity<FoodModel>().HasData(defaultStandardsFood);

            // Seeding NonFoodProducts
            IList<NonFoodModel> defaultStandardsNonFood = new List<NonFoodModel>();
            for (int i = 1; i < 5; i++)
            {
                defaultStandardsNonFood.Add(new NonFoodModel() { ProductId = i * 5 - 4, Name = "Booster", Price = 46, Description = "Mega fast", Obsolete = false, AmountInStock = 10, Size = "3x3", Color = "blue" });
                defaultStandardsNonFood.Add(new NonFoodModel() { ProductId = i * 5 - 3, Name = "gps", Price = 31, Description = "underwater", Obsolete = false, AmountInStock = 0, Size = "10x10", Color = "orange" });
                defaultStandardsNonFood.Add(new NonFoodModel() { ProductId = i * 5 - 2, Name = "Aero shirt", Price = 20, Description = "Aerodynamic", Obsolete = true, AmountInStock = 0, Size = "50x50", Color = "green" });
                defaultStandardsNonFood.Add(new NonFoodModel() { ProductId = i * 5 - 1, Name = "Aero pants", Price = 20, Description = "Aerodynamic", Obsolete = false, AmountInStock = 8, Size = "3x3", Color = "white" });
                defaultStandardsNonFood.Add(new NonFoodModel() { ProductId = i * 5, Name = "Bottle", Price = 9, Description = "Durable", Obsolete = false, AmountInStock = 100, Size = "5x5", Color = "black" });
            }
            modelBuilder.Entity<NonFoodModel>().HasData(defaultStandardsNonFood);

            // Seeding Logins
            IList<LoginModel> defaultUsers = new List<LoginModel>();
            defaultUsers.Add(new LoginModel() { LoginId = 1, UserName = "admin1", Role = "admin", Password = "admin" });
            defaultUsers.Add(new LoginModel() { LoginId = 2, UserName = "arthur", Role = "normal", Password = "arthur" });
            modelBuilder.Entity<LoginModel>().HasData(defaultUsers);
        }  
    }
}
