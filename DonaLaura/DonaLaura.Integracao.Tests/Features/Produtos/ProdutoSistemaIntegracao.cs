using DonaLaura.Aplicacao.Features.Produtos;
using DonaLaura.Common.Tests.Features;
using DonaLaura.Dominio.Features.Produtos;
using DonaLaura.Infra.Data.Features.Produtos;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Integracao.Tests.Features.Produtos
{
    public class ProdutoSistemaIntegracao
    {
        ProdutoRepository _produtoRepository = new ProdutoRepository();

        ProdutoService _produtoService;

        [SetUp]
        public void TestSetup()
        {
            _produtoService = new ProdutoService(_produtoRepository);
        }

        [Test]
        public void ProdutoSistemaIntegracao_Adiciona_DeveRetornarOk()
        {
            //Arrange
            Produto produto = ObjectMother.getValidoProduto();
            produto.Id = 0;

            //IEnumerable<Produto> timelineAntes = _produtoService.ObtemTudo();

            //Action
            Produto produtoResultado = _produtoService.Adiciona(produto);

            //Verify
            produtoResultado.Should().NotBeNull();
            produtoResultado.Id.Should().BeGreaterThan(0);
            //produtoResultado.Nome.Should().Be(produto.Nome);
            //produtoResultado.Disponibilidade.Should().Be(produto.Disponibilidade);
            //produtoResultado.PrecoCusto.Should().Be(produto.PrecoCusto);
            //produtoResultado.PrecoVenda.Should().Be(produto.PrecoVenda);
            //produtoResultado.DataFabricacao.Should().BeBefore(DateTime.Now);
            //produtoResultado.DataValidade.Should().BeBefore(DateTime.Now.AddDays(2));

            //Produto produtoGet = _produtoService.Obtem(produtoResultado.Id);

            //produtoResultado.Id.Should().Be(produtoGet.Id);

            //IEnumerable<Produto> timelineDepois = _produtoService.ObtemTudo();

            //timelineDepois.Should().NotBeEmpty();
            //timelineDepois.Count().Should().BeGreaterThan(timelineAntes.Count());

            _produtoService.Exclui(produtoResultado);
        }
    }
}
