using FluentValidation;
using Moq;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Domain.RegionalAggregate;
using TechChallenge.UseCase.ContatoUseCase.Alterar;
using TechChallenge.UseCase.Interfaces;

namespace TechChallenge.UnitTest.UseCase.ContatoUseCase.Alterar
{
    public class AlterarContatoUseCaseTest
    {
        private readonly AlterarContatoDtoBuilder _builder;        
        private readonly Mock<IContatoRepository> _contatoRepository;
        private readonly IValidator<AlterarContatoDto> _validator;
        private readonly IAlterarContatoUseCase _alterarContatoUseCase;

        public AlterarContatoUseCaseTest()
        {
            _validator = new AlterarContatoValidator();
            _contatoRepository = new Mock<IContatoRepository>();
            _builder = new AlterarContatoDtoBuilder();
            _alterarContatoUseCase = new AlterarContatoUseCase(_contatoRepository.Object, _validator);
        }

        [Fact]
        public void AlterarContatoUseCase_Alterar_Sucesso()
        {
            // Arrange
            var alterarContatoDto = _builder.Default().Build();            

            _contatoRepository.Setup(s => s.Alterar(It.IsAny<Contato>()));
            _contatoRepository.Setup(s => s.ObterPorId(It.IsAny<Guid>()))
                .Returns(new Contato(alterarContatoDto.Id, 
                    alterarContatoDto.Nome, 
                    alterarContatoDto.Telefone, 
                    alterarContatoDto.Email, 
                    alterarContatoDto.RegionalId));

            // Act
            _alterarContatoUseCase.Alterar(alterarContatoDto);

            // Assert            
            _contatoRepository.Verify(x => x.Alterar(It.IsAny<Contato>()), Times.Once());
            _contatoRepository.Verify(x => x.ObterPorId(It.IsAny<Guid>()), Times.Once());

        }
        
        [Theory]
        [InlineData("")]
        [InlineData("     ")]
        public void AlterarContatoUseCase_Alterar_ErroValidacaoNome(string nome)
        {
            // Arrange
            var alterarContatoDto = _builder.Default().WithName(nome).Build();

            _contatoRepository.Setup(s => s.Alterar(It.IsAny<Contato>()));
            _contatoRepository.Setup(s => s.ObterPorId(It.IsAny<Guid>()))
                .Returns(new Contato(alterarContatoDto.Id,
                    alterarContatoDto.Nome,
                    alterarContatoDto.Telefone,
                    alterarContatoDto.Email,
                    alterarContatoDto.RegionalId));

            // Act
            var result = Assert.Throws<Exception>(() => _alterarContatoUseCase.Alterar(alterarContatoDto));

            // Assert
            Assert.Contains("Nome não pode ser nulo ou vazio", result.Message);
        }

        [Theory]        
        [InlineData("")]
        [InlineData("     ")]
        public void AlterarContatoUseCase_Alterar_ErroValidacaoTelefoneNuloVazio(string telefone)
        {
            // Arrange
            var alterarContatoDto = _builder.Default().WithTelefone(telefone).Build();

            _contatoRepository.Setup(s => s.Alterar(It.IsAny<Contato>()));
            _contatoRepository.Setup(s => s.ObterPorId(It.IsAny<Guid>()))
                .Returns(new Contato(alterarContatoDto.Id,
                    alterarContatoDto.Nome,
                    alterarContatoDto.Telefone,
                    alterarContatoDto.Email,
                    alterarContatoDto.RegionalId));

            // Act
            var result = Assert.Throws<Exception>(() => _alterarContatoUseCase.Alterar(alterarContatoDto));

            // Assert
            Assert.Contains("Telefone não pode ser nulo ou vazio", result.Message);

        }

        [Theory]
        [InlineData("1234598-8546789")]        
        public void AlterarContatoUseCase_Alterar_ErroValidacaoTelefoneTamanho(string telefone)
        {
            // Arrange
            var alterarContatoDto = _builder.Default().WithTelefone(telefone).Build();

            _contatoRepository.Setup(s => s.Alterar(It.IsAny<Contato>()));
            _contatoRepository.Setup(s => s.ObterPorId(It.IsAny<Guid>()))
                .Returns(new Contato(alterarContatoDto.Id,
                    alterarContatoDto.Nome,
                    alterarContatoDto.Telefone,
                    alterarContatoDto.Email,
                    alterarContatoDto.RegionalId));

            // Act
            var result = Assert.Throws<Exception>(() => _alterarContatoUseCase.Alterar(alterarContatoDto));

            // Assert
            Assert.Contains("Foi atingido o número máximo de caracteres (10)", result.Message);
        }

