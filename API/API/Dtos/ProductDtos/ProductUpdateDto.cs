namespace API.Dtos.ProductDtos
{
    public class ProductUpdateDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
