using System.ComponentModel.DataAnnotations;

namespace ApricodeTestApi.Core.Entities
{
    public class Game
    {
        [Key]
        public int Id { get; set; }


        [MaxLength(300)]
        public string Title { get; set; } = string.Empty;

        public int DeveloperId { get; set; }
        public Developer Developer { get; set; } = null!;

        public ICollection<Genre> Genres { get; set; } = new List<Genre>();

    }
}