        [Theory]        
        [InlineData("08645-6441")]
        [InlineData("34887037")]
        [InlineData("999999999")]        
        public void AlterarContatoUseCase_Alterar_ErroValidacaoTelefoneFormato(string telefone)
        {
            // Arrange
            var alterarContatoDto = _builder.Default().WithTelefone(telefone).Build();

            _contatoRepository.Setup(s => s.Alterar(It.IsAny<Contato>()));
            _contatoRepository.Setup(s => s.ObterPorId(It.IsAny<Guid>()))
                .Returns(new Contato(alterarContatoDto.Id,
                    alterarContatoDto.Nome,
                    alterarContatoDto.Telefone,
                    alterarContatoDto.Email,
                    alterarContatoDto.RegionalId));

            // Act
            var result = Assert.Throws<Exception>(() => _alterarContatoUseCase.Alterar(alterarContatoDto));

            // Assert
            Assert.Contains("Telefone inválido", result.Message);
        }

        [Theory]        
        [InlineData("")]
        [InlineData("     ")]        
        public void AlterarContatoUseCase_Alterar_ErroValidacaoEmailNuloVazio(string email)
        {
            // Arrange
            var alterarContatoDto = _builder.Default().WithEmail(email).Build();

            _contatoRepository.Setup(s => s.Alterar(It.IsAny<Contato>()));
            _contatoRepository.Setup(s => s.ObterPorId(It.IsAny<Guid>()))
                .Returns(new Contato(alterarContatoDto.Id,
                    alterarContatoDto.Nome,
                    alterarContatoDto.Telefone,
                    alterarContatoDto.Email,
                    alterarContatoDto.RegionalId));

            // Act
            var result = Assert.Throws<Exception>(() => _alterarContatoUseCase.Alterar(alterarContatoDto));

            // Assert
            Assert.Contains("Email não pode ser nulo ou vazio", result.Message);
        }

        [Theory]        
        [InlineData("testetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetestetesteteste" +
            "@testetestetestetestetestetestetestetestetestetestetesteteste")]
        public void AlterarContatoUseCase_Alterar_ErroValidacaoEmailTamanho(string email)
        {
            // Arrange
            var alterarContatoDto = _builder.Default().WithEmail(email).Build();

            _contatoRepository.Setup(s => s.Alterar(It.IsAny<Contato>()));
            _contatoRepository.Setup(s => s.ObterPorId(It.IsAny<Guid>()))
                .Returns(new Contato(alterarContatoDto.Id,
                    alterarContatoDto.Nome,
                    alterarContatoDto.Telefone,
                    alterarContatoDto.Email,
                    alterarContatoDto.RegionalId));

            // Act
            var result = Assert.Throws<Exception>(() => _alterarContatoUseCase.Alterar(alterarContatoDto));

            // Assert
            Assert.Contains("Foi atingido o número máximo de caracteres (150)", result.Message);
        }

        [Theory]
        [InlineData("testedeemail")]
        [InlineData("email@@gmail.com")]
        [InlineData("teste@live")]        
        public void AlterarContatoUseCase_Alterar_ErroValidacaoEmailFormato(string email)
        {
            // Arrange
            var alterarContatoDto = _builder.Default().WithEmail(email).Build();

            _contatoRepository.Setup(s => s.Alterar(It.IsAny<Contato>()));
            _contatoRepository.Setup(s => s.ObterPorId(It.IsAny<Guid>()))
                .Returns(new Contato(alterarContatoDto.Id,
                    alterarContatoDto.Nome,
                    alterarContatoDto.Telefone,
                    alterarContatoDto.Email,
                    alterarContatoDto.RegionalId));

            // Act
            var result = Assert.Throws<Exception>(() => _alterarContatoUseCase.Alterar(alterarContatoDto));

            // Assert
            Assert.Contains("E-mail inválido", result.Message);
        }
    }
}
