using System.ComponentModel.DataAnnotations.Schema;

namespace Exercicio05.Models
{
    [Table("Produto")]
    public class Produto : Entity
    {

        [Column(TypeName = "money")]
        public decimal Preco { get; set; }

        [Column("Quantidade")]
        public short Qtde { get; set; }

        public int TipoDeProdutoId { get; set; }

        [ForeignKey("TipoDeProdutoId")]
        public virtual TipoDeProduto TipoDeProduto { get; set; }

    }
}
