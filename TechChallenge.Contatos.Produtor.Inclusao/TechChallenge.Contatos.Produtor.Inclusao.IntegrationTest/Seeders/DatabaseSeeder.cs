using TechChallenge.Domain.RegionalAggregate;
using TechChallenge.Infrastructure.Repositories;

namespace TechChallenge.IntegrationTest.Seeders
{
    public static class DatabaseSeeder
    {
        public static async Task SeedContato(ApplicationDbContext context)
        {
            var regionalId = Guid.Parse("a4ae0efb-a238-4a15-b3ef-434cf78fa265");
            var regional = new Regional { Id = regionalId, Nome = "Regional Teste", Ddd = 31, Estado = "MG" };

            var contatos = new List<Contato>
            {
                new() { Id = Guid.Parse("8f0fdc40-9485-4f1f-82df-ba974bcf2b0b"), Nome = "Contato Teste 1", Email = "email.contato@gmail.com", Telefone = "98877-6655", RegionalId = regionalId }
            };
          
            context.Regional.Add(regional);
            context.Contato.AddRange(contatos);
            await context.SaveChangesAsync();
        }
        
    }
}
