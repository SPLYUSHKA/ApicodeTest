using ApricodeTestApi.Core.Entities;

namespace ApricodeTestApi.DataTransfer
{
    public class DeveloperDTO
    {
        public DeveloperDTO(Developer developer) 
        { 
            Id = developer.Id;
            Name = developer.Name;
        }

        public Developer ToDeveloper() => new Developer
        {
            Id = Id,
            Name = Name
        };

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
