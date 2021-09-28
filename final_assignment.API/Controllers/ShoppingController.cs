using final_assignment.BLL.Services.Shopping;
using final_assignment.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace final_assignment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ShoppingController
    {
        private readonly ILogger<ShoppingController> _logger;
        private readonly IShoppingService _shoppingService;

        public ShoppingController(ILogger<ShoppingController> logger, IShoppingService shoppingService)
        {
            _logger = logger;
            _shoppingService = shoppingService;
        }
        // GET api/Shopping/id
        [HttpGet("{id}")]
        public ShoppingBagModel Get(string id)
        {
            var shoppingBag = _shoppingService.GetShoppingBagByLoginId(id);
            if (shoppingBag == null)
            {
                shoppingBag = _shoppingService.AddShoppingBag( new ShoppingBagModel() {
                    LoginId = id,
                    TimeCreated = DateTime.Now
                });
            }
            return shoppingBag;
        }
    }
}
