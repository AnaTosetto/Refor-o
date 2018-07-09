using FluentAssertions;
using Moq;
using NUnit.Framework;
using Pizzaria.Comum.Testes.Funcionalidades.Entregas;
using Pizzaria.Dominio.Enum;
using Pizzaria.Dominio.Funcionalidades.Entregas;
using Pizzaria.Dominio.Funcionalidades.Entregas.Excecoes;
using Pizzaria.Dominio.Funcionalidades.Pizzas;
using Pizzaria.Funcionalidades.Entregas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Aplicacao.Testes.Funcionalidades.Entregas
{
    [TestFixture]
    public class EntregaServicoTeste
    {
        private EntregaServico _entregaServico;

        private Mock<IEntregaRepositorio> _mockEntregaRepositorio;

        [SetUp]
        public void IniciarCenario()
        {
            _mockEntregaRepositorio = new Mock<IEntregaRepositorio>();
            _entregaServico = new EntregaServico(_mockEntregaRepositorio.Object);          
        }

        [Test]
        public void Entrega_Aplicacao_Adicionar_DeveSerValido()
        {
            Pizza pizza = new Pizza();
            pizza.Id = 1;

            Entrega entrega = ObjectMother.ObterEntregaValida();
            entrega.Pizza = pizza;

            _mockEntregaRepositorio.Setup(rp => rp.Adicionar(entrega)).Returns(new Entrega { Id = 1, NomeCliente = "Nome Cliente", Pizza = pizza, Entregar = TipoEntregaEnum.NOBALCAO, ValorTotal = 10 });

            Entrega retorno = _entregaServico.Adicionar(entrega);

            retorno.Should().NotBeNull();
            retorno.Id.Should().BeGreaterThan(0);
            _mockEntregaRepositorio.Verify(rp => rp.Adicionar(entrega));
        }

        [Test]
        public void Entrega_Aplicacao_Adicionar_NomeClienteNuloOuVazio_DeveRetornarExcecao()
        {
            Pizza pizza = new Pizza();
            pizza.Id = 1;

            Entrega entrega = ObjectMother.ObterEntregaInvalida_NomeClienteNuloOuVazio();
            entrega.Pizza = pizza;

            _mockEntregaRepositorio.Setup(rp => rp.Adicionar(entrega));

            Action acaoComExcecao = () => _entregaServico.Adicionar(entrega);

            acaoComExcecao.Should().Throw<NomeClienteNuloOuVazioExcecao>();
            _mockEntregaRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Entrega_Aplicacao_Adicionar_ValorTotalMenorQueUm_DeveRetornarExcecao()
        {
            Pizza pizza = new Pizza();
            pizza.Id = 1;

            Entrega entrega = ObjectMother.ObterEntregaInvalida_ValorTotalMenorQueUm();
            entrega.Pizza = pizza;

            _mockEntregaRepositorio.Setup(rp => rp.Adicionar(entrega));

            Action acaoComExcecao = () => _entregaServico.Adicionar(entrega);

            acaoComExcecao.Should().Throw<ValorTotalMenorQueUmExcecao>();
            _mockEntregaRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Entrega_Aplicacao_Adicionar_SemPizza_DeveRetornarExcecao()
        {
            Entrega entrega = ObjectMother.ObterEntregaValida();

            _mockEntregaRepositorio.Setup(rp => rp.Adicionar(entrega));

            Action acaoComExcecao = () => _entregaServico.Adicionar(entrega);

            acaoComExcecao.Should().Throw<SemPizzaExcecao>();
            _mockEntregaRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Entrega_Aplicacao_Atualizar_DeveSerValido()
        {
            Pizza pizza = new Pizza();
            pizza.Id = 1;

            Entrega entrega = ObjectMother.ObterEntregaValida();
            entrega.Pizza = pizza;

            _mockEntregaRepositorio.Setup(rp => rp.Atualizar(entrega)).Returns(new Entrega { Id = entrega.Id, NomeCliente = "Nome Cliente", Pizza = pizza, Entregar = TipoEntregaEnum.NOBALCAO, ValorTotal = 10 });

            Entrega retorno = _entregaServico.Atualizar(entrega);

            retorno.Should().NotBeNull();
            retorno.Id.Should().BeGreaterThan(0);
            _mockEntregaRepositorio.Verify(rp => rp.Atualizar(entrega));

        }
    }
}
