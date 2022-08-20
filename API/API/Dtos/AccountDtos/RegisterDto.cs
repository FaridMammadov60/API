using FluentValidation;

namespace API.Dtos.AccountDtos
{
    public class RegisterDto
    {
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string CheckPassword { get; set; }
    }
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(r => r.Username).NotEmpty().WithMessage("bos olmaz");
            RuleFor(r => r.Password).NotEmpty().MinimumLength(8).MaximumLength(24);
            RuleFor(r => r.CheckPassword).NotEmpty().MinimumLength(8).MaximumLength(24);
            RuleFor(r => r).Custom((r, context) =>
            {
                if (r.Password != r.CheckPassword)
                {
                    context.AddFailure("Password", "duz deyil");
                }
            });
        }
    }
}
