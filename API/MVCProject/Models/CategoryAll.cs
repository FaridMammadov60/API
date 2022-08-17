using System.Collections.Generic;

namespace MVCProject.Models
{
    public class CategoryAll
    {
        public int TotalCount { get; set; }
        public List<CategoryReturnDto> Items { get; set; }
    }
    public class CategoryReturnDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; }
        public int ProductCount { get; set; }
    }
}
