﻿namespace TechChallenge.UseCase.RegionalUseCase.Listar
{
    public class ContatosPorRegionalDto
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Telefone { get; set; }
        public required string Email { get; set; }
    }
}
