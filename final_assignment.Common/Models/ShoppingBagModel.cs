using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace final_assignment.Common.Models
{
    public class ShoppingBagModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShoppingBagId { get; set; }//PK
        public string LoginId { get; set; }//FK
        [JsonIgnore] // Otherwise: System.Text.Json.JsonException: A possible object cycle was detected which is not supported. This can either be due to a cycle or if the object depth is larger than the maximum allowed depth of 32.
        public LoginModel Login { get; set; }
        public DateTime TimeCreated { get; set; }
        public List<ShoppingItemModel> Items { get; set; } = new List<ShoppingItemModel>();
    }
}
