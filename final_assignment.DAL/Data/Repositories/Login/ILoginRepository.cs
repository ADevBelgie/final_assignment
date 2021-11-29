using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using final_assignment.Common.Models;

namespace final_assignment.DAL.Data.Repositories.Login
{
    public interface ILoginRepository
    {
        IEnumerable<LoginModel> GetAllLoginViews();
        LoginModel GetLoginId(string id);
        LoginModel AddLogin(LoginModel login);
        Task<LoginModel> UpdateLoginByIdAsync(LoginModel login);
        Task<LoginModel> DeleteLogin(string userName);
    }
}
