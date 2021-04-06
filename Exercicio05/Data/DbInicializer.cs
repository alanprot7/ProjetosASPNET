using Exercicio05.Models;
using System.Data.Entity;

namespace Exercicio05.Data
{
    internal class DbInicializer : CreateDatabaseIfNotExists<FNDataContext>
    {
        protected override void Seed(FNDataContext context)
        {
            base.Seed(context);
        }
    }
}