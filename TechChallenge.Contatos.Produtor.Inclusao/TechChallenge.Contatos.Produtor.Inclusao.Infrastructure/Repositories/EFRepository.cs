using Microsoft.EntityFrameworkCore;
using TechChallenge.Domain;
using TechChallenge.Domain.Interfaces;

namespace TechChallenge.Infrastructure.Repositories
{
    public class EFRepository<T> : IRepository<T> where T : EntityBase
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> _dbSet;

        public EFRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Alterar(T entidade)
        {
            entidade.AlteradoEm = DateTime.Now;

            _dbSet.Update(entidade);
            _context.SaveChanges();
        }

        public void Adicionar(T entidade)
        {
            _dbSet.Add(entidade);
            _context.SaveChanges();
        }

        public void Remover(T entidade)
        {
            _dbSet.Remove(entidade);
            _context.SaveChanges();
        }

        public T ObterPorId(Guid id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public IList<T> Listar()
        {
            return _dbSet.ToList();
        }
    }
}
