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
        private const string RECREATE_PRODUTO_TABLE = "" +
            "ALTER TABLE [dbo].[Venda] DROP CONSTRAINT [FK_Venda_Produto];" +
            "TRUNCATE TABLE Produto;" +
            "ALTER TABLE [dbo].[Venda] WITH CHECK ADD CONSTRAINT [FK_Venda_Produto] FOREIGN KEY ([ProdutoId]) REFERENCES [dbo].[Produto] ([Id])";

        private const string INSERT_PRODUTO = "INSERT INTO Produto(Nome, Disponibilidade, PrecoVenda, PrecoCusto, DataFabricacao, DataValidade) VALUES ('Repolho', 1, 4.00, 3.40, GETDATE(), GETDATE())";

        public static void SeedDatabase()
        {
            Db.Update(RECREATE_PRODUTO_TABLE);
            Db.Update(INSERT_PRODUTO);
        }
    }
}

