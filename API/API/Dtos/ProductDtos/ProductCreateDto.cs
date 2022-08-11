using FluentValidation;

namespace API.Dtos.ProductDtos
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal DisCountPrice { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
    }
    public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("bosh qoyma").MaximumLength(100).WithMessage("100den cox ola bilmez");
            RuleFor(c => c.Price).GreaterThan(0).WithMessage("sifirdan boyuk olmalidi");
            RuleFor(c => c.IsActive).NotEmpty().WithMessage("bosh qoyma");
            RuleFor(p => p).Custom((p, context) =>
            {
                if (p.Price<p.DisCountPrice)
                {
                    context.AddFailure("Price", "price discuonpricedan kicik ola bilmez");
                }

            });
        }

    }

}
