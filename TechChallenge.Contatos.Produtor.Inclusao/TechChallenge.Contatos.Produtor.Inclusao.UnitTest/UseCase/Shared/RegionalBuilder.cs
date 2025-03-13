using Bogus;
using TechChallenge.Domain.RegionalAggregate;

namespace TechChallenge.UnitTest.UseCase.Shared
{
    public class RegionalBuilder
    {
        private Regional _regional;

        public RegionalBuilder()
        {
            _regional = new Faker<Regional>("pt_BR")
                .RuleFor(x => x.Ddd, f => f.Phone.Random.Number(99))
                .RuleFor(x => x.Estado, f => f.Address.CountryCode())
                .RuleFor(x => x.Nome, f => f.Address.City());
        }
        public RegionalBuilder WithId(Guid id)
        {
            _regional.Id = id;
            return this;
        }

        public Regional Build()
        {
            return _regional;
        }
    }
}

