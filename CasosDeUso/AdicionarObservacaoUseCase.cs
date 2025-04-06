using CasosDeUso.Interface;
using CasosDeUso.PluginsInterfaces;
using CoreBusiness.Entidades;

namespace CasosDeUso
{

    public class AdicionarObservacaoUseCase : IAdicionarObservacoesUseCase
    {
        private readonly IRepositorioDeObservacoes _observacaoRepository;

        public AdicionarObservacaoUseCase(IRepositorioDeObservacoes observacoesRepository)
        {
            _observacaoRepository = observacoesRepository;
        }

        public async Task ExecutaAsync(Observacao observacao)
        {
            await _observacaoRepository.AdicionarObservacao(observacao);
        }
    }
}
