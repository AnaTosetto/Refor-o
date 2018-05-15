using DonaLaura.Aplicacao.Features.Produtos;
using DonaLaura.Common.Tests.Features.Produtos;
using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Features.Produtos.Exceptions;
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
            //Cenário
            Produto produto = ObjectMother.getValidoProduto();
            produto.Id = 0;

            IEnumerable<Produto> timelineAntes = _produtoService.ObtemTudo();

            //Acão
            Produto produtoResultado = _produtoService.Adiciona(produto);

            //Verificar
            produtoResultado.Should().NotBeNull();
            produtoResultado.Id.Should().BeGreaterThan(0);
            produtoResultado.Nome.Should().Be(produto.Nome);
            produtoResultado.Disponibilidade.Should().Be(produto.Disponibilidade);
            produtoResultado.PrecoCusto.Should().Be(produto.PrecoCusto);
            produtoResultado.PrecoVenda.Should().Be(produto.PrecoVenda);
            produtoResultado.DataFabricacao.Should().BeBefore(DateTime.Now);
            produtoResultado.DataValidade.Should().BeBefore(DateTime.Now.AddDays(3));

            Produto produtoGet = _produtoService.Obtem(produtoResultado.Id);

            produtoResultado.Id.Should().Be(produtoGet.Id);

            IEnumerable<Produto> timelineDepois = _produtoService.ObtemTudo();

            timelineDepois.Should().NotBeEmpty();
            timelineDepois.Count().Should().BeGreaterThan(timelineAntes.Count());

            _produtoService.Exclui(produtoResultado);
        }

        [Test]
        public void ProdutoSistemaIntegracao_Adicionar_NomeNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Produto produto = ObjectMother.getNuloOuVazioNomeProduto();
            produto.Id = 0;

            //Acão
            Action acaoResultado = () => _produtoService.Adiciona(produto);

            //Verificar
            acaoResultado.Should().Throw<NomeNuloOuVazioException>();
        }

        [Test]
        public void ProdutoSistemaIntegracao_Adicionar_CaracteresMinimo_DeveRetornarExcecao()
        {
            //Cenário
            Produto produto = ObjectMother.getCaracteresMinimoNomeProduto();
            produto.Id = 0;

            //Acão
            Action acaoResultado = () => _produtoService.Adiciona(produto);

            //Verificar
            acaoResultado.Should().Throw<CaracteresMinimoException>();
        }

        [Test]
        public void ProdutoSistemaIntegracao_Adicionar_PrecoCustoInvalido_DeveRetornarExcecao()
        {
            //Cenário
            Produto produto = ObjectMother.getPrecoDeCustoInvalidoProduto();
            produto.Id = 0;

            //Acão
            Action acaoResultado = () => _produtoService.Adiciona(produto);

            //Verificar
            acaoResultado.Should().Throw<PrecoDeCustoInvalidoException>();
        }

        [Test]
        public void ProdutoSistemaIntegracao_Adicionar_DataDeFabricacaoInvalida_DeveRetornarExcecao()
        {
            //Cenário
            Produto produto = ObjectMother.getDataDeFabricacaoInvalidaProduto();
            produto.Id = 0;

            //Acão
            Action acaoResultado = () => _produtoService.Adiciona(produto);

            //Verificar
            acaoResultado.Should().Throw<DataDeFabricacaoInvalidaException>();
        }

        [Test]
        public void ProdutoSistemaIntegracao_Adicionar_DataDeValidadeInvalida_DeveRetornarExcecao()
        {
            //Cenário
            Produto produto = ObjectMother.getDataDeValidadeInvalidaProduto();
            produto.Id = 0;

            //Acão
            Action acaoResultado = () => _produtoService.Adiciona(produto);

            //Verificar
            acaoResultado.Should().Throw<DataDeValidadeInvalidaException>();
        }

        [Test]
        public void ProdutoSistemaIntegracao_Atualizar_DeveRetornarOk()
        {
            //Cenário
            Produto produtoParaEditar = _produtoService.Obtem(1);
            string produtoVelho = produtoParaEditar.Nome;
            string produtoNovo = "Produto";

            if(produtoVelho == produtoNovo)
            {
                produtoNovo = "Novo Produto";
            }

            produtoParaEditar.Nome = produtoNovo;

            //Acão
            Produto produtoResultado = _produtoService.Atualiza(produtoParaEditar);

            //Verificar
            produtoResultado.Nome.Should().NotBe(produtoVelho);
            produtoResultado.Id.Should().Be(produtoParaEditar.Id);
        }

        [Test]
        public void ProdutoSistemaIntegracao_Atualizar_DeveRetornarExcecao()
        {
            //Cenário
            Produto produto = ObjectMother.getValidoProduto();
            produto.Id = 0;

            //Acão
            Action acaoResultado = () => _produtoService.Atualiza(produto);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void ProdutoSistemaIntegracao_Excluir_DeveRetornarOk()
        {
            //Cenário
            Produto produto = ObjectMother.getValidoProduto();
            produto.Id = 0;

            produto = _produtoService.Adiciona(produto);

            //Acão
            _produtoService.Exclui(produto);

            //Verificar
            Produto produtoInexistente = _produtoService.Obtem(produto.Id);
            produtoInexistente.Should().BeNull();
        }

        [Test]
        public void ProdutoSistemaIntegracao_Excluir_DeveRetornarExcecao()
        {
            //Cenário
            Produto produto = ObjectMother.getValidoProduto();
            produto.Id = 0;

            //Acão
            Action acaoResultado = () => _produtoService.Exclui(produto);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void ProdutoSistemaIntegracao_Obter_DeveRetornarOk()
        {
            //Cenário
            Produto produto = new Produto();
            produto.Id = 1;

            //Acão
            produto = _produtoService.Obtem(produto.Id);

            //Verificar
            produto.Id.Should().Be(1);
            produto.Should().NotBeNull();
        }

        [Test]
        public void ProdutoSistemaIntegracao_Obter_DeveRetornarExcecao()
        {
            //Acão
            Produto produtoResultado = _produtoService.Obtem(9999999999999);

            //Verificar
            produtoResultado.Should().BeNull();
        }

        [Test]
        public void ProdutoSistemaIntegracao_ObterTudo_DeveRetornarOk()
        {
            //Cenário
            IEnumerable<Produto> listaProduto;

            //Acão
            listaProduto = _produtoService.ObtemTudo();

            //Verificar
            listaProduto.Should().NotBeNull();
            listaProduto.Count().Should().BeGreaterOrEqualTo(0);
        }
    }
}
