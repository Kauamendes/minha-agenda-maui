using CasosDeUso.Interface;
using CasosDeUso.PluginsInterfaces;
using CoreBusiness.Entidades;

namespace CasosDeUso
{
    public class ApagarContatosUseCase : IApagarContatoUseCase
    {
        private readonly IRepositorioDeContatos _contatoRepository;

        public ApagarContatosUseCase(IRepositorioDeContatos repositorioDeContatos)
        {
            _contatoRepository = repositorioDeContatos;
        }

        public async Task ExecutaAsync(Contato contato)
        {
            await _contatoRepository.ExcluirContatoAsync(contato);
        }
    }
}
