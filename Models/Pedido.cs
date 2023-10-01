using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriveXpress.Models
{
    [Table("Pedido")]
    public class Pedido : LinksHATEOS
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NomeUsuario { get; set; }        
        [Required]
        public string Descricao { get; set; }
        [Required]
        public int Quantidade { get; set; }        
        [Required]
        public double Valor { get; set; }
        
        [Required]
        public int RestauranteId { get; set; } //pedido pertence a um unico restaurante (pedido associado a Key de restaurante)

        public Produto Produto { get; set; } //retorna produtos cadastrados
    }
}
