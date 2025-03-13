using TechChallenge.Domain.Interfaces;
using TechChallenge.Domain.RegionalAggregate;

namespace TechChallenge.Infrastructure.Repositories
{
    public class ContatoRepository : EFRepository<Contato>, IContatoRepository
    {
        public ContatoRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IList<Contato> ListarPorRegional(Guid regionalId)
        {
            return _dbSet.Where(x => x.RegionalId == regionalId).ToList();
        }
    }
}
