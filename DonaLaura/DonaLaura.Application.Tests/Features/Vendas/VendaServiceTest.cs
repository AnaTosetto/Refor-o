using DonaLaura.Aplicacao.Features.Vendas;
using DonaLaura.Common.Tests.Features;
using DonaLaura.Common.Tests.Features.Vendas;
using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Features.Vendas;
using DonaLaura.Domain.Features.Vendas.Exceptions;
using DonaLaura.Dominio.Features.Produtos;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DonaLaura.Application.Tests.Features.Vendas
{
    public class VendaServiceTest
    {
        VendaService _vendaService;

        private Mock<IVendaRepository> _mockVendaRepository;
        private Mock<Produto> _mockProduto;

        [SetUp]
        public void TesteSetup()
        {
            _mockVendaRepository = new Mock<IVendaRepository>();
            _vendaService = new VendaService(_mockVendaRepository.Object);
            _mockProduto = new Mock<Produto>();
        }

        [Test]
        public void VendaService_Adiciona_VendaValida_DeveRetornarOk()
        {
            //Cenário
            Venda venda = ObjectMother.getValidoVenda(_mockProduto.Object);
            venda.Id = 0;

            //Ação
            _mockVendaRepository.Setup(rp => rp.Adicionar(venda)).Returns(new Venda { Id = 1, NomeCliente = "nome", Produto = _mockProduto.Object, Quantidade = 2 });
            Venda retorno = _vendaService.Adiciona(venda);

            //Verificar
            _mockVendaRepository.Verify(rp => rp.Adicionar(venda));

            retorno.Should().NotBeNull();
            retorno.Id.Should().BeGreaterThan(0);
            retorno.Id.Should().NotBe(venda.Id);
        }

        [Test]
        public void VendaService_Adiciona_NomeNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Venda venda = ObjectMother.getNomeNuloOuVazioVenda(_mockProduto.Object);
            venda.Id = 0;

            //Ação
            _mockVendaRepository.Setup(rp => rp.Adicionar(venda)).Returns(new Venda { Id = 1, NomeCliente = "nome", Produto = _mockProduto.Object, Quantidade = 2 });

            Action acaoRetorno = () => _vendaService.Adiciona(venda);

            //Verificar
            acaoRetorno.Should().Throw<NomeNuloOuVazioException>();

            _mockVendaRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void VendaService_Adiciona_QuantidadeMenorOuIgualZero_DeveRetornarExcecao()
        {
            //Cenário
            Venda venda = ObjectMother.getQuantidadeMenorOuIgualZeroVenda(_mockProduto.Object);
            venda.Id = 0;

            //Ação
            _mockVendaRepository.Setup(rp => rp.Adicionar(venda)).Returns(new Venda { Id = 1, NomeCliente = "nome", Produto = _mockProduto.Object, Quantidade = 2 });

            Action acaoRetorno = () => _vendaService.Adiciona(venda);

            //Verificar
            acaoRetorno.Should().Throw<QuantidadeMenorOuIgualZeroException>();

            _mockVendaRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void VendaService_Atualiza_VendaValida_DeveRetornarOk()
        {
            //Cenário
            Venda venda = ObjectMother.getValidoVenda(_mockProduto.Object);
            venda.Id = 1;

            //Ação
            _mockVendaRepository.Setup(rp => rp.Atualizar(venda)).Returns(new Venda { Id = venda.Id, NomeCliente = "nome", Produto = _mockProduto.Object, Quantidade = 2 });
            Venda retorno = _vendaService.Atualiza(venda);

            //Verificar
            _mockVendaRepository.Verify(rp => rp.Atualizar(venda));
            retorno.Should().NotBeNull();
            retorno.Id.Should().Be(venda.Id);
        }

        [Test]
        public void VendaService_Exclui_VendaValida_DeveRetornarOk()
        {
            //Cenário
            Venda venda = ObjectMother.getValidoVenda(_mockProduto.Object);
            venda.Id = 1;

            //Ação
            _mockVendaRepository.Setup(rp => rp.Excluir(venda));

            _vendaService.Exclui(venda);

            //Verificar
            _mockVendaRepository.Verify(rp => rp.Excluir(venda));
        }

        [Test]
        public void VendaService_Obtem_VendaValida_DeveRetornarOk()
        {
            //Cenário
            Venda venda = ObjectMother.getValidoVenda(_mockProduto.Object);
            venda.Id = 1;

            //Ação
            _mockVendaRepository.Setup(rp => rp.Obter(venda.Id)).Returns(new Venda { Id = 1, NomeCliente = "nome", Produto = _mockProduto.Object, Quantidade = 2 });
            Venda retorno = _vendaService.Obtem(venda.Id);

            //Verificar
            _mockVendaRepository.Verify(rp => rp.Obter(venda.Id));

            retorno.Should().NotBeNull();
            retorno.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void VendaService_ObtemTudo_VendaValida_DeveRetornarOk()
        {
            //Ação
            _mockVendaRepository.Setup(rp => rp.ObterTudo()).Returns(Enumerable.Empty<Venda>);
            IEnumerable<Venda> retorno = _vendaService.ObtemTudo();
            
            //Verificar
            foreach (Venda venda in retorno)
            {
                venda.Id.Should().BeGreaterThan(0);
                venda.Should().NotBeNull();
            }

            _mockVendaRepository.Verify(rp => rp.ObterTudo());
        }
    }
}
