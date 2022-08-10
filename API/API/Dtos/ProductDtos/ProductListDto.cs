using System.Collections.Generic;

namespace API.Dtos.ProductDtos
{
    public class ProductListDto
    {
        public int TotalCount { get; set; }
        public List<ProductReturnDto> Items { get; set; }
    }
}
