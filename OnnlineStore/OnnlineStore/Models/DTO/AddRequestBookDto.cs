using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnnlineStore.Models.DTO
{
    public class AddRequestBookDto
    {
        [Required]
        [MinLength(8,ErrorMessage ="The title must atleast consist of 8 characters ")]
        [MaxLength(120,ErrorMessage ="The number of characters exceeded 120!")]
        public string Title { get; set; }
        public string Description { get; set; } = "No description available for this book.";
        [Required]
        [Range(4,199.9)]
        public decimal Price { get; set; }
        public string? CoverImageUrl { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
    }
}
