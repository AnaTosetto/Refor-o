using DonaLaura.Domain.Features.Produtos;
using DonaLaura.Dominio.Features.Produtos;
using System;
using System.Collections.Generic;
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

        public Produto Adicionar(Produto produto)
        {
            produto.Id = Db.Insert(_sqlInsert, Take(produto));
            return produto;
        }

        public Produto Atualizar(Produto entidade)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Produto entidade)
        {
            throw new NotImplementedException();
        }

        public Produto Obter(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> ObterTudo()
        {
            throw new NotImplementedException();
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
    }
}
