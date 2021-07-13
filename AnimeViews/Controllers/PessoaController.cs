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
            return Ok();
        }

        [HttpPost]
        public IActionResult post()
        {
            return Ok();
        }

        [HttpGet("{PessoaId}")]  
        public IActionResult getById(int PessoaId)
        {
            return Ok();
        }

        [HttpPut("{PessoaId}")]
        public IActionResult put(int PessoaId)
        {
            return Ok();
        }

        [HttpDelete("{PessoaId}")]
        public IActionResult delete(int PessoaId)
        {
            return Ok();
        }

        
    }
}