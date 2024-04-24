using APIDAPPER.Model;
using APIDAPPER.Services.AutorService;
using Microsoft.AspNetCore.Mvc;

namespace APIDAPPER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;
        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpGet]
        public async Task <ActionResult<IEnumerable<AutorModel>>> GetByAllAutor()
        {
            IEnumerable<AutorModel> autores = await _autorService.GetByAllAutor();
            return Ok(autores);
        }

        [HttpPost]
        public async Task <ActionResult<IEnumerable<AutorModel>>> CreateAutor(AutorModel autor)
        {
            IEnumerable<AutorModel> autores = await _autorService.CreateAutor(autor);
            return Ok(autores);
        }

        [HttpDelete("Id")]
        public async Task <ActionResult<IEnumerable<AutorModel>>> ToFileAutor(int id)
        {
            IEnumerable<AutorModel> respose = await _autorService.ToFileAutor(id);
            return Ok(respose); 
        }

        [HttpGet("id")]
        public async Task <ActionResult<AutorModel>> GetByIdAutor (int Id)
        {
            var autor = await _autorService.GetByIdAutor(Id);
            return Ok(autor);
        }

        [HttpPut]
        public async Task <ActionResult<IEnumerable<AutorModel>>> UpdateAutor(AutorModel autor)
        {
            IEnumerable<AutorModel> autores = await _autorService.UpdateAutor(autor);
            return Ok(autores);
        }

    }
}
