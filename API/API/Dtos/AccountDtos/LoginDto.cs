using FluentValidation;

namespace API.Dtos.AccountDtos
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string CheckPassword { get; set; }
    }
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(r => r.Username).NotEmpty().WithMessage("bos olmaz");
            RuleFor(r => r.Password).NotEmpty().MinimumLength(8).MaximumLength(24);

        }
    }
}
