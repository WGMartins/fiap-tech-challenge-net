using Bogus;
using TechChallenge.Domain.RegionalAggregate;

namespace TechChallenge.UnitTest.UseCase.Shared
{
    public class ContatoBuilder
    {
        private Contato _contato;
        private Regional _regional;

        public ContatoBuilder()
        {
            _regional = new Faker<Regional>("pt_BR")
                .RuleFor(x => x.Ddd, f => f.Phone.Random.Number(99))
                .RuleFor(x => x.Estado, f => f.Address.CountryCode())
                .RuleFor(x => x.Nome, f => f.Address.City());

            _contato = new Faker<Contato>("pt_BR")
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.Nome, f => f.Person.FullName)
                .RuleFor(x => x.Telefone, f => f.Phone.PhoneNumber("9####-####"))
                .RuleFor(x => x.Email, f => f.Internet.Email())
                .RuleFor(x => x.RegionalId, f => f.Random.Guid())
                .RuleFor(x => x.Regional, f => _regional);
        }
        public ContatoBuilder WithId(Guid id)
        {
            _contato.Id = id;
            return this;
        }

        public Contato Build()
        {
            return _contato;
        }
    }
}

