using EShop_Backend.Config;
using EShop_Backend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShop_Backend.Controllers
{
    [ApiController]
    [Route("orders/")]
    public class OrdersController : Controller
    {
        private readonly EshopDbContext _context;

        public OrdersController(EshopDbContext context)
        {
            _context = context;
        }

        [HttpGet("get")]
        public IEnumerable<Orders> GetOrders()
        {
            return _context.Orders.Include(u=>u.Users).ToList();
        }
        [HttpPost("create")]
        public IActionResult CreateOrder(Orders order)
        {
            var user = _context.Users.Find(order.Users.UserId);
            if(user != null)
            {
                order.Users = user;
                //for(var i=0;i<order.OrderItem.Count();i++)
                //{
                //    _context.OrderItems.Add(order.OrderItem[i]);
                //}
                
                _context.Orders.Add(order);
                _context.SaveChanges();
                return Ok(order);
            }
            else
            {
                return BadRequest();
            }
           
        }

        //[HttpPost("upload")]
        //[Consumes("multipart/form-data")]
        //public IActionResult UploadData([FromForm]Object obj)
        //{
        //    if (obj == null)
        //        return BadRequest("Upload file");
        //    return Ok();
        //}

    }
}
