using CoreBusiness.Entidades;

namespace CasosDeUso.Interface
{
    public interface IAdicionarObservacoesUseCase
    {
        Task ExecutaAsync(Observacao observacao);
    }
}
