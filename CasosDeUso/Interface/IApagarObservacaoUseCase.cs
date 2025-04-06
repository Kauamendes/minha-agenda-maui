using CoreBusiness.Entidades;

namespace CasosDeUso.Interface
{
    public interface IApagarObservacaoUseCase
    {
        Task ExecutaAsync(Observacao observacao);
    }
}
