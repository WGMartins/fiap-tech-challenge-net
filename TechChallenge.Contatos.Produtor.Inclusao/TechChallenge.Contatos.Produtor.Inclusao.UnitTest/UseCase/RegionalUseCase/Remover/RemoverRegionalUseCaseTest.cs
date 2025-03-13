using Moq;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Domain.RegionalAggregate;
using TechChallenge.UseCase.RegionalUseCase.Remover;
using TechChallenge.UseCase.Interfaces;
using TechChallenge.UnitTest.UseCase.Shared;

namespace TechChallenge.UnitTest.UseCase.RegionalUseCase.Remover
{
    public class RemoverRegionalUseCaseTest
    {
        private readonly Mock<IRegionalRepository> _regionalRepository;
        private readonly Mock<IContatoRepository> _contatoRepository;
        private readonly IRemoverRegionalUseCase _removerRegionalUseCase;
        private readonly RegionalBuilder _regionalBuilder;
        private readonly ContatoBuilder _contatoBuilder;

        public RemoverRegionalUseCaseTest()
        {
            _regionalRepository = new Mock<IRegionalRepository>();
            _contatoRepository = new Mock<IContatoRepository>();
            _removerRegionalUseCase = new RemoverRegionalUseCase(_regionalRepository.Object, _contatoRepository.Object);
            _regionalBuilder = new RegionalBuilder();
            _contatoBuilder = new ContatoBuilder();
        }

        [Fact]
        public void RemoverRegionalUseCase_Remover_Sucesso()
        {
            // Arrange            
            _regionalRepository.Setup(s => s.ObterPorId(It.IsAny<Guid>()))
                .Returns(_regionalBuilder.Build());

            _contatoRepository.Setup(s => s.ListarPorRegional(It.IsAny<Guid>()));

            _regionalRepository.Setup(s => s.Remover(It.IsAny<Regional>()));

            // Act
            _removerRegionalUseCase.Remover(Guid.NewGuid());

            // Assert            
            _regionalRepository.Verify(x => x.ObterPorId(It.IsAny<Guid>()), Times.Once());
            _regionalRepository.Verify(x => x.Remover(It.IsAny<Regional>()), Times.Once());
        }

        [Fact]
        public void ObterRegionalUseCase_Obter_RegionalNaoExistente()
        {
            // Arrange            
            _regionalRepository.Setup(s => s.ObterPorId(Guid.NewGuid()));

            // Act            
            var result = Assert.Throws<Exception>(() => _removerRegionalUseCase.Remover(Guid.NewGuid()));

            // Assert            
            Assert.Contains("Regional não encontrada", result.Message);

        }

        [Fact]
        public void ObterRegionalUseCase_Obter_RegionalPossuiContatosVinculados()
        {
            // Arrange            
            _regionalRepository.Setup(s => s.ObterPorId(It.IsAny<Guid>()))
                .Returns(_regionalBuilder.Build());

            _contatoRepository.Setup(s => s.ListarPorRegional(It.IsAny<Guid>()))
                .Returns(new List<Contato>() { _contatoBuilder.Build() });

            _regionalRepository.Setup(s => s.Remover(It.IsAny<Regional>()));

            // Act
            var result = Assert.Throws<Exception>(() => _removerRegionalUseCase.Remover(Guid.NewGuid()));

            // Assert            
            Assert.Contains("Regional possui contatos vinculados", result.Message);

        }
    }
}
