using CasosDeUso.PluginsInterfaces;
using CoreBusiness.Entidades;
using SQLite;

namespace MinhaAgenda.Plugins.SqlLite
{
    public class RepositorioObservacaoSqlLite : IRepositorioDeObservacoes
    {
        private SQLiteAsyncConnection _database;

        public Task AdicionarObservacao(Observacao observacao)
        {
            return Task.FromResult(AdicionarObservacaoAsync(observacao));
        }

        public async Task AdicionarObservacaoAsync(Observacao observacao)
        {
            await _database.InsertAsync(observacao);
        }

        public Task<List<Observacao>> BuscarObservacoes()
        {
            return BuscarTodosObservacoesAsync();
        }

        public async Task<List<Observacao>> BuscarTodosObservacoesAsync()
        {
            return await _database.Table<Observacao>().ToListAsync();
        }
    }
}
