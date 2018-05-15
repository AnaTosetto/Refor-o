using System;
using System.Collections.Generic;
using System.Linq;
using DonaLaura.Aplicacao.Features.Produtos;
using DonaLaura.Common.Tests.Features.Produtos;
using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Features.Produtos;
using DonaLaura.Domain.Features.Produtos.Exceptions;
using DonaLaura.Dominio.Features.Produtos;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace DonaLaura.Aplicacao.Tests.Features.Produtos
{
    [TestFixture]
    public class ProdutoServiceTest
    {
        ProdutoService _produtoService;

        private Mock<IProdutoRepository> _mockProdutoRepository;

        [SetUp]
        public void TesteSetup()
        {
            _mockProdutoRepository = new Mock<IProdutoRepository>();
            _produtoService = new ProdutoService(_mockProdutoRepository.Object);
        }

        [Test]
        public void ProdutoService_Adiciona_ProdutoValido_DeveRetornarOk() 
        {
            //Cenário
            Produto produto = ObjectMother.getValidoProduto();
            produto.Id = 0;

            //Ação
            _mockProdutoRepository.Setup(rp => rp.Adicionar(produto)).Returns(new Produto { Id = 1, Nome = "abcd", Disponibilidade = true, PrecoCusto = 2.00, PrecoVenda = 3.45, DataFabricacao = DateTime.Now.AddDays(-2), DataValidade = DateTime.Now.AddDays(3) });
            Produto retorno = _produtoService.Adiciona(produto);

            //Verificar
            _mockProdutoRepository.Verify(rp => rp.Adicionar(produto));
            retorno.Should().NotBeNull();
            retorno.Id.Should().BeGreaterThan(0);
            retorno.Id.Should().NotBe(produto.Id);
        }

        [Test]
        public void ProdutoService_Adiciona_NomeNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Produto produto = ObjectMother.getNuloOuVazioNomeProduto();
            produto.Id = 0;

            //Ação
            _mockProdutoRepository.Setup(rp => rp.Adicionar(produto)).Returns(new Produto { Id = 1, Nome = "abcd", Disponibilidade = true, PrecoCusto = 2.00, PrecoVenda = 3.45, DataFabricacao = DateTime.Now.AddDays(-2), DataValidade = DateTime.Now.AddDays(3) });
            Action acaoRetorno = () => _produtoService.Adiciona(produto);

            //Verificar
            acaoRetorno.Should().Throw<NomeNuloOuVazioException>();
            _mockProdutoRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void ProdutoService_Adiciona_CaracteresMinimo_DeveRetornarExcecao()
        {
            //Cenário
            Produto produto = ObjectMother.getCaracteresMinimoNomeProduto();
            produto.Id = 0;

            //Ação
            _mockProdutoRepository.Setup(rp => rp.Adicionar(produto)).Returns(new Produto { Id = 1, Nome = "abcd", Disponibilidade = true, PrecoCusto = 2.00, PrecoVenda = 3.45, DataFabricacao = DateTime.Now.AddDays(-2), DataValidade = DateTime.Now.AddDays(3) });
            Action acaoRetorno = () => _produtoService.Adiciona(produto);

            //Verificar
            acaoRetorno.Should().Throw<CaracteresMinimoException>();
            _mockProdutoRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void ProdutoService_Adicionar_DataDeValidadeInvalida_DeveRetornarExcecao()
        {
            //Cenário
            Produto produto = ObjectMother.getDataDeValidadeInvalidaProduto();
            produto.Id = 0;

            //Ação
            _mockProdutoRepository.Setup(rp => rp.Adicionar(produto)).Returns(new Produto { Id = 1, Nome = "abcd", Disponibilidade = true, PrecoCusto = 2.00, PrecoVenda = 3.45, DataFabricacao = DateTime.Now.AddDays(-2), DataValidade = DateTime.Now.AddDays(3) });
            Action acaoRetorno = () => _produtoService.Adiciona(produto);

            //Verificar
            acaoRetorno.Should().Throw<DataDeValidadeInvalidaException>();
            _mockProdutoRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void ProdutoService_Adicionar_PrecoDeCustoInvalido_DeveRetornarExcecao()
        {
            //Cenário
            Produto produto = ObjectMother.getPrecoDeCustoInvalidoProduto();
            produto.Id = 0;

            //Ação
            _mockProdutoRepository.Setup(rp => rp.Adicionar(produto)).Returns(new Produto { Id = 1, Nome = "abcd", Disponibilidade = true, PrecoCusto = 2.00, PrecoVenda = 3.45, DataFabricacao = DateTime.Now.AddDays(-2), DataValidade = DateTime.Now.AddDays(3) });
            Action acaoRetorno = () => _produtoService.Adiciona(produto);

            //Verificar
            acaoRetorno.Should().Throw<PrecoDeCustoInvalidoException>();
            _mockProdutoRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void ProdutoService_Adicionar_DataDeFabricacaoInvalida_DeveRetornarExcecao()
        {
            //Cenário
            Produto produto = ObjectMother.getDataDeFabricacaoInvalidaProduto();
            produto.Id = 0;

            //Ação
            _mockProdutoRepository.Setup(rp => rp.Adicionar(produto)).Returns(new Produto { Id = 1, Nome = "abcd", Disponibilidade = true, PrecoCusto = 2.00, PrecoVenda = 3.45, DataFabricacao = DateTime.Now.AddDays(-2), DataValidade = DateTime.Now.AddDays(3) });
            Action acaoRetorno = () => _produtoService.Adiciona(produto);

            //Verificar
            acaoRetorno.Should().Throw<DataDeFabricacaoInvalidaException>();
            _mockProdutoRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void ProdutoService_Atualizar_ProdutoValido_DeveRetornarOk()
        {
            //Cenário
            Produto produto = ObjectMother.getValidoProduto();
            produto.Id = 1;

            //Ação
            _mockProdutoRepository.Setup(rp => rp.Atualizar(produto)).Returns(new Produto { Id = produto.Id, Nome = "abcd", Disponibilidade = true, PrecoCusto = 2.00, PrecoVenda = 3.45, DataFabricacao = DateTime.Now.AddDays(-2), DataValidade = DateTime.Now.AddDays(3) });
            Produto retorno = _produtoService.Atualiza(produto);

            //Verificar
            _mockProdutoRepository.Verify(rp => rp.Atualizar(produto));
            retorno.Should().NotBeNull();
            retorno.Id.Should().Be(produto.Id);
        }

        [Test]
        public void ProdutoService_Excluir_ProdutoValido_DeveRetornarOk()
        {
            //Cenário
            Produto produto = ObjectMother.getValidoProduto();
            produto.Id = 1;

            //Ação
            _mockProdutoRepository.Setup(rp => rp.Excluir(produto));
            _produtoService.Exclui(produto);

            //Verificar
            _mockProdutoRepository.Verify(rp => rp.Excluir(produto));
        }

        [Test]
        public void ProdutoService_Obtem_ProdutoValido_DeveRetornarOk()
        {
            //Cenário
            Produto produto = ObjectMother.getValidoProduto();
            produto.Id = 1;

            //Ação
            _mockProdutoRepository.Setup(rp => rp.Obter(produto.Id)).Returns(new Produto { Id = 1, Nome = "abcd", Disponibilidade = true, PrecoCusto = 2.00, PrecoVenda = 3.45, DataFabricacao = DateTime.Now.AddDays(-2), DataValidade = DateTime.Now.AddDays(3) });
            Produto retorno = _produtoService.Obtem(produto.Id);

            //Verificar
            _mockProdutoRepository.Verify(rp => rp.Obter(produto.Id));

            retorno.Should().NotBeNull();
            retorno.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void ProdutoService_ObtemTudo_ProdutoValido_DeveRetornarOk()
        {
            //Ação
            _mockProdutoRepository.Setup(rp => rp.ObterTudo()).Returns(Enumerable.Empty<Produto>);
            IEnumerable<Produto> retorno = _produtoService.ObtemTudo();

            //Verificar
            foreach(Produto produto in retorno)
            {
                produto.Id.Should().BeGreaterThan(0);
                produto.Should().NotBeNull();
            }

            _mockProdutoRepository.Verify(rp => rp.ObterTudo());
        }
    }
}
