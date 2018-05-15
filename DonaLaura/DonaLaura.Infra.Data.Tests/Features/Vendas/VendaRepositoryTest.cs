using DonaLaura.Common.Tests.Base;
using DonaLaura.Common.Tests.Features.Vendas;
using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Features.Vendas;
using DonaLaura.Dominio.Features.Produtos;
using DonaLaura.Infra.Data.Features.Vendas;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DonaLaura.Infra.Data.Tests.Features.Vendas
{
    public class VendaRepositoryTest
    {
        VendaRepository _vendaRepository;

        [SetUp]
        public void TestSetup()
        {
            VendaBaseSqlTest.SeedDatabase();
            _vendaRepository = new VendaRepository();
        }

        [Test]
        public void VendaRepository_Adicionar_DeveRetornarOk()
        {
            //Cenário
            Produto produto = new Produto();
            long idProduto = 1;
            produto.Id = idProduto;
            long id = 0;
            Venda venda = ObjectMother.getValidoVenda(produto);
            venda.Id = id;
            venda.Produto = produto;

            //Acão
            venda = _vendaRepository.Adicionar(venda);

            //Verificar
            venda.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void VendaRepository_Atualizar_DeveRetornarOk()
        {
            //Cenário
            Produto produto = new Produto();
            long idProduto = 1;
            produto.Id = idProduto;
            long id = 1;
            Venda venda = ObjectMother.getValidoVenda(produto);
            venda.Id = id;
            venda.Produto = produto;

            //Acão
            venda = _vendaRepository.Atualizar(venda);

            //Verificar
            venda.Id.Should().Be(venda.Id);
        }

        [Test]
        public void VendaRepository_Atualizar_DeveRetornarExcecao()
        {
            //Cenário
            Produto produto = new Produto();
            long idProduto = 1;
            produto.Id = idProduto;
            long id = 0;
            Venda venda = ObjectMother.getValidoVenda(produto);
            venda.Id = id;
            venda.Produto = produto;

            //Acão
            Action acaoResultado = () => _vendaRepository.Atualizar(venda);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void VendaRepository_Excluir_DeveRetornarOk()
        {
            //Cenário
            Produto produto = new Produto();
            long idProduto = 1;
            produto.Id = idProduto;
            long id = 1;
            Venda venda = ObjectMother.getValidoVenda(produto);
            venda.Id = id;
            venda.Produto = produto;

            //Acão
            _vendaRepository.Excluir(venda);
        }

        [Test]
        public void VendaRepository_Excluir_DeveRetornarExcecao()
        {
            //Cenário
            Produto produto = new Produto();
            long idProduto = 1;
            produto.Id = idProduto;
            long id = 0;
            Venda venda = ObjectMother.getValidoVenda(produto);
            venda.Id = id;
            venda.Produto = produto;

            //Acão
            Action acaoResultado = () => _vendaRepository.Excluir(venda);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void VendaRepository_Obter_DeveRetornarOk()
        {
            //Cenário
            Venda venda = new Venda();
            venda.Id = 1;

            //Acão
            venda = _vendaRepository.Obter(venda.Id);
        }

        [Test]
        public void VendaRepository_Obter_DeveRetornarExcecao()
        {
            //Cenário
            Venda venda = new Venda();
            venda.Id = 0;

            //Acão
            Action acaoResultado = () => _vendaRepository.Obter(venda.Id);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void VendaRepository_ObterTudo_DeveRetornarExcecao()
        {
            //Cenário
            IEnumerable<Venda> listaVenda;

            //Acão
            listaVenda = _vendaRepository.ObterTudo();

            //Verificar
            listaVenda.Should().NotBeNull();
            listaVenda.First<Venda>().Id.Should().Be(1);

        }
    }
}
