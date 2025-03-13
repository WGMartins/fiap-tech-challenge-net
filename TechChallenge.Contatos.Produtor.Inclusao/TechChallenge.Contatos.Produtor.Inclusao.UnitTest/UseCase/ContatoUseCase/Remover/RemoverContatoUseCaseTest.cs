using Moq;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Domain.RegionalAggregate;
using TechChallenge.UnitTest.UseCase.Shared;
using TechChallenge.UseCase.ContatoUseCase.Remover;
using TechChallenge.UseCase.Interfaces;

namespace TechChallenge.UnitTest.UseCase.ContatoUseCase.Remover
{
    public class RemoverRegionalUseCaseTest
    {
        private readonly Mock<IContatoRepository> _contatoRepository;
        private readonly IRemoverContatoUseCase _removerContatoUseCase;
        private readonly ContatoBuilder _contatoBuilder;

        public RemoverRegionalUseCaseTest()
        {
            _contatoRepository = new Mock<IContatoRepository>();
            _removerContatoUseCase = new RemoverContatoUseCase(_contatoRepository.Object);
            _contatoBuilder = new ContatoBuilder();
        }

        [Fact]
        public void RemoverContatoUseCase_Remover_Sucesso()
        {
            // Arrange            
            _contatoRepository.Setup(s => s.ObterPorId(It.IsAny<Guid>()))
                .Returns(_contatoBuilder.Build());

            _contatoRepository.Setup(s => s.Remover(It.IsAny<Contato>()));

            // Act
            _removerContatoUseCase.Remover(Guid.NewGuid());

            // Assert            
            _contatoRepository.Verify(x => x.ObterPorId(It.IsAny<Guid>()), Times.Once());
            _contatoRepository.Verify(x => x.Remover(It.IsAny<Contato>()), Times.Once());
        }

        [Fact]
        public void ObterContatoUseCase_Obter_ContatoNaoExistente()
        {
            // Arrange            
            _contatoRepository.Setup(s => s.ObterPorId(Guid.NewGuid()));

            // Act            
            var result = Assert.Throws<Exception>(() => _removerContatoUseCase.Remover(Guid.NewGuid()));

            // Assert            
            Assert.Contains("Contato não encontrado", result.Message);

        }
    }
}
