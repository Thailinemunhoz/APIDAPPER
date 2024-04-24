using APIDAPPER.Model;
namespace APIDAPPER.Repository.AutorRepository
{
    public interface IAutorRepository
    {
        Task<IEnumerable<AutorModel>> GetByAllAutor();

        Task<AutorModel> GetByIdAutor(int Id);

        Task<IEnumerable<AutorModel>> CreateAutor (AutorModel autor);

        Task<IEnumerable<AutorModel>> UpdateAutor (AutorModel autor);

        Task<IEnumerable<AutorModel>> ToFileAutor(int Id);
        
    }
}
