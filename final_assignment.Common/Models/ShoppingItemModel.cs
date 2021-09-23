using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_assignment.Common.Models
{
    public class ShoppingItemModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }//PK
        public int ShoppingBagId { get; set; }//FK
        public int ProductId { get; set; }//FK
        public ShoppingBagModel ShoppingBag { get; set; }
        public ProductTShirtViewModel Product { get; set; }
        [DisplayName("Aantal")]
        public int Amount { get; set; }
        public double Discount { get; set; }
    }
}
