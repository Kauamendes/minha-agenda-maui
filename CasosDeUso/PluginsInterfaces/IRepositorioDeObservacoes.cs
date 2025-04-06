using CoreBusiness.Entidades;

namespace CasosDeUso.PluginsInterfaces
{
    public interface IRepositorioDeObservacoes
    {
        Task AdicionarObservacao(Observacao observacao);
        Task<List<Observacao>> BuscarObservacoes();
    }
}
