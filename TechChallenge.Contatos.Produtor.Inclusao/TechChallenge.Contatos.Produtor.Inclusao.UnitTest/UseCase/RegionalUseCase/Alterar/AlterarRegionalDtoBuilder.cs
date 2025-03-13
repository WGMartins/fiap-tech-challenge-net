using Bogus;
using TechChallenge.UseCase.RegionalUseCase.Alterar;

namespace TechChallenge.UnitTest.UseCase.RegionalUseCase.Alterar
{
    public class AlterarRegionalDtoBuilder
    {
        private AlterarRegionalDto _adicionarRegionalDto;

        public AlterarRegionalDtoBuilder()
        {
            _adicionarRegionalDto = new AlterarRegionalDto
            {
                Id = Guid.Empty,
                Ddd = 0,
                Estado = string.Empty,
                Nome = string.Empty
            };
        }

        public AlterarRegionalDtoBuilder Default()
        {
            _adicionarRegionalDto = new Faker<AlterarRegionalDto>("pt_BR")
                .RuleFor(x =>  x.Id, f => f.Random.Guid())
                .RuleFor(x => x.Ddd, f => f.Phone.Random.Number(99))
                .RuleFor(x => x.Estado, f => f.Address.CountryCode())
                .RuleFor(x => x.Nome, f => f.Address.City());

            return this;
        }

        public AlterarRegionalDtoBuilder WithId(Guid id)
        {
            _adicionarRegionalDto.Id = id;
            return this;
        }

        public AlterarRegionalDtoBuilder WithDdd(int ddd)
        {
            _adicionarRegionalDto.Ddd = ddd;
            return this;
        }

        public AlterarRegionalDtoBuilder WithEstado(string estado)
        {
            _adicionarRegionalDto.Estado = estado;
            return this;
        }

        public AlterarRegionalDtoBuilder WithNome(string nome)
        {
            _adicionarRegionalDto.Nome = nome;
            return this;
        }

        public AlterarRegionalDto Build()
        {
            return _adicionarRegionalDto;
        }
    }
}
