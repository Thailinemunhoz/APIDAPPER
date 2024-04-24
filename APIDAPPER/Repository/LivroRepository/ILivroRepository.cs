using APIDAPPER.Model;

namespace APIDAPPER.Repository.LivroRepository
{
    public interface ILivroRepository
    {
        Task<IEnumerable<LivrosModel>> GetByAllLivro();

        Task<LivrosModel> GetByIdLivro(int Id);

        Task<LivrosModel> GetByLivroIdAutor(int Id);

        Task<IEnumerable<LivrosModel>> CreateLivro(LivrosModel livros);

        Task<IEnumerable<LivrosModel>> UpdateLivro(LivrosModel livros);

        Task<IEnumerable<LivrosModel>> DeleteLivro(int Id);
    }
}
