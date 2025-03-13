using FluentValidation;
using Moq;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Domain.RegionalAggregate;
using TechChallenge.UseCase.ContatoUseCase.Adicionar;
using TechChallenge.UseCase.Interfaces;

namespace TechChallenge.UnitTest.UseCase.ContatoUseCase.Adicionar
{
    public class AdicionarContatoUseCaseTest
    {
        private readonly AdicionarContatoDtoBuilder _builder;
        private readonly Mock<IContatoRepository> _contatoRepository;
        private readonly IValidator<AdicionarContatoDto> _validator;
        private readonly IAdicionarContatoUseCase _adicionarContatoUseCase;

        public AdicionarContatoUseCaseTest()
        {
            _validator = new AdicionarContatoValidator();
            _contatoRepository = new Mock<IContatoRepository>();
            _builder = new AdicionarContatoDtoBuilder();

            _adicionarContatoUseCase = new AdicionarContatoUseCase(_contatoRepository.Object, _validator);

        }

        [Fact]
        public void AdicionarContatoUseCase_Adicionar_Sucesso()
        {
            // Arrange
            var adicionarContatoDto = _builder.Default().Build();            
            _contatoRepository.Setup(s => s.Adicionar(It.IsAny<Contato>()));

            // Act
            var result = _adicionarContatoUseCase.Adicionar(adicionarContatoDto);

            // Assert
            Assert.True(result.Id != default);
        }

        [Theory]
        [InlineData("")]
        [InlineData("     ")]
        public void AdicionarContatoUseCase_Adicionar_ErroValidacaoNome(string nome)
        {
            // Arrange
            var adicionarContatoDto = _builder.Default().WithName(nome).Build();            
            _contatoRepository.Setup(s => s.Adicionar(It.IsAny<Contato>()));

            // Act
            var result = Assert.Throws<Exception>(() => _adicionarContatoUseCase.Adicionar(adicionarContatoDto));

            // Assert
            Assert.Contains("Nome não pode ser nulo ou vazio", result.Message);
        }

        [Theory]        
        [InlineData("")]
        [InlineData("     ")]
        public void AdicionarContatoUseCase_Adicionar_ErroValidacaoTelefoneNuloVazio(string telefone)
        {
            // Arrange
            var adicionarContatoDto = _builder.Default().WithTelefone(telefone).Build();            
            _contatoRepository.Setup(s => s.Adicionar(It.IsAny<Contato>()));

            // Act
            var result = Assert.Throws<Exception>(() => _adicionarContatoUseCase.Adicionar(adicionarContatoDto));

            // Assert
            Assert.Contains("Telefone não pode ser nulo ou vazio", result.Message);
        }

        [Theory]
        [InlineData("12345754-556789")]        
        public void AdicionarContatoUseCase_Adicionar_ErroValidacaoTelefoneTamanho(string telefone)
        {
            // Arrange
            var adicionarContatoDto = _builder.Default().WithTelefone(telefone).Build();
            _contatoRepository.Setup(s => s.Adicionar(It.IsAny<Contato>()));

            // Act
            var result = Assert.Throws<Exception>(() => _adicionarContatoUseCase.Adicionar(adicionarContatoDto));

            // Assert
            Assert.Contains("Foi atingido o número máximo de caracteres (10)", result.Message);
        }

        [Theory]
        [InlineData("12345-6789")]
        [InlineData("08645-6441")]
        [InlineData("34887037")]
        [InlineData("999999999")]        
        public void AdicionarContatoUseCase_Adicionar_ErroValidacaoTelefoneFormato(string telefone)
        {
            // Arrange
            var adicionarContatoDto = _builder.Default().WithTelefone(telefone).Build();
            _contatoRepository.Setup(s => s.Adicionar(It.IsAny<Contato>()));

            // Act
            var result = Assert.Throws<Exception>(() => _adicionarContatoUseCase.Adicionar(adicionarContatoDto));

            // Assert
            Assert.Contains("Telefone inválido", result.Message);
        }

        [Theory]        
        [InlineData("")]
        [InlineData("     ")]        
        public void AdicionarContatoUseCase_Adicionar_ErroValidacaoEmailNuloVazio(string email)
        {
            // Arrange
            var adicionarContatoDto = _builder.Default().WithEmail(email).Build();            
            _contatoRepository.Setup(s => s.Adicionar(It.IsAny<Contato>()));

            // Act
            var result = Assert.Throws<Exception>(() => _adicionarContatoUseCase.Adicionar(adicionarContatoDto));

            // Assert
            Assert.Contains("Email não pode ser nulo ou vazio", result.Message);
        }

        [Theory]        
        [InlineData("testetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetesteteste" +
            "@testetestetestetestetestetestetestetestetestetestetesteteste")]
        public void AdicionarContatoUseCase_Adicionar_ErroValidacaoEmailTamanho(string email)
        {
            // Arrange
            var adicionarContatoDto = _builder.Default().WithEmail(email).Build();
            _contatoRepository.Setup(s => s.Adicionar(It.IsAny<Contato>()));

            // Act
            var result = Assert.Throws<Exception>(() => _adicionarContatoUseCase.Adicionar(adicionarContatoDto));

            // Assert
            Assert.Contains("Foi atingido o número máximo de caracteres (150)", result.Message);
        }

        [Theory]
        [InlineData("testedeemail")]
        [InlineData("email@@gmail.com")]
        [InlineData("teste@live")]        
        public void AdicionarContatoUseCase_Adicionar_ErroValidacaoEmailFormato(string email)
        {
            // Arrange
            var adicionarContatoDto = _builder.Default().WithEmail(email).Build();

            _contatoRepository.Setup(s => s.Adicionar(It.IsAny<Contato>()));

            // Act
            var result = Assert.Throws<Exception>(() => _adicionarContatoUseCase.Adicionar(adicionarContatoDto));

            // Assert
            Assert.Contains("E-mail inválido", result.Message);
        }
    }
}
