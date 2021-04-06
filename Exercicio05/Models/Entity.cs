using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercicio05.Models
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }

        [Required, Column(TypeName = "varchar"), StringLength(100)]
        public string Nome { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
