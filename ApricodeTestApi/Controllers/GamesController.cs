using ApricodeTestApi.Core.Entities;
using ApricodeTestApi.Core.Errors;
using ApricodeTestApi.Core.Repositories;
using ApricodeTestApi.DataTransfer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApricodeTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGamesRepository gamesRepository;

        public GamesController(IGamesRepository gamesRepository) 
        {
            this.gamesRepository = gamesRepository;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAllGames()
        {
           
            List<Game> games = await gamesRepository.GetAllAsync();
            return Ok(games.Select(game => new GameDTO(game)));
        }

        [HttpGet("get/{genreId}")]
        public async Task<IActionResult> GetGamesByGenre(int genreId)
        {
            List<Game> games = await gamesRepository.GetGamesByGenreAsync(genreId);
            return Ok(games.Select(game => new GameDTO(game)));
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddGame(GameDTO game)
        {
            game.Id = 0;
            try
            {
                var addedGame = await gamesRepository.AddAsync(game.ToGame());
                return Ok(new GameDTO(addedGame));
            }
            catch (NotFoundException e)
            {

                return NotFound(e.Message);
            }
          
           
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateGame(GameDTO game)
        {
            try
            {
                var updatedGame = await gamesRepository.UpdateAsync(game.ToGame());
                return Ok(new GameDTO(updatedGame));
            }
            catch (NotFoundException e)
            {

               return NotFound(e.Message);
            }
           
        }

        [HttpDelete("remove/{gameId}")]
        public async Task<IActionResult> DeleteGame(int gameId)
        {
            try
            {
                await gamesRepository.RemoveAsync(gameId);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            return Ok($"Игра {gameId} удалена");
        }
    }
}
