using System.ComponentModel.DataAnnotations;

namespace final_assignment.Common.Models
{
    public class LoginModel
    {
        [Key]
        public int LoginId { get; set; }
        public int ShoppingBagId { get; set; }
        public ShoppingBagModel ShoppingBag { get; set; }
        [Required]
        [Key]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Key]
        [EmailAddress]
        [Display(Name = "Username")]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
        public string Role { get; set; }
    }
}
