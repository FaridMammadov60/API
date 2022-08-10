using System.Collections.Generic;

namespace API.Dtos.CategoryDtos
{
    public class CategoryListDto
    {
        public int TotalCount { get; set; }
        public List<CategoryReturnDto> Items { get; set; }
    }
}
