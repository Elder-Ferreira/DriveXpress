using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriveXpress.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Quantidade { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public double Valor { get; set; } 
        [Required]
        public TipoProduto Tipo { get; set; }  

        [Required]
        public int RestauranteId { get; set; } //restaurante pode ter varios produtos (associado a Key de restaurante)
        [Required]
        public Restaurante Restaurante { get; set; } //retorna dados restaurante
        
    }
    public enum TipoProduto
    {
        Bebida,
        Comida
    }
}


//Inserir campo observação