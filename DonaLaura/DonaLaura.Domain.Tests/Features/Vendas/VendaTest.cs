using DonaLaura.Domain.Features.Vendas;
using DonaLaura.Domain.Features.Vendas.Exceptions;
using FluentAssertions;
using NUnit.Framework;
using System;
using Moq;
using DonaLaura.Common.Tests.Features.Vendas;
using DonaLaura.Domain.Exceptions;
using DonaLaura.Dominio.Features.Produtos;

namespace DonaLaura.Domain.Tests.Features.Vendas
{
    [TestFixture]
    public class VendaTest
    {
        private Mock<Produto> _mockProduto;

        [SetUp]
        public void TestSetup()
        {
            _mockProduto = new Mock<Produto>();           
        }

        [Test]
        public void Venda_QuantidadeMenorOuIgualZero_DeveRetornarExcecao()
        {
            //Cenário
            Venda venda = ObjectMother.getQuantidadeMenorOuIgualZeroVenda(_mockProduto.Object);
            venda.Id = 1;

            //Acão
            Action action = () => venda.Validate();

            //Verificar
            action.Should().Throw<QuantidadeMenorOuIgualZeroException>();
        }

        [Test]
        public void Venda_NomeNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Venda venda = ObjectMother.getNomeNuloOuVazioVenda(_mockProduto.Object);
            venda.Id = 1;

            //Acão
            Action action = () => venda.Validate();

            //Verificar
            action.Should().Throw<NomeNuloOuVazioException>();
        }

        [Test]
        public void Venda_DeveSerValido()
        {
            //Cenário
            Venda venda = ObjectMother.getValidoVenda(_mockProduto.Object);
            venda.Id = 1;

            _mockProduto.Setup(disponivel => disponivel.Disponibilidade).Returns(true);
            _mockProduto.Setup(dataValidade => dataValidade.DataValidade).Returns(DateTime.Now.AddDays(2));

            //Acão
            Action action = () => venda.Validate();

            //Verificar
            action.Should().NotThrow();
        }

        [Test]
        public void Venda_Lucro_DeveSerValido()
        {
            Venda venda = ObjectMother.getValidoVenda(_mockProduto.Object);
            venda.Id = 1;
            venda.Quantidade = 3;

            _mockProduto.Setup(precoCusto => precoCusto.PrecoCusto).Returns(2);
            _mockProduto.Setup(precoVenda => precoVenda.PrecoVenda).Returns(4);

            var lucro = venda.Lucro;
            
            venda.Lucro.Should().Be(6);
        }

        [Test]
        public void Venda_ProdutoIndisponivel_DeveRetornarExcecao()
        {
            Venda venda = ObjectMother.getValidoVenda(_mockProduto.Object);
            venda.Id = 1;

            _mockProduto.Setup(disponivel => disponivel.Disponibilidade).Returns(false);

            Action acaoResultado = () => venda.Validate();

            acaoResultado.Should().Throw<ProdutoIndisponivelEmEstoqueException>();
        }

        [Test]
        public void Venda_ProdutoForaDaDataDeValidade_DeveRetornarExcecao()
        {
            Venda venda = ObjectMother.getValidoVenda(_mockProduto.Object);
            venda.Id = 1;

            _mockProduto.Setup(disponivel => disponivel.Disponibilidade).Returns(true);
            _mockProduto.Setup(dataValidade => dataValidade.DataValidade).Returns(DateTime.Now.AddDays(-2));

            Action acaoResultado = () => venda.Validate();

            acaoResultado.Should().Throw<ProdutoForaDaDataDeValidadeException>();
        }
    }
}
