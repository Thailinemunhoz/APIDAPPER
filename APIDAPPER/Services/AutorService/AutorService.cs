using APIDAPPER.Model;
using APIDAPPER.Repository.AutorRepository;

namespace APIDAPPER.Services.AutorService
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _autorRepository;
        public AutorService(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public async Task<IEnumerable<AutorModel>> CreateAutor(AutorModel autor)
        {
            var response = await _autorRepository.CreateAutor(autor) 
                ?? throw new Exception("Nenhum autor encontrado");

            return response;
        }

        public async Task<IEnumerable<AutorModel>> ToFileAutor(int Id)
        {
            //var verificaId = await _autorRepository.GetByIdAutor(Id) ?? throw new Exception("Autor não encontrado");

            IEnumerable<AutorModel> response = await _autorRepository.ToFileAutor(Id);

            if (response == null)
            {
                throw new Exception("Registro não encontrado");
            }
            return response;
        }

        public async Task<IEnumerable<AutorModel>> GetByAllAutor()
        {

            IEnumerable<AutorModel> autores = await _autorRepository.GetByAllAutor();
            if (autores == null)
            {
                throw new Exception("Nenhum registro encontrado");
            }
            return autores;
        }

        public async Task<AutorModel> GetByIdAutor(int Id)
        {
            AutorModel autor = await _autorRepository.GetByIdAutor(Id);
            if(autor == null)
            {
                throw new Exception("Registro não encontrado");
            }
            return autor;
        }

        public async Task<IEnumerable<AutorModel>> UpdateAutor(AutorModel autor)
        {
            IEnumerable<AutorModel> response = await _autorRepository.UpdateAutor(autor);
            return response;
        }
    }
}
