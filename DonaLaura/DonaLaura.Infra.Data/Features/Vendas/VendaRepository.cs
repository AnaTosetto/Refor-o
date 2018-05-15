using DonaLaura.Domain.Exceptions;
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

        public Venda Atualizar(Venda venda)
        {
            if (venda.Id > 0)
            {
                Db.Update(_sqlUpdate, Take(venda));
                return venda;
            }
            else
            {
                throw new IdentificadorIndefinidoException();
            }
        }

        public void Excluir(Venda venda)
        {
            if(venda.Id > 0)
            {
                Db.Delete(_sqlDelete, Take(venda));
            }
            else
            {
                throw new IdentificadorIndefinidoException();
            }
        }

        public Venda Obter(long Id)
        {
            if(Id > 0)
            {
                return Db.Get<Venda>(_sqlGet, Make, new object[] { "@Id", Id });
            }
            else
            {
                throw new IdentificadorIndefinidoException();
            }
        }

        public IEnumerable<Venda> ObterTudo()
        {
            return Db.GetAll<Venda>(_sqlGetAll, Make);
        }

        private object[] Take(Venda venda)
        {
            return new object[]
            {
                "@Id", venda.Id,
                "@NomeCliente", venda.NomeCliente,
                "@Quantidade", venda.Quantidade,
                "@Lucro", venda.Lucro,
                "@ProdutoId", venda.Produto.Id
            };
        }

        private static Func<IDataReader, Venda> Make = reader =>
        new Venda
        {
            Id = Convert.ToInt64(reader["Id"]),
            NomeCliente = reader["NomeCliente"].ToString(),
            Quantidade = Convert.ToInt32(reader["Quantidade"]),
            //Lucro = Convert.ToDouble(reader["Lucro"]),
            Produto = new Produto
            {
                Id = Convert.ToInt64(reader["ProdutoId"]),
            }
        };
    }
}
