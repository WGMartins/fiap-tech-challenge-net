using FluentValidation;
using Moq;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Domain.RegionalAggregate;
using TechChallenge.UseCase.ContatoUseCase.Alterar;
using TechChallenge.UseCase.Interfaces;
using TechChallenge.UseCase.RegionalUseCase.Adicionar;
using TechChallenge.UseCase.RegionalUseCase.Alterar;
using TechChallenge.UseCase.RegionalUseCase.Alterar.Validators;

namespace TechChallenge.UnitTest.UseCase.RegionalUseCase.Alterar
{
    public class AlterarRegionalUseCaseTest
    {
        private readonly AlterarRegionalDtoBuilder _builder;        
        private readonly Mock<IRegionalRepository> _regionalRepository;
        private readonly IValidator<AlterarRegionalDto> _validator;
        private readonly IAlterarRegionalUseCase _alterarRegionalUseCase;

        public AlterarRegionalUseCaseTest()
        {
            _validator = new AlterarRegionalValidator();
            _regionalRepository = new Mock<IRegionalRepository>();
            _builder = new AlterarRegionalDtoBuilder();
            _alterarRegionalUseCase = new AlterarRegionalUseCase(_regionalRepository.Object, _validator);
        }

        [Fact]
        public void AlterarRegionalUseCase_Alterar_Sucesso()
        {
            // Arrange
            var alterarContatoDto = _builder.Default().Build();

            _regionalRepository.Setup(s => s.Alterar(It.IsAny<Regional>()));
            _regionalRepository.Setup(s => s.ObterPorId(It.IsAny<Guid>()))
                .Returns(new Regional(alterarContatoDto.Id,
                    alterarContatoDto.Ddd,
                    alterarContatoDto.Estado,
                    alterarContatoDto.Nome));

            // Act
            _alterarRegionalUseCase.Alterar(alterarContatoDto);

            // Assert            
            _regionalRepository.Verify(x => x.Alterar(It.IsAny<Regional>()), Times.Once());
            _regionalRepository.Verify(x => x.ObterPorId(It.IsAny<Guid>()), Times.Once());

        }

        [Theory]
        [InlineData(120)]
        [InlineData(0)]
        public void AlterarRegionalUseCase_Alterar_ErroValidacaoDdd(int ddd)
        {
            // Arrange
            var adicionaRegionalDto = _builder.Default().WithDdd(ddd).Build();
            _regionalRepository.Setup(s => s.Alterar(It.IsAny<Regional>()));
            _regionalRepository.Setup(s => s.ObterPorId(It.IsAny<Guid>()))
                .Returns(new Regional(adicionaRegionalDto.Id,
                    adicionaRegionalDto.Ddd,
                    adicionaRegionalDto.Estado,
                    adicionaRegionalDto.Nome));

            // Act
            var result = Assert.Throws<Exception>(() => _alterarRegionalUseCase.Alterar(adicionaRegionalDto));

            // Assert
            Assert.Contains("DDD deve pertencer ao intervalo [1-99]", result.Message);
        }


        [Theory]
        [InlineData("")]
        [InlineData("     ")]
        public void AlterarRegionalUseCase_Alterar_ErroValidacaoNomeNuloVazio(string nome)
        {
            // Arrange
            var adicionaRegionalDto = _builder.Default().WithNome(nome).Build();
            _regionalRepository.Setup(s => s.Alterar(It.IsAny<Regional>()));
            _regionalRepository.Setup(s => s.ObterPorId(It.IsAny<Guid>()))
                .Returns(new Regional(adicionaRegionalDto.Id,
                    adicionaRegionalDto.Ddd,
                    adicionaRegionalDto.Estado,
                    adicionaRegionalDto.Nome));

            // Act
            var result = Assert.Throws<Exception>(() => _alterarRegionalUseCase.Alterar(adicionaRegionalDto));

            // Assert
            Assert.Contains("Nome não pode ser nulo ou vazio", result.Message);
        }

        [Theory]
        [InlineData("testetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetesteteste")]
        public void AlterarRegionalUseCase_Alterar_ErroValidacaoNomeTamanho(string nome)
        {
            // Arrange
            var alterarRegionalDto = _builder.Default().WithNome(nome).Build();
            _regionalRepository.Setup(s => s.Alterar(It.IsAny<Regional>()));
            _regionalRepository.Setup(s => s.ObterPorId(It.IsAny<Guid>()))
                .Returns(new Regional(alterarRegionalDto.Id,
                    alterarRegionalDto.Ddd,
                    alterarRegionalDto.Estado,
                    alterarRegionalDto.Nome));

            // Act
            var result = Assert.Throws<Exception>(() => _alterarRegionalUseCase.Alterar(alterarRegionalDto));

            // Assert
            Assert.Contains("Foi atingido o número máximo de caracteres (100)", result.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("     ")]
        public void AlterarRegionalUseCase_Adicionar_ErroValidacaoEstadoNuloVazio(string estado)
        {
            // Arrange
            var alterarRegionalDto = _builder.Default().WithEstado(estado).Build();
            _regionalRepository.Setup(s => s.Alterar(It.IsAny<Regional>()));
            _regionalRepository.Setup(s => s.ObterPorId(It.IsAny<Guid>()))
                .Returns(new Regional(alterarRegionalDto.Id,
                    alterarRegionalDto.Ddd,
                    alterarRegionalDto.Estado,
                    alterarRegionalDto.Nome));

            // Act
            var result = Assert.Throws<Exception>(() => _alterarRegionalUseCase.Alterar(alterarRegionalDto));

            // Assert
            Assert.Contains("Estado não pode ser nulo ou vazio", result.Message);
        }

        [Theory]
        [InlineData("MGED")]
        public void AlterarRegionalUseCase_Alterar_ErroValidacaoEstadoTamanho(string estado)
        {
            // Arrange
            var adicionaRegionalDto = _builder.Default().WithEstado(estado).Build();
            _regionalRepository.Setup(s => s.Adicionar(It.IsAny<Regional>()));

            // Act
            var result = Assert.Throws<Exception>(() => _alterarRegionalUseCase.Alterar(adicionaRegionalDto));

            // Assert
            Assert.Contains("Foi atingido o número máximo de caracteres (2)", result.Message);
        }


    }
}
