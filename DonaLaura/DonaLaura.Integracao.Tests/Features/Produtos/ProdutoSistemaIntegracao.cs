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

        [Test]
        public void ProdutoSistemIntegracao_Atualizar_DeveRetornarOk()
        {
            //Arrange
            Produto produtoParaEditar = _produtoService.Obtem(1);
            string produtoVelho = produtoParaEditar.Nome;
            string produtoNovo = "Produto";

            if(produtoVelho == produtoNovo)
            {
                produtoNovo = "Novo Produto";
            }

            produtoParaEditar.Nome = produtoNovo;

            //Action
            Produto produtoResultado = _produtoService.Atualiza(produtoParaEditar);

            //Verify
            produtoResultado.Nome.Should().NotBe(produtoVelho);
            produtoResultado.Id.Should().Be(produtoParaEditar.Id);
        }

        [Test]
        public void ProdutoSistemaIntegracao_Excluir_DeveRetornarOk()
        {
            //Arrange
            Produto produto = ObjectMother.getValidoProduto();
            produto.Id = 0;

            produto = _produtoService.Adiciona(produto);

            //Action
            _produtoService.Exclui(produto);

            //Verify
            Produto produtoInexistente = _produtoService.Obtem(produto.Id);
            produtoInexistente.Should().BeNull();
        }

        [Test]
        public void ProdutoSistemaIntegracao_Obter_DeveRetornarOk()
        {
            //Arrange
            Produto produto = new Produto();
            produto.Id = 1;

            //Action
            produto = _produtoService.Obtem(produto.Id);

            //Verify
            produto.Id.Should().Be(1);
            produto.Should().NotBeNull();
        }

        [Test]
        public void ProdutoSistemaIntegracao_ObterTudo_DeveRetornarOk()
        {
            //Arrange
            IEnumerable<Produto> listaProduto;

            //Action
            listaProduto = _produtoService.ObtemTudo();

            //Verify
            listaProduto.Should().NotBeNull();
            listaProduto.Count().Should().BeGreaterOrEqualTo(0);
        }
    }
}
