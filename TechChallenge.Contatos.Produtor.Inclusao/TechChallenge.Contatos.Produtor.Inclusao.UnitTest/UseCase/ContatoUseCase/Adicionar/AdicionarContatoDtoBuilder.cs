using Bogus;
using TechChallenge.UseCase.ContatoUseCase.Adicionar;

namespace TechChallenge.UnitTest.UseCase.ContatoUseCase.Adicionar
{
    public class AdicionarContatoDtoBuilder
    {
        private AdicionarContatoDto _adicionarContatoDto;

        public AdicionarContatoDtoBuilder()
        {
            _adicionarContatoDto = new AdicionarContatoDto()
            {
                Nome = string.Empty,
                Telefone = string.Empty,
                Email = string.Empty,
                RegionalId = Guid.Empty,
            };
        }

        public AdicionarContatoDtoBuilder Default()
        {
            _adicionarContatoDto = new Faker<AdicionarContatoDto>("pt_BR")
                .RuleFor(x => x.Nome, f => f.Person.FullName)
                .RuleFor(x => x.Telefone, f => f.Phone.PhoneNumber("9####-####"))
                .RuleFor(x => x.Email, f => f.Internet.Email())
                .RuleFor(x => x.RegionalId, f => f.Random.Guid());

            return this;
        }

        public AdicionarContatoDtoBuilder WithName(string nome)
        {
            _adicionarContatoDto.Nome = nome;
            return this;
        }

        public AdicionarContatoDtoBuilder WithTelefone(string telefone)
        {
            _adicionarContatoDto.Telefone = telefone;
            return this;
        }

        public AdicionarContatoDtoBuilder WithEmail(string email)
        {
            _adicionarContatoDto.Email = email;
            return this;
        }

        public AdicionarContatoDtoBuilder WithRegionalId(Guid regionalId)
        {
            _adicionarContatoDto.RegionalId = regionalId;
            return this;
        }

        public AdicionarContatoDto Build()
        {
            return _adicionarContatoDto;
        }
    }
}
