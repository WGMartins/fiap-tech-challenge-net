using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Drawing;
using System.Reflection.Metadata;
using TechChallenge.Domain.RegionalAggregate;
using TechChallenge.Infrastructure.Repositories;
using TechChallenge.IntegrationTest.Seeders;

namespace TechChallenge.IntegrationTest.Factories
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        private readonly string _connectionString;

        public CustomWebApplicationFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
                if (descriptor != null)
                    services.Remove(descriptor);

                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(_connectionString)
                    .UseSeeding((context, _) =>
                    {
                        var regionalId = Guid.Parse("a4ae0efb-a238-4a15-b3ef-434cf78fa265");

                        var contato1Id = Guid.Parse("8f0fdc40-9485-4f1f-82df-ba974bcf2b0b");
                        var contato2Id = Guid.Parse("6cd33da5-7984-46ff-8924-f05b1aadaaa6");
                        var contato3Id = Guid.Parse("664441ea-62ff-47d9-9aa2-cd4433f4b46b");

                        var regional = context.Set<Regional>().FirstOrDefault(b => b.Id == regionalId);
                        if (regional == null)
                        {
                            context.Set<Regional>().Add(new Regional { Id = regionalId, Nome = "Regional Teste 36", Ddd = 36, Estado = "MG" });
                            context.SaveChanges();
                        }

                        var contato = context.Set<Contato>().FirstOrDefault(b => b.Id == contato1Id);
                        if (contato == null)
                        {
                            var contatos = new List<Contato>
                            {
                                new() { Id = contato1Id, Nome = "Contato Teste 1", Email = "email.contato@gmail.com", Telefone = "98877-6655", RegionalId = regionalId },
                                new() { Id = contato2Id, Nome = "Contato Teste 1", Email = "email.contato@gmail.com", Telefone = "98877-6655", RegionalId = regionalId },
                                new() { Id = contato3Id, Nome = "Contato Teste 1", Email = "email.contato@gmail.com", Telefone = "98877-6655", RegionalId = regionalId }
                            };

                            context.Set<Contato>().AddRange(contatos);

                            context.SaveChanges();
                        }
                    }));

                using (var scope = services.BuildServiceProvider().CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    db.Database.Migrate();
                }

            });
        }
    }
}
