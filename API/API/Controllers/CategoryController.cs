using API.DATA;
using API.Dtos.CategoryDtos;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(int id)
        {
            Category product = _context.Categories.FirstOrDefault(p => p.Id == id);
            CategoryReturnDto categoryReturnDto = new CategoryReturnDto();
            categoryReturnDto.Name = product.Name;
            categoryReturnDto.IsActive = product.IsActive;

            if (product == null)
            {
                return NotFound();
            }
            return Ok(categoryReturnDto);
            // return Ok(products.First());
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var query = _context.Categories.Where(p => !p.IsDelete);


            CategoryListDto categoryListDto = new CategoryListDto();
            categoryListDto.Items = query
                .Select(p => new CategoryReturnDto
                {
                    Name = p.Name,
                    IsActive = p.IsActive
                })
                .ToList();

            categoryListDto.TotalCount = query.Count();

            return StatusCode(200, categoryListDto);
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateDto categoryCreateDto)
        {
            Category newCategory = new Category
            {
                Name = categoryCreateDto.Name,
                IsActive = categoryCreateDto.IsActive
            };
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return StatusCode(201, "Category yaradıldı");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CategoryUpdateDto categoryUpdateDto)
        {
            Category category = _context.Categories.FirstOrDefault(p => p.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            category.Name = categoryUpdateDto.Name;
            category.IsActive = categoryUpdateDto.IsActive;

            _context.SaveChanges();
            return StatusCode(200, category.Id);
        }

        [HttpPatch]
        public IActionResult ChangeIsActive(int id, bool isActive)
        {
            Category category = _context.Categories.FirstOrDefault(p => p.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            category.IsActive = isActive;

            _context.SaveChanges();
            return StatusCode(200, category.Id);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Category category = _context.Categories.FirstOrDefault(p => p.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Ok();
        }
    }
}
