using final_assignment.Common.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_assignment.DAL.Data.DB
{
    public class AppDbInitializer 
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.SaveChanges();
            //SeedRoles(roleManager);
            //SeedUsers(userManager);
        }
        public static void SeedRoles(RoleManager<RoleModel> roleManager)
        {
            if (!roleManager.RoleExistsAsync("NormalUser").Result)
            {
                RoleModel role = new RoleModel();
                role.Name = "NormalUser";
                role.Description = "Perform normal operations.";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                RoleModel role = new RoleModel();
                role.Name = "Administrator";
                role.Description = "Perform all the operations.";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
        public static void SeedUsers(UserManager<LoginModel> userManager)
        {
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                LoginModel user = new LoginModel() { 
                    ShoppingBagId = 1, 
                    UserName = "admin", 
                    Email = "admin.admin@gmail.com"};

                IdentityResult result = userManager.CreateAsync
                (user, "admin").Result; // password

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }


            if (userManager.FindByNameAsync("arthur").Result == null)
            {
                LoginModel user = new LoginModel()
                {
                    ShoppingBagId = 2,
                    UserName = "arthur",
                    Email = "arthur.arthur@gmail.com"
                };

                IdentityResult result = userManager.CreateAsync
                (user, "arthur").Result; // password

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "NormalUser").Wait();
                }
            }
        }
        
    }
}
