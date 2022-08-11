using API.DATA;
using API.Dtos.CategoryDtos;
using API.Extentions;
using API.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;


        public CategoryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(int id)
        {
            Category category = _context.Categories.FirstOrDefault(p => p.Id == id);
            CategoryReturnDto categoryReturnDto = new CategoryReturnDto();
            categoryReturnDto.Name = category.Name;
            categoryReturnDto.IsActive = category.IsActive;
            categoryReturnDto.ImageUrl = "https://localhost:44369/" + category.ImageUrl;

            if (category == null)
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
                    IsActive = p.IsActive,
                    ImageUrl = "https://localhost:44369/" + p.ImageUrl
                })
                .ToList();

            categoryListDto.TotalCount = query.Count();

            return StatusCode(200, categoryListDto);
        }

        [HttpPost]
        public IActionResult Create([FromForm] CategoryCreateDto categoryCreateDto)
        {
            bool existCategroy = _context.Categories.Any(c => c.Name.ToLower() == categoryCreateDto.Name.ToLower());
            if (existCategroy)
            {
                return StatusCode(409);
            }

            if (!categoryCreateDto.Photo.IsImage())
            {
                return BadRequest();
            }
            if (!categoryCreateDto.Photo.ValidSize(5))
            {
                return BadRequest();
            }

            Category newCategory = new Category
            {
                Name = categoryCreateDto.Name,
                IsActive = categoryCreateDto.IsActive,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                ImageUrl = categoryCreateDto.Photo.SaveImage(_env, "img")

            };
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return StatusCode(201, "Category yaradıldı");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromForm] CategoryUpdateDto categoryUpdateDto)
        {
            Category category = _context.Categories.FirstOrDefault(p => p.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            if (_context.Categories
                .Any(c => c.Name.ToLower() == categoryUpdateDto.Name.ToLower()
                && category.Id != id))
            {
                return BadRequest();
            }

            if (true)
            {
                string path = Path.Combine(_env.WebRootPath, "img", category.ImageUrl);
            }
            if (categoryUpdateDto.Photo != null)
            {
                if (!categoryUpdateDto.Photo.IsImage())
                {
                    return BadRequest();
                }
                if (!categoryUpdateDto.Photo.ValidSize(5))
                {

                    return BadRequest();
                }

                string path = Path.Combine(_env.WebRootPath, "img", category.ImageUrl);
                Helpers.Helper.DeleteImage(path);
                category.ImageUrl = categoryUpdateDto.Photo.SaveImage(_env, "img");

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
            string path = Path.Combine(_env.WebRootPath, "img", category.ImageUrl);
            Helpers.Helper.DeleteImage(path);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Ok();
        }
    }
}
