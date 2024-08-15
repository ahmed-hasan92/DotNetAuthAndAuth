using System.ComponentModel.DataAnnotations;

namespace OnnlineStore.Models.Domain
{
    public class Author
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Biography { get; set; }
    }
}
