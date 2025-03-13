using Bogus;
using TechChallenge.UseCase.RegionalUseCase.Adicionar;

namespace TechChallenge.UnitTest.UseCase.RegionalUseCase.Adicionar
{
    public class AdicionarRegionalDtoBuilder
    {
        private AdicionarRegionalDto _adicionarRegionalDto; 

        public AdicionarRegionalDtoBuilder()
        {
            _adicionarRegionalDto = new AdicionarRegionalDto
            {
                Ddd = 0,
                Estado = string.Empty,
                Nome = string.Empty
            };
        }

        public AdicionarRegionalDtoBuilder Default()
        {
            _adicionarRegionalDto = new Faker<AdicionarRegionalDto>("pt_BR")
                .RuleFor(x => x.Ddd, f => f.Phone.Random.Number(99))
                .RuleFor(x => x.Estado, f => f.Address.CountryCode())
                .RuleFor(x => x.Nome, f => f.Address.City());

            return this;
        }

        public AdicionarRegionalDtoBuilder WithDdd(int ddd)
        {
            _adicionarRegionalDto.Ddd = ddd;
            return this;
        }

        public AdicionarRegionalDtoBuilder WithEstado(string estado)
        {
            _adicionarRegionalDto.Estado = estado;
            return this;
        }

        public AdicionarRegionalDtoBuilder WithNome(string nome)
        {
            _adicionarRegionalDto.Nome = nome;
            return this;
        }

        public AdicionarRegionalDto Build()
        {
            return _adicionarRegionalDto;
        }
    }
}
