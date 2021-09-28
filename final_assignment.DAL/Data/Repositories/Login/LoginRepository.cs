using final_assignment.Common.Models;
using final_assignment.DAL.Data.DB;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace final_assignment.DAL.Data.Repositories.Login
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<LoginModel> _userManager;
        private readonly RoleManager<RoleModel> _roleManager;
        public LoginRepository(
            AppDbContext context, 
            UserManager<LoginModel> userManager,
            RoleManager<RoleModel> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public LoginModel AddLogin(LoginModel login)
        {
            try
            {
                if (_userManager.FindByNameAsync(login.UserName).Result == null)
                {
                    LoginModel user = new LoginModel()
                    {
                        UserName = login.UserName,
                        Email = login.Email
                    };

                    IdentityResult result = _userManager.CreateAsync
                    (user, login.PasswordHash).Result; // password

                    if (result.Succeeded)
                    {
                        _userManager.AddToRoleAsync(user, "NormalUser").Wait();
                    }
                }
            }
            catch (Exception)
            {
                // Add logging
                throw;
            }
            Save();
            return GetLoginId(login.Id);
        }

        public IEnumerable<LoginModel> GetAllLoginViews()
        {
            return (IEnumerable<LoginModel>)_context.UserLogins;
        }

        public LoginModel GetLoginId(string id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public LoginModel UpdateLoginById(LoginModel login)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception)
            {
                // Add logging
                throw;
            }
            Save();
            return GetLoginId(login.Id);
        }

        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
