namespace MVCProject.Models
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal DisCountPrice { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
    }
}
