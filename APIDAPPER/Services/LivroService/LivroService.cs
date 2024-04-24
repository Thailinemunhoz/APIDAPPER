using APIDAPPER.Model;
using APIDAPPER.Repository.LivroRepository;

namespace APIDAPPER.Services.LivroService
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;
        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<IEnumerable<LivrosModel>> CreateLivro(LivrosModel livros)
        {
            IEnumerable<LivrosModel> livro = await _livroRepository.CreateLivro(livros);
            if(livro == null)
            {
                throw new Exception("Registro não encontrado");
            }
            return livro;
        }

        public async Task<IEnumerable<LivrosModel>> DeleteLivro(int Id)
        {
            IEnumerable<LivrosModel> livros = await _livroRepository.DeleteLivro(Id);
            if(livros == null)
            {
                throw new Exception("Registro não encontrado");
            }
            return livros;
        }

        public async Task<IEnumerable<LivrosModel>> GetByAllLivro()
        {
            IEnumerable<LivrosModel> livros = await _livroRepository.GetByAllLivro();
            return livros;  
        }

        public async Task<LivrosModel> GetByIdLivro(int Id)
        {
            var response = await _livroRepository.GetByIdLivro(Id);
            if(response == null)
            {
                throw new Exception("Registro não encontrado");
            }
            return response;
        }

        public async Task<LivrosModel> GetByLivroIdAutor(int Id)
        {
            var response = await _livroRepository.GetByLivroIdAutor(Id);
            if (response == null)
            {
                throw new Exception("Registro não encontrado");
            }
            return response;
        }

        public async Task<IEnumerable<LivrosModel>> UpdateLivro(LivrosModel livros)
        {
            IEnumerable<LivrosModel> livro = await _livroRepository.UpdateLivro(livros);
            if (livro == null)
            {
                throw new Exception("Registro não encontrado");
            }
            return livro;
        }
    }
}
