using EShop_Backend.Config;
using EShop_Backend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShop_Backend.Controllers
{
    [ApiController]
    [Route("orderitem/")]
    public class OrderItemController :Controller
    {
        private readonly EshopDbContext _context;

        public OrderItemController(EshopDbContext context)
        {
            _context = context;
        }

        [HttpGet("get")]
        public IEnumerable<OrderItem> GetOrderItems()
        {
            return _context.OrderItems.Include(p=>p.Products).ToList();
        }

        [HttpPost]
        public IActionResult CreateOrderItem(OrderItem item)
        {
            var product = _context.Products.Find(item.Products.Id);
            if(product != null)
            {
                item.Products= product;
                _context.OrderItems.Add(item);
                _context.SaveChanges();
                return Ok(item);

            }
            else
            {
                return BadRequest();
            }
            
            
        }
    }
}
