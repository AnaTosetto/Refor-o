using DonaLaura.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Common.Tests.Base
{
    public static class ProdutoBaseSqlTest
    {
        private const string RECREATE_PRODUTO_TABLE =
          "TRUNCATE TABLE Venda; DELETE FROM Produto DBCC CHECKIDENT('DBDonaLaura.dbo.Produto', RESEED, 0)";

        private const string INSERT_PRODUTO = "INSERT INTO Produto(Nome, Disponibilidade, PrecoVenda, PrecoCusto, DataFabricacao, DataValidade) VALUES ('Repolho', 1, 4.00, 3.40, GETDATE(), GETDATE())";

        public static void SeedDatabase()
        {
            Db.Update(RECREATE_PRODUTO_TABLE);
            Db.Update(INSERT_PRODUTO);
        }
    }
}
