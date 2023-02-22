using System.ComponentModel.DataAnnotations;

namespace EShop_Backend.Model
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        public int UsersId { get; set; }
        public Users Users { get; set; }
       
        public List<OrderItem> OrderItem { get; set; }
    }
}
