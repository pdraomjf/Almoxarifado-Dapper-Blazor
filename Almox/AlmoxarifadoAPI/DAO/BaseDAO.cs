using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlmoxarifadoModel;
using Dapper;
using Microsoft.Data.Sqlite;

namespace AlmoxarifadoAPI.DAO
{
    public abstract class BaseDAO<T> where T : IModel
    {
        public abstract string NomeTabela { get; }
        public abstract Mapa[] Mapas { get; }
        private static string GetConnection() => 
        "Data Source=../BD/database.db";

        public async Task Inserir(T obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Id))
            {
                obj.Id = Guid.NewGuid().ToString();
            }

            using (var conexao = new SqliteConnection(GetConnection()))
            {
                conexao.Open();

                string sql = $"INSERT INTO {NomeTabela}" +
                                $" (id{GetInsertNomes()})" +
                                $" VALUES (@Id{GetInsertValores()})";

                await conexao.ExecuteAsync(sql, obj);
            }
        }

        public async Task Alterar(T obj)
        {
            using (var conexao = new SqliteConnection(GetConnection()))
            {
                conexao.Open();

                string sql = $"UPDATE {NomeTabela}" +
                $" SET {GetUpdate()}" +
                " WHERE id = @Id";

                await conexao.ExecuteAsync(sql, obj);
            }
        }

        public async Task Excluir(string id)
        {
            using (var conexao = new SqliteConnection(GetConnection()))
            {
                conexao.Open();

                string sql = $"DELETE FROM {NomeTabela} WHERE id = @Id";

                await conexao.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<IList<T>> BuscarTodos()
        {
            using (var conexao = new SqliteConnection(GetConnection()))
            {
                conexao.Open();

                string sql = $"SELECT * FROM {NomeTabela}";

                var objetos = await conexao.QueryAsync<T>(sql);

                return objetos.ToList();
            }
        }

        public async Task<T> BuscarId(string id)
        {
            using (var conexao = new SqliteConnection(GetConnection()))
            {
                conexao.Open();

                string sql = $"SELECT * FROM {NomeTabela} WHERE id = @Id";

                var obj = await conexao.QuerySingleOrDefaultAsync<T>(sql, new { Id = id });

                if (obj == null)
                {
                    throw new InvalidOperationException($"Nenhum objeto encontrado com o ID {id}");
                }

                return obj;
            }
        }

        public string GetInsertNomes()
        {
            var sb = new StringBuilder();

            foreach (var mapa in Mapas)
                sb.Append($", {mapa.Campo}");

            return sb.ToString();
        }

        public string GetInsertValores()
        {
            var sb = new StringBuilder();

            foreach (var mapa in Mapas)
                sb.Append($", @{mapa.Propriedade}");

            return sb.ToString();
        }

        public string GetUpdate()
        {
            var sb = new StringBuilder();

            foreach (var mapa in Mapas)
                sb.Append($", {mapa.Campo}=@{mapa.Propriedade}");

            return sb.ToString().Substring(1);
        }
    }
}