
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace final_assignment.Common.Models
{
    public class LoginModel : IdentityUser
    {
        public int ShoppingBagId { get; set; } // FK
        public ShoppingBagModel ShoppingBag { get; set; }
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
    }
}
