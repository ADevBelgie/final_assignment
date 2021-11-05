using final_assignment.API.Models;
using final_assignment.BLL.Services.Account;
using final_assignment.BLL.Services.Shopping;
using final_assignment.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace final_assignment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ShoppingController : ControllerBase
    {
        private readonly ILogger<ShoppingController> _logger;
        private readonly IShoppingService _shoppingService;
        private readonly IAccountService _accountService;

        public ShoppingController(ILogger<ShoppingController> logger, IShoppingService shoppingService, IAccountService accountService)
        {
            _logger = logger;
            _shoppingService = shoppingService;
            _accountService = accountService;
        }
        // GET api/Shopping
        [HttpGet]
        [Authorize]
        public ShoppingBagModel Get()
        {
            var allUsers = _accountService.GetAllLoginViews();
            var currentUser = _accountService.GetAllLoginViews().Find(x => x.UserName == User.Identity.Name);
            var shoppingBag = _shoppingService.GetShoppingBagByLoginId(currentUser.Id);
            if (shoppingBag == null)
            {
                shoppingBag = CreateShoppingBag(currentUser);
            }
            
            return shoppingBag;
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> AddItem()
        {
            
            var allUsers = _accountService.GetAllLoginViews();
            var currentUser = _accountService.GetAllLoginViews().Find(x => x.UserName == User.Identity.Name);
            var shoppingBag = _shoppingService.GetShoppingBagByLoginId(currentUser.Id);

            // add Shoppingbag if not already created for this user.
            if (shoppingBag == null)
            {
                shoppingBag = CreateShoppingBag(currentUser);
            }
            return Ok(new Response { Status = "Success", Message = "Item added to shoppingcart" });
        }
        private ShoppingBagModel CreateShoppingBag(LoginModel currentUser)
        {
            // Create shoppingbag for user and add shoppingbagid to user
            var shoppingBag = _shoppingService.AddShoppingBag(new ShoppingBagModel
            {
                LoginId = currentUser.Id,
                TimeCreated = DateTime.Now
            });
            currentUser.ShoppingBagId = shoppingBag.ShoppingBagId;
            _accountService.UpdateLoginById(currentUser);

            return shoppingBag;
        }
    }
}
