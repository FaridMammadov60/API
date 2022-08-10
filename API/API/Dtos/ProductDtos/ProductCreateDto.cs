namespace API.Dtos.ProductDtos
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
