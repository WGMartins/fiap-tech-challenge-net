using Moq;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Domain.RegionalAggregate;
using TechChallenge.UnitTest.UseCase.Shared;
using TechChallenge.UseCase.Interfaces;
using TechChallenge.UseCase.RegionalUseCase.Listar;
using TechChallenge.UseCase.RegionalUseCase.Obter;

namespace TechChallenge.UnitTest.UseCase.RegionalUseCase.Listar
{
    public class ListarRegionalUseCaseTest
    {
        private readonly Mock<IRegionalRepository> _regionalRepository;
        private readonly Mock<IContatoRepository> _contatoRepository;
        private readonly IListarRegionalUseCase _listarRegionalUseCase;
        private readonly RegionalBuilder _regionalBuilder;
        private readonly ContatoBuilder _contatoBuilder;

        public ListarRegionalUseCaseTest()
        {
            _regionalRepository = new Mock<IRegionalRepository>();
            _contatoRepository = new Mock<IContatoRepository>();
            _listarRegionalUseCase = new ListarRegionalUseCase(_regionalRepository.Object, _contatoRepository.Object);
            _regionalBuilder = new RegionalBuilder();
            _contatoBuilder = new ContatoBuilder();
        }

        [Fact]
        public void ListarRegionalUseCase_ListarContatosPorRegionalId_Sucesso()
        {
            // Arrange            
            _regionalRepository.Setup(s => s.ObterPorId(It.IsAny<Guid>()))
                .Returns(_regionalBuilder.Build());

            _contatoRepository.Setup(s => s.ListarPorRegional(It.IsAny<Guid>()))
                .Returns(new List<Contato>() { _contatoBuilder.Build() });

            // Act
            var result = _listarRegionalUseCase.ListarContatosPorRegionalId(Guid.NewGuid());

            // Assert            
            _regionalRepository.Verify(x => x.ObterPorId(It.IsAny<Guid>()), Times.Once());
            _contatoRepository.Verify(x => x.ListarPorRegional(It.IsAny<Guid>()), Times.Once());
            Assert.True(result.First().Id == _contatoBuilder.Build().Id);
        }

        [Fact]
        public void ListarRegionalUseCase_ListarContatosPorRegionalId_RegionalNaoExistente()
        {
            // Arrange            
            _regionalRepository.Setup(s => s.ObterPorId(Guid.NewGuid()));

            // Act            
            var result = Assert.Throws<Exception>(() => _listarRegionalUseCase.ListarContatosPorRegionalId(Guid.NewGuid()));

            // Assert            
            Assert.Contains("Regional não encontrada", result.Message);

        }

        [Fact]
        public void ListarRegionalUseCase_ListarContatosPorRegionalId_ContatosNaoExistentes()
        {
            // Arrange            
            _regionalRepository.Setup(s => s.ObterPorId(It.IsAny<Guid>()))
                .Returns(_regionalBuilder.Build());

            _contatoRepository.Setup(s => s.ListarPorRegional(It.IsAny<Guid>()));

            // Act            
            var result = Assert.Throws<Exception>(() => _listarRegionalUseCase.ListarContatosPorRegionalId(Guid.NewGuid()));

            // Assert            
            Assert.Contains("Regional não possui contatos vinculados", result.Message);

        }

        [Fact]
        public void ListarRegionalUseCase_ListarContatosPorDdd_Sucesso()
        {
            // Arrange            
            _regionalRepository.Setup(s => s.ObterPorDdd(It.IsAny<int>()))
                .Returns(_regionalBuilder.Build());

            _contatoRepository.Setup(s => s.ListarPorRegional(It.IsAny<Guid>()))
                .Returns(new List<Contato>() { _contatoBuilder.Build() });

            // Act
            var result = _listarRegionalUseCase.ListarContatosPorDdd(new Random().Next(11, 99));

            // Assert            
            _regionalRepository.Verify(x => x.ObterPorDdd(It.IsAny<int>()), Times.Once());
            _contatoRepository.Verify(x => x.ListarPorRegional(It.IsAny<Guid>()), Times.Once());
            Assert.True(result.First().Id == _contatoBuilder.Build().Id);
        }

        [Fact]
        public void ListarRegionalUseCase_ListarContatosPorDdd_RegionalNaoExistente()
        {
            // Arrange            
            _regionalRepository.Setup(s => s.ObterPorDdd(It.IsAny<int>()));

            // Act            
            var result = Assert.Throws<Exception>(() => _listarRegionalUseCase.ListarContatosPorDdd(new Random().Next(11, 99)));

            // Assert            
            Assert.Contains("Regional não encontrada", result.Message);

        }

        [Fact]
        public void ListarRegionalUseCase_ListarContatosPorDdd_ContatosNaoExistentes()
        {
            // Arrange            
            _regionalRepository.Setup(s => s.ObterPorDdd(It.IsAny<int>()))
                .Returns(_regionalBuilder.Build());

            _contatoRepository.Setup(s => s.ListarPorRegional(It.IsAny<Guid>()));

            // Act            
            var result = Assert.Throws<Exception>(() => _listarRegionalUseCase.ListarContatosPorDdd(new Random().Next(11, 99)));

            // Assert            
            Assert.Contains("Regional não possui contatos vinculados", result.Message);

        }
    }
}
