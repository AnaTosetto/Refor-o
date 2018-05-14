using DonaLaura.Common.Tests.Base;
using DonaLaura.Common.Tests.Features;
using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Features.Vendas;
using DonaLaura.Dominio.Features.Produtos;
using DonaLaura.Infra.Data.Features.Vendas;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //Arrange
            Produto produto = new Produto();
            long idProduto = 1;
            produto.Id = idProduto;
            long id = 0;
            Venda venda = ObjectMother.getValidoVenda();
            venda.Id = id;
            venda.Produto = produto;

            //Action
            venda = _vendaRepository.Adicionar(venda);

            //Verify
            venda.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void VendaRepository_Atualizar_DeveRetornarOk()
        {
            //Arrange
            Produto produto = new Produto();
            long idProduto = 1;
            produto.Id = idProduto;
            long id = 1;
            Venda venda = ObjectMother.getValidoVenda();
            venda.Id = id;
            venda.Produto = produto;

            //Action
            venda = _vendaRepository.Atualizar(venda);

            //Verify
            venda.Id.Should().Be(venda.Id);
        }

        [Test]
        public void VendaRepository_Atualizar_DeveRetornarExcecao()
        {
            //Arrange
            Produto produto = new Produto();
            long idProduto = 1;
            produto.Id = idProduto;
            long id = 0;
            Venda venda = ObjectMother.getValidoVenda();
            venda.Id = id;
            venda.Produto = produto;

            //Action
            Action acaoResultado = () => _vendaRepository.Atualizar(venda);

            //Verify
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void VendaRepository_Excluir_DeveRetornarOk()
        {
            //Arrange
            Produto produto = new Produto();
            long idProduto = 1;
            produto.Id = idProduto;
            long id = 1;
            Venda venda = ObjectMother.getValidoVenda();
            venda.Id = id;
            venda.Produto = produto;

            //Action
            _vendaRepository.Excluir(venda);
        }

        [Test]
        public void VendaRepository_Excluir_DeveRetornarExcecao()
        {
            //Arrange
            Produto produto = new Produto();
            long idProduto = 1;
            produto.Id = idProduto;
            long id = 0;
            Venda venda = ObjectMother.getValidoVenda();
            venda.Id = id;
            venda.Produto = produto;

            //Action
            Action acaoResultado = () => _vendaRepository.Excluir(venda);

            //Verify
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void VendaRepository_Obter_DeveRetornarOk()
        {
            //Arrange
            Venda venda = new Venda();
            venda.Id = 1;

            //Action
            venda = _vendaRepository.Obter(venda.Id);
        }

        [Test]
        public void VendaRepository_Obter_DeveRetornarExcecao()
        {
            //Arrange
            Venda venda = new Venda();
            venda.Id = 0;

            //Action
            Action acaoResultado = () => _vendaRepository.Obter(venda.Id);

            //Verify
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void VendaRepository_ObterTudo_DeveRetornarExcecao()
        {
            //Arrange
            IEnumerable<Venda> listaVenda;

            //Action
            listaVenda = _vendaRepository.ObterTudo();

            //Verify
            listaVenda.Should().NotBeNull();
            listaVenda.First<Venda>().Id.Should().Be(1);

        }
    }
}
