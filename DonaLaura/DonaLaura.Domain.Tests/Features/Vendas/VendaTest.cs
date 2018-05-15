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

            //Acão
            Action action = () => venda.Validate();

            //Verificar
            action.Should().NotThrow();
        }

        [Test]
        public void Venda_DeveSerValido_Lucro()
        {
            Venda venda = new Venda();
            _mockProduto.Setup(precoCusto => precoCusto.PrecoCusto).Returns(2);
            _mockProduto.Setup(precoVenda => precoVenda.PrecoVenda).Returns(4);
            venda.Quantidade = 3;

            //double lucro = 6;

            venda.Lucro.Should().Be(6);
        }
    }
}
