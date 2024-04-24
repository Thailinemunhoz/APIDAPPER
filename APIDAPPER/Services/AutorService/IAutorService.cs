using APIDAPPER.Model;

namespace APIDAPPER.Services.AutorService
{
    public interface IAutorService
    {
        Task<IEnumerable<AutorModel>> GetByAllAutor();

        Task<AutorModel> GetByIdAutor(int Id);

        Task<IEnumerable<AutorModel>> CreateAutor(AutorModel autor);

        Task<IEnumerable<AutorModel>> UpdateAutor(AutorModel autor);

        Task<IEnumerable<AutorModel>> ToFileAutor(int Id);
    }
}
