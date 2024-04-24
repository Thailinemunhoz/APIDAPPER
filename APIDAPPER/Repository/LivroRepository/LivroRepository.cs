using APIDAPPER.Model;
using Dapper;
using System.Data.SqlClient;

namespace APIDAPPER.Repository.LivroRepository
{
    public class LivroRepository : ILivroRepository
    {
        private readonly string getConnection;

        public LivroRepository(IConfiguration configuration)
        {
            getConnection = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<LivrosModel>> CreateLivro(LivrosModel livros)
        {
            using(var con = new SqlConnection(getConnection))
            {
                var sql = "insert into Livros (NomeLivro, DataLancamento, IdAutor) values (@NomeLivro, @DataLancamento, @IdAutor) ";
                await con.ExecuteAsync(sql, livros);
                return await con.QueryAsync<LivrosModel>(sql = "select * from livros");
            }
        }

        public async Task<IEnumerable<LivrosModel>> DeleteLivro(int Id)
        {
            using(var con = new SqlConnection (getConnection))
            {
                var sql = "delete livros where IdLivro = @IdLivro";
                await con.ExecuteAsync(sql, new {IdLivro = Id });
                return await con.QueryAsync<LivrosModel>(sql = "select * from livros");
            }
        }

        public async Task<IEnumerable<LivrosModel>> GetByAllLivro()
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "select * from livros";
                await con.ExecuteAsync(sql);
                return await con.QueryAsync<LivrosModel>(sql);
            }
        }

        public async Task<LivrosModel> GetByIdLivro(int Id)
        {
            using (var con = new SqlConnection (getConnection))
            {
                var sql = "select * from livros where IdLivro = @IdLivro";
                return await con.QueryFirstOrDefaultAsync<LivrosModel>(sql, new { IdLivro = Id });   
            }
        }

        public async Task<LivrosModel> GetByLivroIdAutor(int Id)
        {
            using( var con = new SqlConnection(getConnection))
            {
                var sql = @"
                    SELECT L.NomeLivro, A.NomeAutor 
                    FROM livros L
                    JOIN Autor A ON A.IdAutor = L.IdAutor
                    WHERE L.IdAutor = @IdAutor
                ";
                return await con.QueryFirstOrDefaultAsync<LivrosModel>(sql, new {IdAutor = Id});
            }
        }

        public async Task<IEnumerable<LivrosModel>> UpdateLivro(LivrosModel livros)
        {
            using(var con = new SqlConnection(getConnection))
            {
                var sql = @"update Livros 
                            set NomeLivro = @NomeLivro, DataLancamento = @DataLancamento, IdAutor = @IdAutor
                            where IdLivro = @IdLivro
                          ";
                await con.ExecuteAsync(sql, livros);
                return await con.QueryAsync<LivrosModel>(sql = "select * from livros");
            }
        }
    }
}
