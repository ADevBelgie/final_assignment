
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace final_assignment.Common.Models
{
    public class LoginModel : IdentityUser
    {
        //[DisplayName("Username")]
        //[Required(ErrorMessage = "User Name is required")]
        //override public string UserName { get; set; }
        //[DisplayName("Password")]
        //[Required(ErrorMessage = "Password is required")]
        //[ProtectedPersonalData]
        //override public string PasswordHash { get; set; }
        //[DisplayName("Username")]
        //[Required(ErrorMessage = "Email is required")]
        //override public string Email { get; set; }
        public int ShoppingBagId { get; set; } // FK
        public ShoppingBagModel ShoppingBag { get; set; }
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
    }
}
