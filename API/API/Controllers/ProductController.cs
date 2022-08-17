using API.DATA;
using API.Dtos.ProductDtos;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(int id)
        {
            Product product = _context.Products.Include(c => c.Category).FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            //ProductReturnDto productReturnDto = new ProductReturnDto();
            //productReturnDto.Name = product.Name;
            //productReturnDto.Price = product.Price;
            //productReturnDto.IsActive = product.IsActive;
            //productReturnDto.CategoryId = product.CategoryId;
            ProductReturnDto productReturnDto = _mapper.Map<ProductReturnDto>(product);
            return Ok(productReturnDto);
            // return Ok(products.First());
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var query = _context.Products.Where(p => !p.IsDelete);


            ProductListDto productListDto = new ProductListDto();
            productListDto.Items = query
                .Select(p => new ProductReturnDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    IsActive = p.IsActive,
                })
                .ToList();

            //foreach (var item in products)
            //{
            //    ProductReturnDto productReturnDto = new ProductReturnDto();
            //    productReturnDto.Name = item.Name;
            //    productReturnDto.Price = item.Price;
            //    productReturnDto.IsActive = item.IsActive;
            //    productListDto.Items.Add(productReturnDto);
            //}
            //productListDto.Items = products;

            productListDto.TotalCount = query.Count();

            return StatusCode(200, productListDto);
            // return Ok(products.First());
        }
        [HttpPost]
        public IActionResult Create(ProductCreateDto productCreateDto)
        {
            Product newProduct = new Product
            {
                Name = productCreateDto.Name,
                Price = productCreateDto.Price,
                IsActive = productCreateDto.IsActive,
                CategoryId = productCreateDto.CategoryId,
                DisCountPrice = productCreateDto.DisCountPrice

            };
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return StatusCode(201, "Product yaradıldı");
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductUpdateDto productUpdateDto)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            product.Name = productUpdateDto.Name;
            product.Price = productUpdateDto.Price;
            product.IsActive = productUpdateDto.IsActive;
            product.CategoryId = productUpdateDto.CategoryId;

            _context.SaveChanges();
            return StatusCode(200, product.Id);
        }

        [HttpPatch]
        public IActionResult ChangeIsActive(int id, bool isActive)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
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
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok();
        }
    }
}
