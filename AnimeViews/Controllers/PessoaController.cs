using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeViews.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : Controller
    {    
        public PessoaController()
        {
            
        }

        [HttpGet]
        public IActionResult get()
        {
            try {
                return Ok();
            } catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
        }

        [HttpPost]
        public IActionResult post()
        {
            try {
                return Ok();
            } catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
        }

        [HttpGet("{PessoaId}")]  
        public IActionResult getById(int PessoaId)
        {
            try {
                return Ok();
            } catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
        }

        [HttpPut("{PessoaId}")]
        public IActionResult put(int PessoaId)
        {
            try {
                return Ok();
            } catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
        }

        [HttpDelete("{PessoaId}")]
        public IActionResult delete(int PessoaId)
        {
            try {
                return Ok();
            } catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
        }

        
    }
}