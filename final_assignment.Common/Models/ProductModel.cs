using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_assignment.Common.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductType { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(18,4)")] // Needs to be specified for DB, This will store 18 digits in the database with 4 of those after the decimal.
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool Obsolete { get; set; } // Active
        public int AmountInStock { get; set; }
    }
}
