using EShop_Backend.Config;
using EShop_Backend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShop_Backend.Controllers
{
    [ApiController]
    [Route("products/")]
    public class ProductsController:Controller
    {
        private readonly EshopDbContext _context;

        public ProductsController(EshopDbContext context)
        {
            _context = context;
        }

        [HttpGet("get")]
        public IEnumerable<Products> GetProducts()
        {
            return _context.Products.ToList();
        }
        [HttpPost("create")]
        public IActionResult Create(Products product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok(product);
        }
    }
}
