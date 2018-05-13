using DonaLaura.Domain.Features.Produtos;
using DonaLaura.Dominio.Features.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Aplicacao.Features.Produtos
{
    public class ProdutoService
    {
        IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public Produto Adiciona(Produto produto)
        {
            produto.Validate();

            return _produtoRepository.Adicionar(produto);
        }

        public Produto Atualiza(Produto produto)
        {
            produto.Validate();

            return _produtoRepository.Atualizar(produto);
        }

        public void Exclui(Produto produto)
        {
            _produtoRepository.Excluir(produto);
        }

        public Produto Obtem(long id)
        {
            return _produtoRepository.Obter(id);
        }

        public IEnumerable<Produto> ObtemTudo()
        {
            return _produtoRepository.ObterTudo();
        }
    }
}
