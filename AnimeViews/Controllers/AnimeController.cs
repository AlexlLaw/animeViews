
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
            return Ok();
        }

        [HttpPost]
        public IActionResult post()
        {
            return Ok();
        }

        [HttpGet("{AnimeId}")]  
        public IActionResult getById(int AnimeId)
        {
            return Ok();
        }

        [HttpPut("{AnimeId}")]
        public IActionResult put(int AnimeId)
        {
            return Ok();
        }

        [HttpDelete("{AnimeId}")]
        public IActionResult delete(int AnimeId)
        {
            return Ok();
        }
    }
}