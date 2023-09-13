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
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public PerfilUsuario Perfil { get; set; }

        public ICollection<Produto> Produtos { get; set; } //usuario possui uma coleção de produtos
    }

    public enum PerfilUsuario
    {
        Cliente,
        Funcionario,
        Gerente
    }
}
