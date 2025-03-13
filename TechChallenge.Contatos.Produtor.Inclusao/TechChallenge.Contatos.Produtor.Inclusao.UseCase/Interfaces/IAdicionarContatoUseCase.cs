using TechChallenge.UseCase.ContatoUseCase.Adicionar;

namespace UseCase.Interfaces
{
    public interface IAdicionarContatoUseCase
    {
        ContatoAdicionadoDto Adicionar(AdicionarContatoDto input);
    }
}
