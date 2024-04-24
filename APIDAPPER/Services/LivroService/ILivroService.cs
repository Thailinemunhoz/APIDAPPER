using APIDAPPER.Model;

namespace APIDAPPER.Services.LivroService
{
    public interface ILivroService
    {
        Task<IEnumerable<LivrosModel>> CreateLivro(LivrosModel livros);

        Task<IEnumerable<LivrosModel>> DeleteLivro(int Id);

        Task<IEnumerable<LivrosModel>> GetByAllLivro();

        Task<LivrosModel> GetByIdLivro(int Id);

        Task<LivrosModel> GetByLivroIdAutor(int Id);

        Task<IEnumerable<LivrosModel>> UpdateLivro(LivrosModel livros);
    }
}
