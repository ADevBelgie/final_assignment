using final_assignment.BLL.Services.Account;
using final_assignment.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_assignment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;

        public AccountController(ILogger<AccountController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }
        // Authenthıcation request, returns token
        // api/Account/login
        [HttpPost]
        public object Login(LoginModel objLoginModel)
        {
            // Validation object
            // Authenticate user
            // Return Token
            return null;
        }
    }
}
