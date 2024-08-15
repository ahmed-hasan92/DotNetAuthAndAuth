using System.ComponentModel.DataAnnotations;

namespace OnnlineStore.Models.Domain
{
    public class Book
    {

        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? CoverImageUrl { get; set; }

        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }

        // Navigation properties
        public Author Author { get; set; }
        public Category Category { get; set; }
    }
}
