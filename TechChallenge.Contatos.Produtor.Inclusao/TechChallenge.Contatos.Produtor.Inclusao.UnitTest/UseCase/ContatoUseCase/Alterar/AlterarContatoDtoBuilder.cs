using Bogus;
using TechChallenge.UseCase.ContatoUseCase.Alterar;

namespace TechChallenge.UnitTest.UseCase.ContatoUseCase.Alterar
{
    public  class AlterarContatoDtoBuilder
    {
        private AlterarContatoDto _alterarContatoDto;

        public AlterarContatoDtoBuilder()
        {
            _alterarContatoDto = new AlterarContatoDto()
            { 
                Id = Guid.Empty,
                Nome = string.Empty,
                Telefone = string.Empty,
                Email = string.Empty,
                RegionalId = Guid.Empty,

            };
        }

        public AlterarContatoDtoBuilder Default()
        {
            _alterarContatoDto = new Faker<AlterarContatoDto>("pt_BR")
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.Nome, f => f.Person.FullName)
                .RuleFor(x => x.Telefone, f => f.Phone.PhoneNumber("9####-####"))
                .RuleFor(x => x.Email, f => f.Internet.Email())
                .RuleFor(x => x.RegionalId, f => f.Random.Guid());
            return this;
        }

        public AlterarContatoDtoBuilder WithId(Guid id)
        {
            _alterarContatoDto.Id = id;
            return this;
        }

        public AlterarContatoDtoBuilder WithName(string nome)
        {
            _alterarContatoDto.Nome = nome;
            return this;
        }

        public AlterarContatoDtoBuilder WithTelefone(string telefone)
        {
            _alterarContatoDto.Telefone = telefone;
            return this;
        }

        public AlterarContatoDtoBuilder WithEmail(string email)
        {
            _alterarContatoDto.Email = email;
            return this;
        }

        public AlterarContatoDtoBuilder WithRegionalId(Guid regionalId)
        {
            _alterarContatoDto.RegionalId = regionalId;
            return this;
        }

        public AlterarContatoDto Build()
        {
            return _alterarContatoDto;
        }
    }
}
