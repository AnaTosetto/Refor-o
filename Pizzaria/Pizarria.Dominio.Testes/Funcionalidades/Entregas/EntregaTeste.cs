using FluentAssertions;
using Moq;
using NUnit.Framework;
using Pizzaria.Comum.Testes.Funcionalidades.Entregas;
using Pizzaria.Dominio.Excecoes;
using Pizzaria.Dominio.Funcionalidades.Entregas;
using Pizzaria.Dominio.Funcionalidades.Entregas.Excecoes;
using Pizzaria.Dominio.Funcionalidades.Pizzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizarria.Dominio.Testes.Funcionalidades.Entregas
{
    [TestFixture]
    public class EntregaTeste
    {
        private Mock<Pizza> _mockPizza;

        [SetUp]
        public void IniciarCenario()
        {
            _mockPizza = new Mock<Pizza>();
        }

        [Test]
        public void Entrega_Dominio_Validar_DeveSerValido()
        {
            Entrega entrega = ObjectMother.ObterEntregaValida();
            entrega.Pizza = _mockPizza.Object;

            Action acaoSemExcecao = entrega.Validar;

            acaoSemExcecao.Should().NotThrow<ExcecaoDeNegocio>();
        }

        [Test]
        public void Entrega_Dominio_Validar_NomeClienteNuloOuVazio_DeveRetornarExcecao()
        {
            Entrega entrega = ObjectMother.ObterEntregaInvalida_NomeClienteNuloOuVazio();
            entrega.Pizza = _mockPizza.Object;

            Action acaoComExcecao = entrega.Validar;

            acaoComExcecao.Should().Throw<NomeClienteNuloOuVazioExcecao>();
        }

        [Test]
        public void Entrega_Dominio_Validar_ValorTotalMenorQueUm_DeveRetornarExcecao()
        {
            Entrega entrega = ObjectMother.ObterEntregaInvalida_ValorTotalMenorQueUm();
            entrega.Pizza = _mockPizza.Object;

            Action acaoComExcecao = entrega.Validar;

            acaoComExcecao.Should().Throw<ValorTotalMenorQueUmExcecao>();
        }

        [Test]
        public void Entrega_Dominio_Validar_SemPizza_DeveRetornarExcecao()
        {
            Entrega entrega = ObjectMother.ObterEntregaValida();
            entrega.Pizza = null;

            Action acaoComExcecao = entrega.Validar;

            acaoComExcecao.Should().Throw<SemPizzaExcecao>();
        }

        [Test]
        public void Entrega_Dominio_Validar_CalculoValorTotalComTaxaDeEntrega_DeveSerValido()
        {
            _mockPizza.Object.Custo = 4;
            Entrega entrega = ObjectMother.ObterEntregaValida_EntregaEmCasa();
            entrega.Pizza = _mockPizza.Object;

            entrega.CalcularValorTotal();

            entrega.ValorTotal.Should().Be(8.5);
        }

        [Test]
        public void Entrega_Dominio_Validar_CalculoValorTotalSemTaxaDeEntrega_DeveSerValido()
        {
            _mockPizza.Object.Custo = 4;
            Entrega entrega = ObjectMother.ObterEntregaValida();
            entrega.Pizza = _mockPizza.Object;

            entrega.CalcularValorTotal();

            entrega.ValorTotal.Should().Be(4);
        }
    }
}
