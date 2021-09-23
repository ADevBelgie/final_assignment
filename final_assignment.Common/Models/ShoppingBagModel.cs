using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace final_assignment.Common.Models
{
    public class ShoppingBagModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShoppingBagId { get; set; }//PK
        public int LoginId { get; set; }//FK
        public LoginModel Login { get; set; }
        public DateTime TimeCreated { get; set; }
        public List<ShoppingItemModel> Items { get; set; } = new List<ShoppingItemModel>();
    }
}
