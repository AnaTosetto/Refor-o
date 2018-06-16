using FluentAssertions;
using NUnit.Framework;
using Pizzaria.Comum.Testes.Funcionalidades.Pizzas;
using Pizzaria.Dominio.Excecoes;
using Pizzaria.Dominio.Funcionalidades.Pizzas;
using Pizzaria.Dominio.Funcionalidades.Pizzas.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Dominio.Testes.Funcionalidades.Pizzas
{
    [TestFixture]
    public class PizzaTeste
    {
        [Test]
        public void Pizza_Dominio_Validar_DeveSerValido()
        {
            Pizza pizza = ObjectMother.ObterPizzaValida();

            Action acaoSemExcecao = pizza.Validar;

            acaoSemExcecao.Should().NotThrow<ExcecaoDeNegocio>();
        }

        [Test]
        public void Pizza_Dominio_Validar_NomeComMinimoDeCaracteres_DeveRetornarExcecao()
        {
            Pizza pizza = ObjectMother.ObterPizzaInvalida_NomeComMinimoDeCaracteres();

            Action acaoComExcecao = pizza.Validar;

            acaoComExcecao.Should().Throw<NomeComMinimoDeCaracteresExcecao>();
        }

        [Test]
        public void Pizza_Dominio_Validar_NomeNuloOuVazio_DeveRetornarExcecao()
        {
            Pizza pizza = ObjectMother.ObterPizzaInvalida_NomeNuloOuVazio();

            Action acaoComExcecao = pizza.Validar;

            acaoComExcecao.Should().Throw<NomeNuloOuVazioExcecao>();
        }

        [Test]
        public void Pizza_Dominio_Validar_SemIngredientes_DeveRetornarExcecao()
        {
            Pizza pizza = ObjectMother.ObterPizzaInvalida_SemIngredientes();

            Action acaoComExcecao = pizza.Validar;

            acaoComExcecao.Should().Throw<SemIngredientesExcecao>();
        }

        [Test]
        public void Pizza_Dominio_Validar_QuantidadeDeFatiasMenorQueUm_DeveRetornarExcecao()
        {
            Pizza pizza = ObjectMother.ObterPizzaInvalida_QuantidadeDeFatiasMenorQueUm();

            Action acaoComExcecao = pizza.Validar;

            acaoComExcecao.Should().Throw<QuantidadeDeFatiasMenorQueUmExcecao>();
        }
    }
}
