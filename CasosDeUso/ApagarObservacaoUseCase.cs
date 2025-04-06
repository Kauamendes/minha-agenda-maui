using CasosDeUso.Interface;
using CasosDeUso.PluginsInterfaces;
using CoreBusiness.Entidades;

namespace CasosDeUso
{
    public class ApagarObservacaoUseCase : IApagarObservacaoUseCase
    {
        private readonly IRepositorioDeObservacoes _repositorioDeObservacoes;

        public ApagarObservacaoUseCase(IRepositorioDeObservacoes repositorioDeObservacoes)
        {
            _repositorioDeObservacoes = repositorioDeObservacoes;
        }

        public async Task ExecutaAsync(Observacao observacao)
        {
            await _repositorioDeObservacoes.ExcluirObservacao(observacao);
        }
    }
}
