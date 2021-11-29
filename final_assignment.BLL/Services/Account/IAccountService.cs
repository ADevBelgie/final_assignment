using final_assignment.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_assignment.BLL.Services.Account
{
    public interface IAccountService
    {
        List<LoginModel> GetAllLoginViews();
        LoginModel AddLogin(LoginModel login);
        LoginModel UpdateLoginById(LoginModel login);
        Task<LoginModel> DeleteLogin(string userName);
    }
}
