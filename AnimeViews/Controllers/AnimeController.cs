
using System.Threading.Tasks;
using AnimeViews.Data;
using AnimeViews.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeViews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeController : Controller
    {
        public IRepository _repo { get; }

        public AnimeController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> get()
        {
            try {
                var result = await _repo.GetAllAnimesAsync(true);

                return Ok(result);
            } catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
        }

        [HttpGet("{AnimeId}")]  
        public async Task<IActionResult> getById(int AnimeId)
        {
            try {
                var result = await _repo.GetAnimeAsyncById(AnimeId, true);

                return Ok(result);
            } catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Anime model)
        {
            try {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync()) {
                    return Created($"/api/anime/{model.AnimeId}", model);
                }
                
            } catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
            
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> put(Anime model)
        {
            try {
                var anime = await _repo.GetAnimeAsyncById(model.AnimeId, true);

                if (anime == null) {
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

        [HttpDelete("{AnimeId}")]
        public async Task<IActionResult> delete(int AnimeId)
        {
            try {
                var anime = await _repo.GetAnimeAsyncById(AnimeId, true);

                if (anime == null) {
                return NotFound();
                }

                _repo.Delete(anime);

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