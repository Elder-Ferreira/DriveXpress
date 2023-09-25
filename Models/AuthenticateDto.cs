using System.ComponentModel.DataAnnotations;

namespace DriveXpress.Models
{
    public class AuthenticateDto
    {
        [Required]
        public int Id { get; set; }
        public string Senha { get; set; }
    }
}
