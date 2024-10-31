﻿using FluentValidation;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Domain.RegionalAggregate;
using TechChallenge.UseCase.Interfaces;

namespace TechChallenge.UseCase.ContatoUseCase.Adicionar
{
    public class AdicionarContatoUseCase : IAdicionarContatoUseCase
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IValidator<AdicionarContatoDto> _validator;

        public AdicionarContatoUseCase(IContatoRepository contatoRepository, IValidator<AdicionarContatoDto> validator)
        {
            _contatoRepository = contatoRepository;
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

            _contatoRepository.Adicionar(contato);

            return new ContatoAdicionadoDto
            {
                Id = contato.Id,
            };
        }
    }
}
