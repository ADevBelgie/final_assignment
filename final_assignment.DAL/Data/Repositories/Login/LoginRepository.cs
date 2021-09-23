using final_assignment.Common.Models;
using final_assignment.DAL.Data.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_assignment.DAL.Data.Repositories.Login
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDbContext _context;
        public LoginRepository(AppDbContext context)
        {
            _context = context;
        }
        public LoginModel AddLogin(LoginModel login)
        {
            try
            {
                _context.Logins.Add(login);
            }
            catch (Exception)
            {
                // Add logging
                throw;
            }
            Save();
            return GetLoginId(login.LoginId);
        }

        public IEnumerable<LoginModel> GetAllLoginViews()
        {
            return _context.Logins;
        }

        public LoginModel GetLoginId(int id)
        {
            return _context.Logins
                .FirstOrDefault(x => x.LoginId == id);
        }

        public LoginModel UpdateLoginById(LoginModel login)
        {
            try
            {
                _context.Logins.Update(login);
            }
            catch (Exception)
            {
                // Add logging
                throw;
            }
            Save();
            return GetLoginId(login.LoginId);
        }
        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
