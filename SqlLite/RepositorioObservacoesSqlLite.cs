using CasosDeUso.PluginsInterfaces;
using CoreBusiness.Entidades;
using SQLite;

namespace MinhaAgenda.Plugins.SqlLite
{
    public class RepositorioObservacaoSqlLite : IRepositorioDeObservacoes
    {
        private SQLiteAsyncConnection _database;
        public RepositorioObservacaoSqlLite()
        {
            _database = new SQLiteAsyncConnection(Constantes._databasepath);
            _database.CreateTableAsync<Observacao>().Wait();
        }

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
            Console.WriteLine("[LOG] Iniciando busca de observações...");

            return await _database.Table<Observacao>().ToListAsync();
        }

        public Task<Observacao> BuscarObservacaoPorId(Guid id)
        {
            return BuscarObservacaoPorIdAsync(id);
        }

        public async Task<Observacao> BuscarObservacaoPorIdAsync(Guid id)
        {
            return await _database.Table<Observacao>().Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public Task ExcluirObservacao(Observacao observacao)
        {
            return Task.FromResult(ExcluirObservacaoAsync(observacao));
        }

        public async Task ExcluirObservacaoAsync(Observacao observacao)
        {
            var observacaoExcluir = await BuscarObservacaoPorId(observacao.Id);
            if (observacaoExcluir != null && observacao.Id.Equals(observacaoExcluir.Id))
                await _database.DeleteAsync(observacaoExcluir);
        }
    }
}
