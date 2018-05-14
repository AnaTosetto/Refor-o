using DonaLaura.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Common.Tests.Base
{
    public static class VendaBaseSqlTest
    {

        private const string INSERT_VENDA = "INSERT INTO Venda(NomeCliente, Quantidade, Lucro, ProdutoId) VALUES ('nome', 2, 4.00, 1)";


        public static void SeedDatabase()
        {
            ProdutoBaseSqlTest.SeedDatabase();
            Db.Update(INSERT_VENDA);
        }
    }
}
