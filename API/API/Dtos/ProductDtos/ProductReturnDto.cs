namespace API.Dtos.ProductDtos
{
    public class ProductReturnDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }        
        public ProductCategoryDto Category { get; set; }
    }
    public class ProductCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
