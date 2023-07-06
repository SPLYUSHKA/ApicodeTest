using ApricodeTestApi.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace ApricodeTestApi.DataTransfer
{
    public class GameDTO
    {

        public GameDTO() 
        { 

        }

        public GameDTO(Game game)
        {
            Id = game.Id;
            Title = game.Title;
            DeveloperId = game.DeveloperId;
            Developer = game.Developer.Name;
            Genres = game.Genres.Distinct().Select(g => new GenreDTO(g)).ToHashSet();
        }

        public Game ToGame() => new Game
        {
            Id = Id,
            Title = Title,
            DeveloperId = DeveloperId,
            Genres = Genres.Select(g => g.ToGenre()).ToList()
        };


        public int Id { get; set; }

        [StringLength(300)]
        public string Title { get; set; } = string.Empty;

        public string? Developer { get; set; }
        public int DeveloperId { get; set; }

        [MinLength(1)]
        public HashSet<GenreDTO> Genres { get; set; }

    }
}
