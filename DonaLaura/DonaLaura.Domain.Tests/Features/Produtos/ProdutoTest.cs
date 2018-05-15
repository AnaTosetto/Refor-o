using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using NUnit.Framework;
using DonaLaura.Domain.Features.Produtos.Exceptions;
using DonaLaura.Domain.Exceptions;
using DonaLaura.Common.Tests.Features.Produtos;
using DonaLaura.Dominio.Features.Produtos;

namespace DonaLaura.Domain.Tests
{
    [TestFixture]
    public class ProdutoTest
    {
        [Test]
        public void Produto_NomeMenorQue4_DeveRetornarExcecao()
        {
            //Cenário
            Produto produto = ObjectMother.getCaracteresMinimoNomeProduto();
            produto.Id = 1;

            //Acão
            Action action = () => produto.Validate();

            //Verificar
            action.Should().Throw<CaracteresMinimoException>();
        }

        [Test]
        public void Produto_NomeNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Produto produto = ObjectMother.getNuloOuVazioNomeProduto();
            produto.Id = 1;

            //Acão
            Action action = () => produto.Validate();

            //Verificar
            action.Should().Throw<NomeNuloOuVazioException>();
        }

        [Test]
        public void Produto_DataDeValidadeInvalida_DeveRetornarExcecao()
        {
            //Cenário
            Produto produto = ObjectMother.getDataDeValidadeInvalidaProduto();
            produto.Id = 1;

            //Acão
            Action action = () => produto.Validate();

            //Verificar
            action.Should().Throw<DataDeValidadeInvalidaException>();
        }

        [Test]
        public void Produto_PrecoDeCustoInvalido_DeveRetornarExcecao()
        {
            //Cenário
            Produto produto = ObjectMother.getPrecoDeCustoInvalidoProduto();
            produto.Id = 1;

            //Acão
            Action action = () => produto.Validate();
            
            //Verificar
            action.Should().Throw<PrecoDeCustoInvalidoException>();
        }

        [Test]
        public void Produto_DeveSerValido()
        {
            //Cenário
            Produto produto = ObjectMother.getValidoProduto();
            produto.Id = 1;

            //Acão
            Action action = () => produto.Validate();

            //Verificar
            action.Should().NotThrow();
        }

        [Test]
        public void Produto_DataDeFabricacaoInvalida_DeveRetornarExcecao()
        {
            //Cenário
            Produto produto = ObjectMother.getDataDeFabricacaoInvalidaProduto();
            produto.Id = 1;

            //Acão
            Action action = () => produto.Validate();

            //Verificar
            action.Should().Throw<DataDeFabricacaoInvalidaException>();
        }
    }
}
