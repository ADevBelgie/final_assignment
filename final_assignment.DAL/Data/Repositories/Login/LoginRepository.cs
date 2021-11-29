using final_assignment.Common.Models;
using final_assignment.DAL.Data.DB;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace final_assignment.DAL.Data.Repositories.Login
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<LoginRepository> _logger;
        private readonly UserManager<LoginModel> _userManager;
        private readonly RoleManager<RoleModel> _roleManager;
        public LoginRepository(
            AppDbContext context,
             ILogger<LoginRepository> logger,
            UserManager<LoginModel> userManager,
            RoleManager<RoleModel> roleManager)
        {
            _context = context;
            _logger = logger;
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
                    // logging
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
            Save();
            return _context.Users.FirstOrDefault(x => x.UserName == login.UserName);
        }

        public async Task<LoginModel> DeleteLogin(string userName)
        {
            LoginModel user;
            try
            {
                user = _userManager.FindByNameAsync(userName).Result;
                if (user != null)
                {
                    await _userManager.DeleteAsync(user);
                }
            }
            catch (Exception)
            {
                // Add logging
                throw;
            }
            Save();
            return GetLoginId(user.Id);
        }

        public IEnumerable<LoginModel> GetAllLoginViews()
        {
            return (IEnumerable<LoginModel>)_context.Users;
        }

        public LoginModel GetLoginId(string id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public async Task<LoginModel> UpdateLoginByIdAsync(LoginModel login)
        {
            try
            {
                var user = _userManager.FindByIdAsync(login.Id).Result;
                if (user != null)
                {
                    user.ShoppingBagId = login.ShoppingBagId;
                    // Potentially add more things to be updated.
                    await _userManager.UpdateAsync(user); // Need to await for Save() to work
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

        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
