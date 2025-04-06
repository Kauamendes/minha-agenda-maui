using CoreBusiness.Entidades;

namespace CasosDeUso.Interface
{
    public interface IVisualizarObservacoesUseCase
    {
        Task<List<Observacao>> ExecutaList();
    }
}
