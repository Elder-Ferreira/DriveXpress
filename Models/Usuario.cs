using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriveXpress.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
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

        public enum PerfilUsuario
        {
            [Display(Name = "Cliente")]
            Cliente,
            [Display(Name = "Funcionario")]
            Funcionario,
            [Display(Name = "Gerente")]
            Gerente
        }
    
}
