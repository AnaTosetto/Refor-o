using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using NUnit.Framework;
using DonaLaura.Domain.Features.Produtos.Exceptions;
using DonaLaura.Domain.Exceptions;
using DonaLaura.Common.Tests.Features;
using DonaLaura.Dominio.Features.Produtos;

namespace DonaLaura.Domain.Tests
{
    [TestFixture]
    public class ProdutoTest
    {
        [Test]
        public void Produto_NomeMenorQue4_DeveRetornarExcecao()
        {
            //Arrange
            Produto produto = ObjectMother.getCaracteresMinimoNomeProduto();
            produto.Id = 1;

            //Action
            Action action = () => produto.Validate();

            //Verify
            action.Should().Throw<CaracteresMinimoException>();
        }

        [Test]
        public void Produto_NomeNuloOuVazio_DeveRetornarExcecao()
        {
            //Arrange
            Produto produto = ObjectMother.getNuloOuVazioNomeProduto();
            produto.Id = 1;

            //Action
            Action action = () => produto.Validate();

            //Verify
            action.Should().Throw<NomeNuloOuVazioException>();
        }

        [Test]
        public void Produto_DataDeValidadeInvalida_DeveRetornarExcecao()
        {
            //Arrange
            Produto produto = ObjectMother.getDataDeValidadeInvalidaProduto();
            produto.Id = 1;

            //Action
            Action action = () => produto.Validate();

            //Verify
            action.Should().Throw<DataDeValidadeInvalidaException>();
        }

        [Test]
        public void Produto_PrecoDeCustoInvalido_DeveRetornarExcecao()
        {
            //Arrange
            Produto produto = ObjectMother.getPrecoDeCustoInvalidoProduto();
            produto.Id = 1;

            //Action
            Action action = () => produto.Validate();
            
            //Verify
            action.Should().Throw<PrecoDeCustoInvalidoException>();
        }

        [Test]
        public void Produto_DeveSerValido()
        {
            //Arrange
            Produto produto = ObjectMother.getValidoProduto();
            produto.Id = 1;

            //Action
            Action action = () => produto.Validate();

            //Verify
            action.Should().NotThrow();
        }

        [Test]
        public void Produto_DataDeFabricacaoInvalida_DeveRetornarExcecao()
        {
            //Arrange
            Produto produto = ObjectMother.getDataDeFabricacaoInvalidaProduto();
            produto.Id = 1;

            //Action
            Action action = () => produto.Validate();

            //Verify
            action.Should().Throw<DataDeFabricacaoInvalidaException>();
        }
    }
}
