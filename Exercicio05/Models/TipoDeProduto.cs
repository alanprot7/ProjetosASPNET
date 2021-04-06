using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercicio05.Models
{
    [Table("TipoDeProduto")]
    public class TipoDeProduto : Entity
    {
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
