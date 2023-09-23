using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DriveXpress.Models
{
    public class UsuarioDto
    {
        public int? Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public PerfilUsuario Perfil { get; set; }

        public ICollection<RestauranteUsuarios> Restaurantes { get; set; } //usuario possui uma coleção de restaurantes. usuario possui varios restaurantes
    }
}


