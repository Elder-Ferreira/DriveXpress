using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriveXpress.Models
{
    [Table("Restaurantes")]
    public class Restaurante : LinksHATEOS
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public Categoria Categoria { get; set; }

        public ICollection<Produto> Produtos { get; set; } //restaurante possui uma coleção de produtos

        //public ICollection<Pedido> Pedidos { get; set; } //restaurante possui uma coleção de produtos

        public ICollection<RestauranteUsuarios> Usuarios { get; set; } //restaurante possui uma coleção de usuarios
    }
        public enum Categoria
    {
        Japonesa,
        Gourmet,
        Doces
    }

}
