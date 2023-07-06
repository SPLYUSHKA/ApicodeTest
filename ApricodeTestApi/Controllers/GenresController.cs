using ApricodeTestApi.Core.Entities;
using ApricodeTestApi.Core.Repositories;
using ApricodeTestApi.DataTransfer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApricodeTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IRepository<Genre> genresRepository;

        public GenresController(IRepository<Genre> genresRepository) 
        {
            this.genresRepository = genresRepository;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetGenres() 
        {
            var genres = await genresRepository.GetAllAsync();
            return Ok(genres.Select(g => new GenreDTO(g)));
        }

    }
}
