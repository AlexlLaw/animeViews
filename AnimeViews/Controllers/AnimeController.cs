
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeViews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeController : Controller
    {
        public AnimeController()
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

        [HttpGet("{AnimeId}")]  
        public IActionResult getById(int AnimeId)
        {
            try {
                return Ok();
            } catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
        }

        [HttpPut("{AnimeId}")]
        public IActionResult put(int AnimeId)
        {
            try {
                return Ok();
            } catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
        }

        [HttpDelete("{AnimeId}")]
        public IActionResult delete(int AnimeId)
        {
            try {
                return Ok();
            } catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
        }
    }
}