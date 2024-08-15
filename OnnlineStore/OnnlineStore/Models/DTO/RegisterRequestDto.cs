using System.ComponentModel.DataAnnotations;

namespace OnnlineStore.Models.DTO
{
    public class RegisterRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public List<string> Roles { get; set; }
    }
}
