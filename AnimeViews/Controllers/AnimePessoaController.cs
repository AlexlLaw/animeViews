using System.Threading.Tasks;
using AnimeViews.Data;
using AnimeViews.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace AnimeViews.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AnimePessoaController : Controller
    {
         public IRepository _repo { get; }
         
        public AnimePessoaController(IRepository repo)
        {
             _repo = repo;
        }

         [HttpPost]
        public async Task<IActionResult> post(AnimePessoa model)
        {
            try {

                 var anime = await _repo.GetAnimeAsyncById(model.AnimeId, false);

                 var pessoa = await _repo.GetPessoaAsyncById(model.PessoaId, false);

                if (anime != null && pessoa != null) {
                     _repo.Add(model);
                }
                 
                if (await _repo.SaveChangesAsync()) {
                     return Ok();
                }
                
            } catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
            
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> delete(AnimePessoa AnimePessoa)
        {
            try {
                var hasAnimePessoa = await _repo.GetAnimePessoaAsyncById(AnimePessoa);

                if (hasAnimePessoa == null) {
                  return NotFound();
                }

                _repo.Delete(AnimePessoa);

                if (await _repo.SaveChangesAsync()) {
                    return Ok();
                }
            } catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
             return BadRequest();
        }
    }
}