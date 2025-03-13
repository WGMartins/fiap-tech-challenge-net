using FluentValidation;

namespace TechChallenge.UseCase.ContatoUseCase.Adicionar
{
    public class AdicionarContatoValidator : AbstractValidator<AdicionarContatoDto>
    {
        public AdicionarContatoValidator()
        {
            RuleFor(x => x.Nome)
               .NotEmpty()
               .WithMessage("Nome não pode ser nulo ou vazio")
               .MaximumLength(100)
               .WithMessage("Foi atingido o número máximo de caracteres (100)");

            RuleFor(x => x.Telefone)
                .NotEmpty()
                .WithMessage("Telefone não pode ser nulo ou vazio")
                .MaximumLength(10)
                .WithMessage("Foi atingido o número máximo de caracteres (10)")
                .Matches("^(?:[2-8]|9[0-9])[0-9]{3}\\-[0-9]{4}$")
                .WithMessage("Telefone inválido");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email não pode ser nulo ou vazio")
                .MaximumLength(150)
                .WithMessage("Foi atingido o número máximo de caracteres (150)")
                .Matches("^[a-zA-Z0-9][-\\._a-zA-Z0-9]+@[a-z0-9]+\\.[a-z]+(\\.[a-z]+)?")
                .WithMessage("E-mail inválido");
        }
    }
}
