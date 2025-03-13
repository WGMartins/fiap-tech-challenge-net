using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;
using TechChallenge.Infrastructure.Repositories;
using TechChallenge.IntegrationTest.Factories;
using TechChallenge.IntegrationTest.Fixtures;
using TechChallenge.IntegrationTest.Seeders;
using TechChallenge.UseCase.ContatoUseCase.Adicionar;
using TechChallenge.UseCase.ContatoUseCase.Alterar;
using TechChallenge.UseCase.ContatoUseCase.Obter;
using TechChallenge.UseCase.RegionalUseCase.Adicionar;
using TechChallenge.UseCase.RegionalUseCase.Alterar;
using TechChallenge.UseCase.RegionalUseCase.Obter;
using TechChallenge.UseCase.Shared;

namespace TechChallenge.IntegrationTest.Tests
{
    public class ContatoControllerTest : IClassFixture<DatabaseFixture>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory _factory;

        public ContatoControllerTest(DatabaseFixture databaseFixture)
        {
            var factory = new CustomWebApplicationFactory(databaseFixture.Container.GetConnectionString());
            _client = factory.CreateClient();
            _factory = factory;

            using var scope = _factory.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            //DatabaseSeeder.SeedContato(dbContext).Wait();
        }

        [Fact]
        public async Task ContatoController_ListarContatos_Sucesso()
        {
            //Arrange           

            //Act            
            var response = await _client.GetAsync("/contato");

            //Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseString);
        }

        [Fact]
        public async Task ContatoController_ObterPorIdContato_Sucesso()
        {
            //Arrange                      

            //Act            
            var response = await _client.GetAsync($"/contato/{Guid.Parse("8f0fdc40-9485-4f1f-82df-ba974bcf2b0b")}");

            //Assert
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadFromJsonAsync<ContatoObtidoDto>();
            Assert.NotNull(responseData);
            Assert.Equal("Contato Teste 1", responseData.Nome);
            Assert.Equal("email.contato@gmail.com", responseData.Email);
            Assert.Equal("98877-6655", responseData.Telefone);            
        }

        [Fact]
        public async Task ContatoController_AdicionarContato_Sucesso()
        {
            //Arrange
            var contato = new AdicionarContatoDto { Nome = "Contato 1", Email = "email@teste.com.br", Telefone = "99955-6633", RegionalId = Guid.Parse("a4ae0efb-a238-4a15-b3ef-434cf78fa265") };

            //Act            
            var response = await _client.PostAsJsonAsync($"/contato", contato);            

            //Assert
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadFromJsonAsync<ContatoAdicionadoDto>();
            Assert.NotNull(responseData);
            Assert.NotEqual(Guid.Empty, responseData.Id);
        }

        [Fact]
        public async Task ContatoController_AlterarContato_Sucesso()
        {
            //Arrange            
            var contatoAlterado = new AlterarContatoDto 
            {   Id = Guid.Parse("6cd33da5-7984-46ff-8924-f05b1aadaaa6"), 
                Nome = "Teste alterado", 
                Email = "emailalterado@gmail.com", 
                Telefone = "99911-2233", 
                RegionalId = Guid.Parse("a4ae0efb-a238-4a15-b3ef-434cf78fa265") 
            };

            //Act            
            var response = await _client.PutAsJsonAsync($"/contato", contatoAlterado);

            //Assert
            response.EnsureSuccessStatusCode();

            var responseGetById = await _client.GetAsync($"/contato/{contatoAlterado.Id}");

            var responseData = await responseGetById.Content.ReadFromJsonAsync<ContatoObtidoDto>();
            Assert.NotNull(responseData);
            Assert.Equal(contatoAlterado.Nome, responseData.Nome);
            Assert.Equal(contatoAlterado.Email, responseData.Email);
            Assert.Equal(contatoAlterado.Telefone, responseData.Telefone);

        }

        [Fact]
        public async Task ContatoController_RemoverContato_Sucesso()
        {
            //Arrange            

            //Act            
            var response = await _client.DeleteAsync($"/contato/{Guid.Parse("664441ea-62ff-47d9-9aa2-cd4433f4b46b")}");

            //Assert
            response.EnsureSuccessStatusCode();
            var responseGetById = await _client.GetAsync($"/contato/ {Guid.Parse("664441ea-62ff-47d9-9aa2-cd4433f4b46b")}");
            var mensagemErro = await responseGetById.Content.ReadAsStringAsync();
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, responseGetById.StatusCode);
            Assert.Equal("Contato não encontrado", mensagemErro);
        }
    }
}
