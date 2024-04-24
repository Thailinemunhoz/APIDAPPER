using APIDAPPER.Model;
using Dapper;
using System.Data.SqlClient;

namespace APIDAPPER.Repository.AutorRepository
{
    public class AutorRepository : IAutorRepository
    {
        private readonly string getConnection;

        public AutorRepository(IConfiguration configuration)
        {
            getConnection = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<AutorModel>> CreateAutor(AutorModel autor)
        {
            using (var con = new SqlConnection(getConnection))
            {
               var sql = "INSERT INTO Autor (NomeAutor, ArquivoAutor) VALUES (@NomeAutor, '1')";
               await con.ExecuteAsync(sql, autor);
               return await con.QueryAsync<AutorModel>("select * from autor where ArquivoAutor = 1");
            }
        }

        public async Task<IEnumerable<AutorModel>> UpdateAutor(AutorModel autor)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var isArchived = await con.ExecuteScalarAsync<int?>("SELECT ArquivoAutor FROM Autor WHERE IdAutor = @IdAutor", new { autor.IdAutor })
                                 ?? throw new Exception("Erro: Autor arquivado");

                if (isArchived == 0)
                {
                    throw new Exception("Erro: Autor arquivado. Não pode ser atualizado.");
                }

                // Atualizar os campos do autor
                var updateSql = @"UPDATE Autor 
                          SET NomeAutor = @NomeAutor 
                          WHERE IdAutor = @IdAutor";
                await con.ExecuteAsync(updateSql, autor);

                // Retornar todos os autores
                return await con.QueryAsync<AutorModel>("SELECT * FROM Autor WHERE ArquivoAutor = 1");
            }
        }

        public async Task<IEnumerable<AutorModel>> GetByAllAutor()

        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "SELECT * FROM Autor WHERE ArquivoAutor = 1";
                await con.ExecuteAsync(sql);
                return await con.QueryAsync<AutorModel>(sql);            
            }
        }

        public async Task<AutorModel> GetByIdAutor(int Id)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var isArchived = await con.ExecuteScalarAsync<int?>("SELECT ArquivoAutor FROM Autor WHERE IdAutor = @IdAutor", new { IdAutor = Id });

                if (isArchived == 0)
                {
                    throw new Exception("Erro: Autor arquivado");
                }

                var sql = "SELECT * FROM Autor WHERE IdAutor = @IdAutor AND ArquivoAutor = 1";

                return await con.QueryFirstOrDefaultAsync<AutorModel>(sql, new { IdAutor = Id });
            }
        }

        public async Task<IEnumerable<AutorModel>> ToFileAutor(int Id)
        {
            using (var con = new SqlConnection(getConnection))
            {
                // Verificar se o autor está arquivado antes de atualizá-lo
                var isArchived = await con.ExecuteScalarAsync<int?>("SELECT ArquivoAutor FROM Autor WHERE IdAutor = @IdAutor", new { IdAutor = Id });

                if (isArchived == null || isArchived != 1)
                {
                    throw new Exception("Erro: Autor arquivado.");
                }

                // Atualizar o campo ArquivoAutor para 0 para arquivar o autor
                var updateSql = "UPDATE Autor SET ArquivoAutor = 0 WHERE IdAutor = @IdAutor";
                await con.ExecuteAsync(updateSql, new { IdAutor = Id });

                // Retornar os dados atualizados
                return await con.QueryAsync<AutorModel>("SELECT * FROM Autor WHERE ArquivoAutor != 1", new { IdAutor = Id });
            }
        }
    }
}
