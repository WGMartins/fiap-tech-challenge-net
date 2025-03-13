using Moq;
using TechChallenge.Domain.Interfaces;
using TechChallenge.UnitTest.UseCase.Shared;
using TechChallenge.UseCase.Interfaces;
using TechChallenge.UseCase.RegionalUseCase.Obter;

namespace TechChallenge.UnitTest.UseCase.RegionalUseCase.Obter
{
    public class ObterRegionalUseCaseTest
    {
        private readonly Mock<IRegionalRepository> _regionalRepository;
        private readonly IObterRegionalUseCase _obterRegionalUseCase;
        private readonly RegionalBuilder _regionalBuilder;

        public ObterRegionalUseCaseTest()
        {
            _regionalRepository = new Mock<IRegionalRepository>();
            _obterRegionalUseCase = new ObterRegionalUseCase(_regionalRepository.Object);
            _regionalBuilder = new RegionalBuilder();
        }

        [Fact]
        public void ObterRegionalUseCase_Obter_Sucesso()
        {
            // Arrange            
            _regionalRepository.Setup(s => s.ObterPorId(It.IsAny<Guid>()))
                .Returns(_regionalBuilder.Build());

            // Act
            var result = _obterRegionalUseCase.ObterPorId(Guid.NewGuid());

            // Assert            
            _regionalRepository.Verify(x => x.ObterPorId(It.IsAny<Guid>()), Times.Once());
            Assert.True(result.Nome == _regionalBuilder.Build().Nome);
        }

        [Fact]
        public void ObterRegionalUseCase_Obter_RegionalNaoExistente()
        {
            // Arrange            
            _regionalRepository.Setup(s => s.ObterPorId(Guid.NewGuid()));

            // Act            
            var result = Assert.Throws<Exception>(() => _obterRegionalUseCase.ObterPorId(Guid.NewGuid()));

            // Assert            
            Assert.Contains("Regional não encontrada", result.Message);

        }
    }
}
