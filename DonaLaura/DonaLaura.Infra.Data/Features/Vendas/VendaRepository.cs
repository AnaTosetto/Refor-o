using DonaLaura.Domain.Features.Vendas;
using DonaLaura.Dominio.Features.Produtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Infra.Data.Features.Vendas
{
    public class VendaRepository : IVendaRepository
    {
        string _sqlInsert = @"INSERT INTO Venda 
                                        (NomeCliente, 
                                        Quantidade, 
                                        Lucro, 
                                        ProdutoId)
                                    VALUES
                                        (@NomeCliente, 
                                         @Quantidade, 
                                         @Lucro, 
                                         @ProdutoId);";

        string _sqlUpdate = @"UPDATE Venda
                                SET NomeCliente = @NomeCliente, 
                                        Quantidade = @Quantidade, 
                                        Lucro = @Lucro, 
                                        ProdutoId = @ProdutoId
                                    WHERE Id = @Id";

        string _sqlDelete = @"DELETE FROM Venda
                                WHERE Id = @Id";

        string _sqlGet = @"SELECT * FROM Venda
                            WHERE Id = @Id";

        string _sqlGetAll = @"SELECT * FROM Venda";
                                    

        public Venda Adicionar(Venda venda)
        {
            venda.Id = Db.Insert(_sqlInsert, Take(venda));
            return venda;
        }

        public Venda Atualizar(Venda entidade)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Venda entidade)
        {
            throw new NotImplementedException();
        }

        public Venda Obter(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Venda> ObterTudo()
        {
            throw new NotImplementedException();
        }

        private object[] Take(Venda venda)
        {
            return new object[]
            {
                "@Id", venda.Id,
                "@NomeCliente", venda.NomeCliente,
                "@Quantidade", venda.Quantidade,
                "@Lucro", venda.Lucro,
                "@ProdutoId", venda.Produto
            };
        }

        private static Func<IDataReader, Venda> Make = reader =>
        new Venda
        {
            Id = Convert.ToInt64(reader["Id"]),
            NomeCliente = reader["NomeCliente"].ToString(),
            Quantidade = Convert.ToInt32(reader["Quantidade"]),
            Lucro = Convert.ToDouble(reader["Lucro"]),
            Produto = new Produto
            {
                Id = Convert.ToInt64(reader["ProdutoId"]),
            }
        };
    }
}
