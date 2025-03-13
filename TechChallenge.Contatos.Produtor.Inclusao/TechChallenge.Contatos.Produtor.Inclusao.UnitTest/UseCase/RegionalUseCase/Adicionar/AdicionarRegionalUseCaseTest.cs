using FluentValidation;
using Moq;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Domain.RegionalAggregate;
using TechChallenge.UseCase.Interfaces;
using TechChallenge.UseCase.RegionalUseCase.Adicionar;

namespace TechChallenge.UnitTest.UseCase.RegionalUseCase.Adicionar
{
    public class AdicionarRegionalUseCaseTest
    {
        private readonly AdicionarRegionalDtoBuilder _builder;
        private readonly Mock<IRegionalRepository> _regionalRepository;
        private readonly IValidator<AdicionarRegionalDto> _validator;
        private readonly IAdicionarRegionalUseCase _adicionarRegionalUseCase;

        public AdicionarRegionalUseCaseTest()
        {
            _builder = new AdicionarRegionalDtoBuilder();
            _regionalRepository = new Mock<IRegionalRepository>();
            _validator = new AdicionarRegionalValidator();
            _adicionarRegionalUseCase = new AdicionarRegionalUseCase(_regionalRepository.Object, _validator);
        }

        [Fact]
        public void AdicionarRegionalUseCase_Adicionar_Sucesso()
        {
            // Arrange
            var adicionarRegionalDto = _builder.Default().Build();
            _regionalRepository.Setup(s => s.Adicionar(It.IsAny<Regional>()));
            
            //Act
            var result = _adicionarRegionalUseCase.Adicionar(adicionarRegionalDto);

            //Assert
            Assert.True(result.Id != default);
        }

        [Theory]
        [InlineData(120)]
        [InlineData(0)]
        public void AdicionarRegionalUseCase_Adicionar_ErroValidacaoDdd(int ddd)
        {
            // Arrange
            var adicionaRegionalDto = _builder.Default().WithDdd(ddd).Build();
            _regionalRepository.Setup(s => s.Adicionar(It.IsAny<Regional>()));

            // Act
            var result = Assert.Throws<Exception>(() => _adicionarRegionalUseCase.Adicionar(adicionaRegionalDto));

            // Assert
            Assert.Contains("DDD deve pertencer ao intervalo [1-99]", result.Message);
        }


        [Theory]
        [InlineData("")]
        [InlineData("     ")]
        public void AdicionarRegionalUseCase_Adicionar_ErroValidacaoNomeNuloVazio(string nome)
        {
            // Arrange
            var adicionaRegionalDto = _builder.Default().WithNome(nome).Build();
            _regionalRepository.Setup(s => s.Adicionar(It.IsAny<Regional>()));

            // Act
            var result = Assert.Throws<Exception>(() => _adicionarRegionalUseCase.Adicionar(adicionaRegionalDto));

            // Assert
            Assert.Contains("Nome não pode ser nulo ou vazio", result.Message);
        }

        [Theory]
        [InlineData("testetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetesteteste")]        
        public void AdicionarRegionalUseCase_Adicionar_ErroValidacaoNomeTamanho(string nome)
        {
            // Arrange
            var adicionaRegionalDto = _builder.Default().WithNome(nome).Build();
            _regionalRepository.Setup(s => s.Adicionar(It.IsAny<Regional>()));

            // Act
            var result = Assert.Throws<Exception>(() => _adicionarRegionalUseCase.Adicionar(adicionaRegionalDto));

            // Assert
            Assert.Contains("Foi atingido o número máximo de caracteres (100)", result.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData("     ")]
        public void AdicionarRegionalUseCase_Adicionar_ErroValidacaoEstadoNuloVazio(string estado)
        {
            // Arrange
            var adicionaRegionalDto = _builder.Default().WithEstado(estado).Build();
            _regionalRepository.Setup(s => s.Adicionar(It.IsAny<Regional>()));

            // Act
            var result = Assert.Throws<Exception>(() => _adicionarRegionalUseCase.Adicionar(adicionaRegionalDto));

            // Assert
            Assert.Contains("Estado não pode ser nulo ou vazio", result.Message);
        }

        [Theory]
        [InlineData("MGED")]
        public void AdicionarRegionalUseCase_Adicionar_ErroValidacaoEstadoTamanho(string estado)
        {
            // Arrange
            var adicionaRegionalDto = _builder.Default().WithEstado(estado).Build();
            _regionalRepository.Setup(s => s.Adicionar(It.IsAny<Regional>()));

            // Act
            var result = Assert.Throws<Exception>(() => _adicionarRegionalUseCase.Adicionar(adicionaRegionalDto));

            // Assert
            Assert.Contains("Foi atingido o número máximo de caracteres (2)", result.Message);
        }

    }
}
