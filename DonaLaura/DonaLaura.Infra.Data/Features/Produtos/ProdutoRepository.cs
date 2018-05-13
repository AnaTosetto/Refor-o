using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Features.Produtos;
using DonaLaura.Dominio.Features.Produtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Infra.Data.Features.Produtos
{
    public class ProdutoRepository : IProdutoRepository
    {
        string _sqlInsert = @"INSERT INTO Produto 
                                (Nome, 
                                Disponibilidade, 
                                PrecoCusto,    
                                PrecoVenda, 
                                DataFabricacao, 
                                DataValidade) 
                               VALUES
                                (@Nome,    
                                 @Disponibilidade, 
                                 @PrecoCusto,   
                                 @PrecoVenda, 
                                 @DataFabricacao, 
                                 @DataValidade);";

        string _sqlUpdate = @"UPDATE Produto
                                SET Nome = @Nome,
                                    Disponibilidade = @Disponibilidade, 
                                    PrecoCusto = @PrecoCusto,    
                                    PrecoVenda = @PrecoVenda, 
                                    DataFabricacao = @DataFabricacao, 
                                    DataValidade = @DataValidade
                                WHERE Id = @Id";

        string _sqlDelete = @"DELETE FROM Produto
                                WHERE Id = @Id";

        string _sqlGet = @"SELECT * FROM produto
                            WHERE Id = @Id";

        string _sqlGetAll = @"SELECT * FROM Produto";

        public Produto Adicionar(Produto produto)
        {
            produto.Id = Db.Insert(_sqlInsert, Take(produto));
            return produto;
        }

        public Produto Atualizar(Produto produto)
        {
            if(produto.Id > 0)
            {
                Db.Update(_sqlUpdate, Take(produto));
                return produto;
            }
            else
            {
                throw new IdentificadorIndefinidoException();
            }         
        }

        public void Excluir(Produto produto)
        {
            if (produto.Id > 0)
            {
                Db.Delete(_sqlDelete, Take(produto));
            }
            else
            {
                throw new IdentificadorIndefinidoException();
            }
            
        }

        public Produto Obter(long Id)
        {
            if(Id > 0)
            {
                return Db.Get<Produto>(_sqlGet, Make, new object[] { "@Id", Id });
            }
            else
            {
                throw new IdentificadorIndefinidoException();
            }
        }

        public IEnumerable<Produto> ObterTudo()
        {
            return Db.GetAll<Produto>(_sqlGetAll, Make);
        }

        private object[] Take(Produto produto)
        {
            return new object[]
            {
                "@Id", produto.Id,
                "@Nome", produto.Nome,
                "@Disponibilidade", produto.Disponibilidade,
                "@PrecoCusto", produto.PrecoCusto,
                "@PrecoVenda", produto.PrecoVenda,
                "@DataFabricacao", produto.DataFabricacao,
                "@DataValidade", produto.DataValidade
            };
        }

        private static Func<IDataReader, Produto> Make = reader =>
            new Produto
            {
                Id = Convert.ToInt64(reader["Id"]),
                Nome = reader["Nome"].ToString(),
                Disponibilidade = Convert.ToBoolean(reader["Disponibilidade"]),
                PrecoCusto = Convert.ToDouble(reader["PrecoCusto"]),
                PrecoVenda = Convert.ToDouble(reader["PrecoVenda"]),
                DataFabricacao = Convert.ToDateTime(reader["DataFabricacao"]),
                DataValidade = Convert.ToDateTime(reader["DataValidade"])
            };
    }
}
