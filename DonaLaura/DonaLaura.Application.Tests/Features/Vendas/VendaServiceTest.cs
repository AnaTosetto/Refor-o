using DonaLaura.Aplicacao.Features.Vendas;
using DonaLaura.Common.Tests.Features;
using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Features.Vendas;
using DonaLaura.Domain.Features.Vendas.Exceptions;
using DonaLaura.Dominio.Features.Produtos;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DonaLaura.Application.Tests.Features.Vendas
{
    public class VendaServiceTest
    {
        VendaService _vendaService;

        private Mock<IVendaRepository> _mockVendaRepository;

        [SetUp]
        public void TesteSetup()
        {
            _mockVendaRepository = new Mock<IVendaRepository>();
            _vendaService = new VendaService(_mockVendaRepository.Object);
        }

        [Test]
        public void VendaService_Adiciona_VendaValida_DeveRetornarOk()
        {
            Produto produto = new Produto();
            Venda venda = ObjectMother.getValidoVenda();
            venda.Id = 0;
            venda.Produto = produto;

            _mockVendaRepository.Setup(rp => rp.Adicionar(venda)).Returns(new Venda { Id = 1, NomeCliente = "nome", Produto = produto, Lucro = 3.50, Quantidade = 2 });
            Venda retorno = _vendaService.Adiciona(venda);

            _mockVendaRepository.Verify(rp => rp.Adicionar(venda));

            retorno.Should().NotBeNull();
            retorno.Id.Should().BeGreaterThan(0);
            retorno.Id.Should().NotBe(venda.Id);
        }

        [Test]
        public void VendaService_Adiciona_NomeNuloOuVazio_DeveRetornarExcecao()
        {
            Produto produto = new Produto();
            Venda venda = ObjectMother.getNomeNuloOuVazioVenda();
            venda.Id = 0;
            venda.Produto = produto;

            _mockVendaRepository.Setup(rp => rp.Adicionar(venda)).Returns(new Venda { Id = 1, NomeCliente = "nome", Produto = produto, Lucro = 3.50, Quantidade = 2 });

            Action acaoRetorno = () => _vendaService.Adiciona(venda);

            acaoRetorno.Should().Throw<NomeNuloOuVazioException>();

            _mockVendaRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void VendaService_Adiciona_QuantidadeMenorOuIgualZero_DeveRetornarExcecao()
        {
            Produto produto = new Produto();
            Venda venda = ObjectMother.getQuantidadeMenorOuIgualZeroVenda();
            venda.Id = 0;
            venda.Produto = produto;

            _mockVendaRepository.Setup(rp => rp.Adicionar(venda)).Returns(new Venda { Id = 1, NomeCliente = "nome", Produto = produto, Lucro = 3.50, Quantidade = 2 });

            Action acaoRetorno = () => _vendaService.Adiciona(venda);

            acaoRetorno.Should().Throw<QuantidadeMenorOuIgualZeroException>();

            _mockVendaRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void VendaService_Atualiza_VendaValida_DeveRetornarOk()
        {
            Produto produto = new Produto();
            Venda venda = ObjectMother.getValidoVenda();
            venda.Id = 1;
            venda.Produto = produto;

            _mockVendaRepository.Setup(rp => rp.Atualizar(venda)).Returns(new Venda { Id = venda.Id, NomeCliente = "nome", Produto = produto, Lucro = 3.50, Quantidade = 2 });
            Venda retorno = _vendaService.Atualiza(venda);

            _mockVendaRepository.Verify(rp => rp.Atualizar(venda));
            retorno.Should().NotBeNull();
            retorno.Id.Should().Be(venda.Id);
        }

        [Test]
        public void VendaService_Exclui_VendaValida_DeveRetornarOk()
        {
            Produto produto = new Produto();
            Venda venda = ObjectMother.getValidoVenda();
            venda.Id = 1;
            venda.Produto = produto;

            _mockVendaRepository.Setup(rp => rp.Excluir(venda));

            _vendaService.Exclui(venda);

            _mockVendaRepository.Verify(rp => rp.Excluir(venda));
        }

        [Test]
        public void VendaService_Obtem_VendaValida_DeveRetornarOk()
        {
            Produto produto = new Produto();
            Venda venda = ObjectMother.getValidoVenda();
            venda.Id = 1;
            venda.Produto = produto;

            _mockVendaRepository.Setup(rp => rp.Obter(venda.Id)).Returns(new Venda { Id = 1, NomeCliente = "nome", Produto = produto, Lucro = 3.50, Quantidade = 2 });
            Venda retorno = _vendaService.Obtem(venda.Id);

            _mockVendaRepository.Verify(rp => rp.Obter(venda.Id));

            retorno.Should().NotBeNull();
            retorno.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void VendaService_ObtemTudo_VendaValida_DeveRetornarOk()
        {
            _mockVendaRepository.Setup(rp => rp.ObterTudo()).Returns(Enumerable.Empty<Venda>);
            IEnumerable<Venda> retorno = _vendaService.ObtemTudo();

            foreach (Venda venda in retorno)
            {
                venda.Id.Should().BeGreaterThan(0);
                venda.Should().NotBeNull();
            }

            _mockVendaRepository.Verify(rp => rp.ObterTudo());
        }
    }
}
