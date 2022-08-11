using Microsoft.AspNetCore.Http;

namespace API.Dtos.CategoryDtos
{
    public class CategoryCreateDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public IFormFile Photo { get; set; }

    }

}
