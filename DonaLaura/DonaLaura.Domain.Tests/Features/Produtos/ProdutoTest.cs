using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using NUnit.Framework;
using DonaLaura.Domain.Features.Produtos.Exceptions;
using DonaLaura.Common.Tests.Features.Produtos;

namespace DonaLaura.Domain.Tests
{
    [TestFixture]
    public class ProdutoTest
    {
        [Test]
        public void Produto_NomeMenorQue4_DeveRetornarExcecao()
        {
            Produto produto = ObjectMother.getCaracteresMinimoNomeProduto();
            produto.Id = 1;

            Action action = () => produto.Validate();

            action.Should().Throw<CaracteresMinimoException>();
        }

        [Test]
        public void Produto_NomeNuloOuVazio_DeveRetornarExcecao()
        {
            Produto produto = ObjectMother.getNuloOuVazioNomeProduto();
            produto.Id = 1;

            Action action = () => produto.Validate();

            action.Should().Throw<NomeNuloOuVazioException>();
        }

        [Test]
        public void Produto_DataDeValidadeInvalida_DeveRetornarExcecao()
        {
            Produto produto = ObjectMother.getDataDeValidadeInvalidaProduto();
            produto.Id = 1;

            Action action = () => produto.Validate();

            action.Should().Throw<DataDeValidadeInvalidaException>();
        }

        [Test]
        public void Produto_PrecoDeCustoInvalido_DeveRetornarExcecao()
        {
            Produto produto = ObjectMother.getPrecoDeCustoInvalidoProduto();
            produto.Id = 1;

            Action action = () => produto.Validate();

            action.Should().Throw<PrecoDeCustoInvalidoException>();
        }

        [Test]
        public void Produto_DeveSerValido()
        {
            Produto produto = ObjectMother.getValidoProduto();
            produto.Id = 1;

            Action action = () => produto.Validate();

            action.Should().NotThrow();
        }
    }
}
