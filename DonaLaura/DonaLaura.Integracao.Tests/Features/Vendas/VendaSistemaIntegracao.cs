using DonaLaura.Aplicacao.Features.Vendas;
using DonaLaura.Common.Tests.Features.Vendas;
using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Features.Vendas;
using DonaLaura.Domain.Features.Vendas.Exceptions;
using DonaLaura.Dominio.Features.Produtos;
using DonaLaura.Infra.Data.Features.Vendas;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DonaLaura.Integracao.Tests.Features.Vendas
{
    public class VendaSistemaIntegracao
    {
        VendaRepository _vendaRepository = new VendaRepository();

        VendaService _vendaService;

        [SetUp]
        public void TestSetup()
        {
            _vendaService = new VendaService(_vendaRepository);
        }

        [Test]
        public void VendaSistemaIntegracao_Adicionar_DeveRetornarOk()
        {
            //Cenário 
            Produto produto = new Produto();
            produto.Id = 1;
            produto.Disponibilidade = true;
            produto.DataValidade = DateTime.Now.AddDays(2);
            Venda venda = ObjectMother.getValidoVenda(produto);
            venda.Id = 0;
            venda.Produto = produto;



            IEnumerable<Venda> timelineAntes = _vendaService.ObtemTudo();

            //Acão
            Venda vendaResultado = _vendaService.Adiciona(venda);

            //Verificar
            vendaResultado.Should().NotBeNull();
            vendaResultado.Id.Should().BeGreaterThan(0);
            vendaResultado.NomeCliente.Should().Be(venda.NomeCliente);
            vendaResultado.Quantidade.Should().Be(venda.Quantidade);
            //vendaResultado.Lucro.Should().Be(venda.Lucro);
            vendaResultado.Produto.Id.Should().Be(venda.Produto.Id);

            Venda vendaGet = _vendaService.Obtem(vendaResultado.Id);

            vendaResultado.Id.Should().Be(vendaGet.Id);

            IEnumerable<Venda> timelineDepois = _vendaService.ObtemTudo();

            timelineDepois.Should().NotBeEmpty();
            timelineDepois.Count().Should().BeGreaterThan(timelineAntes.Count());

            _vendaService.Exclui(vendaResultado);
        }

        [Test]
        public void VendaSistemaIntegracao_Adicionar_NomeNuloOuVazio_DeveRetornarExcecao()
        {
            //Cenário
            Produto produto = new Produto();
            long idProduto = 1;
            produto.Id = idProduto;
            Venda venda = ObjectMother.getNomeNuloOuVazioVenda(produto);
            venda.Id = 0;
            venda.Produto = produto;

            //Acão
            Action acaoResultado = () => _vendaService.Adiciona(venda);

            //Verificar
            acaoResultado.Should().Throw<NomeNuloOuVazioException>();
        }

        [Test]
        public void VendaSistemaIntegracao_Adicionar_QuantidadeMenorOuIgualZero_DeveRetornarExcecao()
        {
            //Cenário
            Produto produto = new Produto();
            long idProduto = 1;
            produto.Id = idProduto;
            Venda venda = ObjectMother.getQuantidadeMenorOuIgualZeroVenda(produto);
            venda.Id = 0;
            venda.Produto = produto;

            //Acão
            Action acaoResultado = () => _vendaService.Adiciona(venda);

            //Verificar
            acaoResultado.Should().Throw<QuantidadeMenorOuIgualZeroException>();
        }

        [Test]
        public void VendaSistemaIntegracao_Adicionar_ProdutoIndisponivelNoEstoque_DeveRetornarExcecao()
        {
            //Cenário
            Produto produto = new Produto();
            produto.Id = 1;
            produto.Disponibilidade = false;
            Venda venda = ObjectMother.getValidoVenda(produto);
            venda.Id = 0;
            venda.Produto = produto;

            //Acão
            Action acaoResultado = () => _vendaService.Adiciona(venda);

            //Verificar
            acaoResultado.Should().Throw<ProdutoIndisponivelEmEstoqueException>();
        }

        [Test]
        public void VendaSistemaIntegracao_Adicionar_ProdutoForaDaDataDeValidade_DeveRetornarExcecao()
        {
            //Cenário
            Produto produto = new Produto();
            produto.Id = 1;
            produto.DataValidade = DateTime.Now.AddDays(-2);
            produto.Disponibilidade = true;
            Venda venda = ObjectMother.getValidoVenda(produto);
            venda.Id = 0;
            venda.Produto = produto;

            //Acão
            Action acaoResultado = () => _vendaService.Adiciona(venda);

            //Verificar
            acaoResultado.Should().Throw<ProdutoForaDaDataDeValidadeException>();
        }

        [Test]
        public void VendaSistemaIntegracao_Atualizar_DeveRetornarOk()
        {
            //Cenário
            Venda vendaParaEditar = _vendaService.Obtem(1);
            vendaParaEditar.Id = 1;
            vendaParaEditar.Produto.Disponibilidade = true;
            vendaParaEditar.Produto.DataValidade = DateTime.Now.AddDays(2);
            string vendaVelha = vendaParaEditar.NomeCliente;
            string novaVenda = "Venda";

            if (vendaVelha == novaVenda)
            {
                novaVenda = "Nova venda";
            }

            vendaParaEditar.NomeCliente = novaVenda;

            //Acão
            Venda vendaResultado = _vendaService.Atualiza(vendaParaEditar);

            //Verificar
            vendaResultado.NomeCliente.Should().NotBe(vendaVelha);
            vendaResultado.Id.Should().Be(vendaParaEditar.Id);
        }

        [Test]
        public void VendaSistemaIntegracao_Atualizar_DeveRetornarExcecao()
        {
            //Cenário
            Produto produto = new Produto();
            produto.Id = 1;
            produto.Disponibilidade = true;
            produto.DataValidade = DateTime.Now.AddDays(2);
            Venda venda = ObjectMother.getValidoVenda(produto);
            venda.Id = 0;
            venda.Produto = produto;

            //Acão
            Action acaoResultado = () => _vendaService.Atualiza(venda);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void VendaSistemaIntegracao_Excluir_DeveRetornarOk()
        {
            //Cenário
            Produto produto = new Produto();
            produto.Id = 1;
            produto.Disponibilidade = true;
            produto.DataValidade = DateTime.Now.AddDays(2);
            Venda venda = ObjectMother.getValidoVenda(produto);
            venda.Id = 0;
            venda.Produto = produto;
            

            venda = _vendaService.Adiciona(venda);

            //Acão
            _vendaService.Exclui(venda);

            //Verificar
            Venda vendaInexistente = _vendaService.Obtem(venda.Id);
            vendaInexistente.Should().BeNull();
        }

        [Test]
        public void VendaSistemaIntegracao_Excluir_DeveRetornarExcecao()
        {
            //Cenário
            Produto produto = new Produto();
            long idProduto = 1;
            produto.Id = idProduto;
            Venda venda = ObjectMother.getValidoVenda(produto);
            venda.Id = 0;
            venda.Produto = produto;

            //Acão
            Action acaoResultado = () => _vendaService.Exclui(venda);

            //Verificar
            acaoResultado.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void VendaSistemaIntegracao_Obter_DeveRetornarOk()
        {
            //Cenário
            Produto produto = new Produto();
            produto.Id = 1;
            produto.Disponibilidade = true;
            produto.PrecoCusto = 2;
            produto.PrecoVenda = 4;
            produto.DataValidade = DateTime.Now.AddDays(2);
            produto.DataFabricacao = DateTime.Now.AddDays(-3);
            Venda venda = ObjectMother.getValidoVenda(produto);
            venda.Id = 1;
            venda.Produto = produto;

            //Acão
            venda = _vendaService.Obtem(venda.Id);

            //Verificar
            venda.Id.Should().Be(1);
            venda.Should().NotBeNull();
        }

        [Test]
        public void VendaSistemaIntegracao_Obter_DeveRetornarExcecao()
        {
            //Acão
            Venda vendaResultado = _vendaService.Obtem(9999999999999);

            //Verificar
            vendaResultado.Should().BeNull();
        }

        [Test]
        public void VendaSistemaIntegracao_ObterTudo_DeveRetornarOk()
        {
            //Cenário
            IEnumerable<Venda> listaVenda;

            //Acão
            listaVenda = _vendaService.ObtemTudo();

            //Verificar
            listaVenda.Should().NotBeNull();
            listaVenda.Count().Should().BeGreaterOrEqualTo(0);
        }

    }
}
