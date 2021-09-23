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
        LoginModel GetLoginId(int id);
        LoginModel AddLogin(LoginModel login);
        LoginModel UpdateLoginById(LoginModel login);
    }
}
