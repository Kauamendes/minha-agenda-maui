using CoreBusiness.Entidades;

namespace CasosDeUso.Interface
{
    public interface IAdicionarContatoUseCase
    {
        Task ExecutaAsync(Contato contato);
    }
}
