using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriveXpress.Models
{
    [Table("Pedidos")]
    public class Pedido : LinksHATEOS
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NomeCliente { get; set; }        
        [Required]
        public string Descricao { get; set; }
        [Required]
        public int Quantidade { get; set; }        
        [Required]
        public double Valor { get; set; }

        [Required]
        public int RestauranteId { get; set; } //produto pertence a um unico restaurante (produto associado a Key de restaurante)

        public ICollection<Produto> Produtos { get; set; } //pedido possui uma coleção de produtos
    }
}
