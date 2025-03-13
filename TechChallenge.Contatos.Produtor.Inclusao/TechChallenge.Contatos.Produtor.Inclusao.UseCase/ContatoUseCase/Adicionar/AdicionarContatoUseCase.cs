using FluentValidation;
using TechChallenge.Domain.RegionalAggregate;
using UseCase.Interfaces;

namespace TechChallenge.UseCase.ContatoUseCase.Adicionar
{
    public class AdicionarContatoUseCase : IAdicionarContatoUseCase
    {
        private readonly IValidator<AdicionarContatoDto> _validator;

        public AdicionarContatoUseCase(IValidator<AdicionarContatoDto> validator)
        {
            _validator = validator;
        }

        public ContatoAdicionadoDto Adicionar(AdicionarContatoDto adicionarContatoDto)
        {
            var validacao = _validator.Validate(adicionarContatoDto);
            if (!validacao.IsValid)
            {
                string mensagemValidacao = string.Empty;
                foreach (var item in validacao.Errors)
                {
                    mensagemValidacao = string.Concat(mensagemValidacao, item.ErrorMessage, ", ");
                }

                throw new Exception(mensagemValidacao.Remove(mensagemValidacao.Length - 2));
            }

            var contato = Contato.Criar(adicionarContatoDto.Nome, adicionarContatoDto.Telefone, adicionarContatoDto.Email, adicionarContatoDto.RegionalId);

            //PUBLICAR MENSAGEM NO RABBIT MQ
            //_contatoRepository.Adicionar(contato);

            return new ContatoAdicionadoDto
            {
                Id = contato.Id,
            };
        }
    }
}
