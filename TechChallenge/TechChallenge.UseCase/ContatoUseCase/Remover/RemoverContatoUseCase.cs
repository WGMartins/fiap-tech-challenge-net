﻿using TechChallenge.Domain.Interfaces;
using TechChallenge.UseCase.Interfaces;

namespace TechChallenge.UseCase.ContatoUseCase.Remover
{
    public class RemoverContatoUseCase : IRemoverContatoUseCase
    {
        private readonly IContatoRepository _contatoRepository;

        public RemoverContatoUseCase(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public void Remover(Guid id)
        {
            var contato = _contatoRepository.ObterPorId(id);

            if (contato is null)
            {
                throw new Exception("Contato não encontrado");
            }

            _contatoRepository.Remover(contato);
        }
    }
}
