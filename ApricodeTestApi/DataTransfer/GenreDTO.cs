using ApricodeTestApi.Core.Entities;

namespace ApricodeTestApi.DataTransfer
{
    public class GenreDTO
    {
        public GenreDTO() { }

        public GenreDTO(Genre genre)
        {
            Id = genre.Id;
            GenreName = genre.Name;
        }

        public Genre ToGenre() => new Genre
        {
            Id = Id,
            Name = GenreName ?? string.Empty
        };

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object? obj)
        {
            if (obj is GenreDTO genre)
            {
                return Id.Equals(genre.Id);
            }

            return base.Equals(obj);
        }



        public int Id { get; set; }
        public string? GenreName { get; set; } = null!;
    }
}
