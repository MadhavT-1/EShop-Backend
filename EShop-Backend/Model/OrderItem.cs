using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop_Backend.Model
{
    public class OrderItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ItemId { get; set; }
       public int ProductsId { get;set; }
        public Products Products { get; set; }
        public int Quantity { get; set; }
    }
}
