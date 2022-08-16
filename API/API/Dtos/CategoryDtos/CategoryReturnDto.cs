namespace API.Dtos.CategoryDtos
{
    public class CategoryReturnDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; }
        public int ProductCount { get; set; }
    }
}
