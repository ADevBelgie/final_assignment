using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace final_assignment.Common.Models
{
    public class ShoppingItemModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }//PK
        public int ShoppingBagId { get; set; }//FK
        public int ProductId { get; set; }//FK
        [JsonIgnore]
        public ShoppingBagModel ShoppingBag { get; set; }
        public ProductModel Product { get; set; }
        [DisplayName("Aantal")]
        public int Amount { get; set; }
        public double Discount { get; set; }
    }
}
