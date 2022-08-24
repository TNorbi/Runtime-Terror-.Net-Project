using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWebAPI.Services.Genres;

namespace MoviesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        public IGenreService _service { get; set; }

        public GenreController(IGenreService service)
        {
            _service = service;
        }

        [HttpGet,Route("get-all-genres")]
        public async Task<IActionResult> GetAllGenres()
        {
            return Ok();
        }
    }
}
