using CasosDeUso.Interface;
using CasosDeUso.PluginsInterfaces;
using CoreBusiness.Entidades;

namespace CasosDeUso
{
    public class VisualizarObservacoesUseCase : IVisualizarObservacoesUseCase
    {

        private readonly IRepositorioDeObservacoes _repositorioDeObservacoes;

        public VisualizarObservacoesUseCase(IRepositorioDeObservacoes repositorioDeObservacoes)
        {
            _repositorioDeObservacoes = repositorioDeObservacoes;
        }

        public Task<List<Observacao>> ExecutaList()
        {
            Console.WriteLine(_repositorioDeObservacoes);

            Console.WriteLine("[LOG] Iniciando busca de observações...");

            return _repositorioDeObservacoes.BuscarObservacoes();
        }
    }
}