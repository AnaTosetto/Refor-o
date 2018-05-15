using DonaLaura.Common.Tests.Base;
using DonaLaura.Common.Tests.Features.Produtos;
using DonaLaura.Dominio.Features.Produtos;
using DonaLaura.Infra.Data.Features.Produtos;
using FluentAssertions;
using NUnit.Framework;
using System;
using DonaLaura.Domain.Exceptions;
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
            //Cenário
            int id = 0;
            Produto produto = ObjectMother.getValidoProduto();
            produto.Id = id;

            //Acão
            produto = _produtoRepository.Adicionar(produto);

            //Verificar
            produto.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void ProdutoRepository_Atualizar_DeveRetornarOk()
        {
            //Cenário
            int id = 1;
            Produto produto = ObjectMother.getValidoProduto();
            produto.Id = id;

            //Acão
            produto = _produtoRepository.Atualizar(produto);

            //Verificar
            produto.Id.Should().Be(produto.Id);
        }

        [Test]
        public void ProdutoRepository_Atualizar_DeveRetornarExcecao()
        {
            //Cenário
            long id = 0;
            Produto produto = ObjectMother.getValidoProduto();
            produto.Id = id;

            //Acão
            Action acaoResultado = () => _produtoRepository.Atualizar(produto);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void ProdutoRepository_Excluir_DeveRetornarOk()
        {
            //Cenário
            Produto produto = ObjectMother.getValidoProduto();
            produto.Id = 1;

            //Acão
            _produtoRepository.Excluir(produto);
        }

        [Test]
        public void ProdutoRepository_Excluir_DeveRetornarExcecao()
        {
            //Cenário
            Produto produto = ObjectMother.getValidoProduto();
            produto.Id = 0;

            //Acão
            Action acaoResultado = () => _produtoRepository.Excluir(produto);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void ProdutoRepository_Obter_DeveRetornarOk()
        {
            //Cenário
            Produto produto = new Produto();
            produto.Id = 1;

            //Acão
            produto = _produtoRepository.Obter(produto.Id);
        }

        [Test]
        public void ProdutoRepository_Obter_DeveRetornarExcecao()
        {
            //Cenário
            Produto produto = new Produto();
            produto.Id = 0;

            //Acão
            Action acaoResultado = () => _produtoRepository.Obter(produto.Id);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void ProdutoRepository_ObterTudo_DeveRetornarOk()
        {
            //Cenário
            IEnumerable<Produto> listaProduto;

            //Acão
            listaProduto = _produtoRepository.ObterTudo();

            //Verificar
            listaProduto.Should().NotBeNull();
            listaProduto.First<Produto>().Id.Should().Be(1);
        }
    }
}
