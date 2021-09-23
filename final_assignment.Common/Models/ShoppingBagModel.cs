using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_assignment.Common.Models
{
    public class ShoppingBagModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShoppingBagId { get; set; }//PK
        public int LoginId { get; set; }//FK
        public LoginViewModel LoginViewModel { get; set; }
        public DateTime TimeCreated { get; set; }
        public List<ShoppingItemViewModel> Items { get; set; } = new List<ShoppingItemViewModel>();
    }
}
