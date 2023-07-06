using System.ComponentModel.DataAnnotations;

namespace ApricodeTestApi.Core.Entities
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(300)]
        public string Name { get; set; } = string.Empty;


        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}