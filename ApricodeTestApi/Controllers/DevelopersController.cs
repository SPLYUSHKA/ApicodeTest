using ApricodeTestApi.Core.Entities;
using ApricodeTestApi.Core.Repositories;
using ApricodeTestApi.DataTransfer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApricodeTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {

        private readonly IRepository<Developer> developerRepository;

        public DevelopersController(IRepository<Developer> developerRepository)
        {
            this.developerRepository = developerRepository;
        }


        [HttpGet("get")]
        public async Task<IActionResult> GetGenres()
        {
            var genres = await developerRepository.GetAllAsync();
            return Ok(genres.Select(d => new DeveloperDTO(d)));
        }
    }
}
