using Exercicio05.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio05.Data
{
    public class FNDataContext:DbContext
    {
        public FNDataContext():base("StoreConn")
        {
            Database.SetInitializer(new DbInicializer());
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<TipoDeProduto> TiposDeProdutos { get; set; }
    }
}
