using System.Threading.Tasks;
using Testcontainers.PostgreSql;

namespace TechChallenge.IntegrationTest.Fixtures;

public class DatabaseFixture: IAsyncLifetime
{
    public PostgreSqlContainer Container { get; private set; }

    public async Task InitializeAsync()
    {        
        Container = new PostgreSqlBuilder()
            .WithDatabase("test_db")
            .WithUsername("test_user")
            .WithPassword("test_pass")
            .Build();

        await Container.StartAsync();     
    }
    public async Task DisposeAsync()
    {
        await Container.DisposeAsync();
    }

    
}

