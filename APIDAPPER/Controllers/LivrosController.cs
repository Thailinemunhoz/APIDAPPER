using APIDAPPER.Model;
using APIDAPPER.Services.LivroService;
using Microsoft.AspNetCore.Mvc;

namespace APIDAPPER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public LivrosController(ILivroService livrosService)
        {
            _livroService = livrosService;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<LivrosModel>>> CreateLivro(LivrosModel livros)
        {
            IEnumerable<LivrosModel> livro = await _livroService.CreateLivro(livros);
            return Ok(livro);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<IEnumerable<LivrosModel>>> DeleteLivro(int id)
        {
            IEnumerable<LivrosModel> livro = await _livroService.DeleteLivro(id);
            return Ok(livro);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivrosModel>>> GetByAllLivro()
        {
            IEnumerable<LivrosModel> livros = await _livroService.GetByAllLivro();
            return Ok(livros);
        }

        [HttpGet("id")] 
        public async Task<ActionResult<LivrosModel>> GetByIdLivro(int Id)
        {
            var response = await _livroService.GetByIdLivro(Id);
            return Ok(response);
        }

        [HttpGet("idAutor")]
        public async Task<ActionResult<LivrosModel>> GetByLivroIdAutor(int Id)
        {
            var response = await _livroService.GetByLivroIdAutor(Id);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<LivrosModel>>> UpdateLivro(LivrosModel livros)
        {
            IEnumerable<LivrosModel> livro = await _livroService.UpdateLivro(livros);
            return Ok(livro);
        }
    }
}
