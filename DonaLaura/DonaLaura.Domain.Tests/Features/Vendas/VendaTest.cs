using DonaLaura.Domain.Features.Vendas;
using DonaLaura.Domain.Features.Vendas.Exceptions;
using FluentAssertions;
using NUnit.Framework;
using System;
using Moq;
using System.Collections.Generic;
using DonaLaura.Common.Tests.Features;
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
            //Arrange
            Produto produto = new Produto();
            Venda venda = ObjectMother.getQuantidadeMenorOuIgualZeroVenda();
            venda.Id = 1;
            venda.Produto = produto;

            //Action
            Action action = () => venda.Validate();

            //Verify
            action.Should().Throw<QuantidadeMenorOuIgualZeroException>();
        }

        [Test]
        public void Venda_NomeNuloOuVazio_DeveRetornarExcecao()
        {
            //Arrange
            Produto produto = new Produto();
            Venda venda = ObjectMother.getNomeNuloOuVazioVenda();
            venda.Id = 1;
            venda.Produto = produto;

            //Action
            Action action = () => venda.Validate();

            //Verify
            action.Should().Throw<NomeNuloOuVazioException>();
        }

        [Test]
        public void Venda_DeveSerValido()
        {
            //Arrange
            Produto produto = new Produto();
            Venda venda = ObjectMother.getValidoVenda();
            venda.Id = 1;
            venda.Produto = produto;

            //Action
            Action action = () => venda.Validate();

            //Verify
            action.Should().NotThrow();
        }
    }
}
