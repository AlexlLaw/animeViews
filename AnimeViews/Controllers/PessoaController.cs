using System.Threading.Tasks;
using AnimeViews.Data;
using AnimeViews.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeViews.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : Controller
    {    
        public IRepository _repo { get; }

        public PessoaController(IRepository repo)
        {
            _repo = repo;
        }
        
        [HttpGet]
        public async Task<IActionResult> get()
        {
            try {
                var result = await _repo.GetAllPessoasAsync(true);

                return Ok(result);
            } catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
        }

        
        [HttpGet("{PessoaId}")]  
        public async Task<IActionResult> getById(int PessoaId)
        {
            try {
                var result = await _repo.GetPessoaAsyncById(PessoaId, true);
                return Ok(result);
            } catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
        }

        [HttpPost]
       public async Task<IActionResult> post(Pessoa model)
       {
            try {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync()) {
                    return Created($"/api/pessoa/{model.PessoaId}", model);
                }

            } catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }

            return BadRequest();
       }

        [HttpPut("{PessoaId}")]
        public async Task<IActionResult> put(int PessoaId, Pessoa model)
        {
            try {
                var pessoa = await _repo.GetPessoaAsyncById(PessoaId, true);

                if (pessoa == null) {
                    return NotFound();
                }
                _repo.Update(model);

                if (await _repo.SaveChangesAsync()) {
                    return Ok();
                }

            } catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }

            return BadRequest();
        }

        [HttpDelete("{PessoaId}")]
        public async Task<IActionResult> delete(int PessoaId)
        {
            try {
               var Pessoa = await _repo.GetPessoaAsyncById(PessoaId, true);

                if (Pessoa == null) {
                return NotFound();
                }

                _repo.Delete(Pessoa);

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