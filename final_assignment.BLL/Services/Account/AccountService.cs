using final_assignment.Common.Models;
using final_assignment.DAL.Data.Repositories.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_assignment.BLL.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly ILoginRepository _loginRepository;
        public AccountService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public LoginModel AddLogin(LoginModel login)
        {
            return  _loginRepository.AddLogin(login);
        }

        public List<LoginModel> GetAllLoginViews()
        {
            return _loginRepository.GetAllLoginViews().ToList();
        }

        public LoginModel UpdateLoginById(LoginModel login)
        {
            return _loginRepository.UpdateLoginByIdAsync(login).Result;
        }
    }
}
