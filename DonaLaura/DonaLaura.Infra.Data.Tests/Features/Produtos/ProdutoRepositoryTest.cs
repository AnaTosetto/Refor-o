using DonaLaura.Common.Tests.Base;
using DonaLaura.Common.Tests.Features;
using DonaLaura.Dominio.Features.Produtos;
using DonaLaura.Infra.Data.Features.Produtos;
using FluentAssertions;
using NUnit.Framework;
using System;

using DonaLaura.Domain.Exceptions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DonaLaura.Infra.Data.Tests.Features.Produtos
{
    public class ProdutoRepositoryTest
    {
        ProdutoRepository _produtoRepository;

        [SetUp]
        public void TestSetup()
        {
             ProdutoBaseSqlTest.SeedDatabase();
            _produtoRepository = new ProdutoRepository();
        }

        [Test]
        public void ProdutoRepository_Adicionar_DeveRetornarOK()
        {
            //Arrange
            int id = 0;
            Produto produto = ObjectMother.getValidoProduto();
            produto.Id = id;

            //Action
            produto = _produtoRepository.Adicionar(produto);

            //Verify
            produto.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void ProdutoRepository_Atualizar_DeveRetornarOk()
        {
            //Arrange
            int id = 1;
            Produto produto = ObjectMother.getValidoProduto();
            produto.Id = id;

            //Action
            produto = _produtoRepository.Atualizar(produto);

            //Verify
            produto.Id.Should().Be(produto.Id);
        }

        [Test]
        public void ProdutoRepository_Atualizar_DeveRetornarExcecao()
        {
            //Arrange
            long id = 0;
            Produto produto = ObjectMother.getValidoProduto();
            produto.Id = id;

            //Action
            Action acaoResultado = () => _produtoRepository.Atualizar(produto);

            //Verify
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void ProdutoRepository_Excluir_DeveRetornarOk()
        {
            //Arrange
            Produto produto = ObjectMother.getValidoProduto();
            produto.Id = 1;

            //Action
            _produtoRepository.Excluir(produto);
        }

        [Test]
        public void ProdutoRepository_Excluir_DeveRetornarExcecao()
        {
            //Arrange
            Produto produto = ObjectMother.getValidoProduto();
            produto.Id = 0;

            //Action
            Action acaoResultado = () => _produtoRepository.Excluir(produto);

            //Verify
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void ProdutoRepository_Obter_DeveRetornarOk()
        {
            //Arrange
            Produto produto = new Produto();
            produto.Id = 1;

            //Action
            produto = _produtoRepository.Obter(produto.Id);
        }

        [Test]
        public void ProdutoRepository_Obter_DeveRetornarExcecao()
        {
            //Arrange
            Produto produto = new Produto();
            produto.Id = 0;

            //Action
            Action acaoResultado = () => _produtoRepository.Obter(produto.Id);

            //Verify
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void ProdutoRepository_ObterTudo_DeveRetornarOk()
        {
            //Arrange
            IEnumerable<Produto> listaProduto;

            //Action
            listaProduto = _produtoRepository.ObterTudo();

            //Verify
            listaProduto.Should().NotBeNull();
            listaProduto.First<Produto>().Id.Should().Be(1);
        }
    }
}
