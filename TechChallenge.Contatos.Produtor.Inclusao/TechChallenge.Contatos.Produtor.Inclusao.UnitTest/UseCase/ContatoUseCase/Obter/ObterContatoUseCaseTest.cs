using Moq;
using TechChallenge.Domain.Interfaces;
using TechChallenge.UnitTest.UseCase.Shared;
using TechChallenge.UseCase.ContatoUseCase.Obter;
using TechChallenge.UseCase.Interfaces;

namespace TechChallenge.UnitTest.UseCase.ContatoUseCase.Obter
{
    public class ObterContatoUseCaseTest
    {
        private readonly Mock<IContatoRepository> _contatoRepository;
        private readonly IObterContatoUseCase _obterContatoUseCase;
        private readonly ContatoBuilder _contatoBuilder;

        public ObterContatoUseCaseTest()
        {
            _contatoRepository = new Mock<IContatoRepository>();
            _obterContatoUseCase = new ObterContatoUseCase(_contatoRepository.Object);
            _contatoBuilder = new ContatoBuilder();
        }

        [Fact]
        public void ObterContatoUseCase_Obter_Sucesso()
        {
            // Arrange            
            _contatoRepository.Setup(s => s.ObterPorId(It.IsAny<Guid>()))
                .Returns(_contatoBuilder.Build());

            // Act
            var result = _obterContatoUseCase.ObterPorId(Guid.NewGuid());

            // Assert            
            _contatoRepository.Verify(x => x.ObterPorId(It.IsAny<Guid>()), Times.Once());
            Assert.True(result.Nome == _contatoBuilder.Build().Nome);
        }

        [Fact]
        public void ObterContatoUseCase_Obter_ContatoNaoExistente()
        {
            // Arrange            
            _contatoRepository.Setup(s => s.ObterPorId(Guid.NewGuid()));

            // Act            
            var result = Assert.Throws<Exception>(() => _obterContatoUseCase.ObterPorId(Guid.NewGuid()));

            // Assert            
            Assert.Contains("Contato não encontrado", result.Message);
            
        }
    }
}
