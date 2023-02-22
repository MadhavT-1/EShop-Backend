using EShop_Backend.Config;
using EShop_Backend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace EShop_Backend.Controllers
{
    [ApiController]
    [Route("users/")]
    public class UsersController : Controller
    {
         EshopDbContext _context;
        public UsersController(EshopDbContext context)
        {
            _context = context;
        }

        [HttpGet("get")]
        public  IEnumerable<Users> GetUsers()
        {
            return _context.Users.ToList();
        }

        [HttpPost("create")]
        public ActionResult CreateUser(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }
    }
}
