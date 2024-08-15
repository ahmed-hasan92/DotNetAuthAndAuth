using System.ComponentModel.DataAnnotations;

namespace OnnlineStore.Models.Domain
{
    public class Category
    {

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
