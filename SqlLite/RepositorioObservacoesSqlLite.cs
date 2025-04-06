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
    }
}
