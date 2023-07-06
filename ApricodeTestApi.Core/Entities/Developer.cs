using System.ComponentModel.DataAnnotations;

namespace ApricodeTestApi.Core.Entities
{
    public class Developer
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(300)]        
        public string Name { get; set; } = string.Empty;
    }
}