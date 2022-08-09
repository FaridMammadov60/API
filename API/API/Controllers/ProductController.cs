using API.DATA;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return StatusCode(200, product);
            // return Ok(products.First());
        }

        [HttpGet]
        [Route("All")]
        public IActionResult GetAll()
        {
            return StatusCode(200, _context.Products.ToList());
            // return Ok(products.First());
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return StatusCode(201);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product newProduct)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            product.Name = newProduct.Name;
            product.Price = newProduct.Price;
            product.IsActive = newProduct.IsActive;
          
            _context.SaveChanges();
            return StatusCode(200, product.Id);
        }

        [HttpPatch]
        public IActionResult ChangeIsActive(int id,bool isActive)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id ==id);
            if (product == null)
            {
                return NotFound();
            }
            product.IsActive = isActive;

            _context.SaveChanges();
            return StatusCode(200, product.Id);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Product product = _context.Products.FirstOrDefault(p=>p.Id==id);
            if (product==null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok();
        }
    }
}
