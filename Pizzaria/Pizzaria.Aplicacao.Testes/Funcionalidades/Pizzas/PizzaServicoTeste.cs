using FluentAssertions;
using Moq;
using NUnit.Framework;
using Pizzaria.Comum.Testes.Funcionalidades.Pizzas;
using Pizzaria.Dominio.Enum;
using Pizzaria.Dominio.Excecoes;
using Pizzaria.Dominio.Funcionalidades.Pizzas;
using Pizzaria.Dominio.Funcionalidades.Pizzas.Excecoes;
using Pizzaria.Funcionalidades.Pizzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Aplicacao.Testes.Funcionalidades.Pizzas
{
    [TestFixture]
    public class PizzaServicoTeste
    {
        private PizzaServico _pizzaServico;

        private Mock<IPizzaRepositorio> _mockPizzaRepositorio;

        [SetUp]
        public void IniciarCenario()
        {
            _mockPizzaRepositorio = new Mock<IPizzaRepositorio>();
            _pizzaServico = new PizzaServico(_mockPizzaRepositorio.Object);
        }

        [Test]
        public void Pizza_Aplicacao_Adicionar_DeveSerValido()
        {
            Pizza pizza = ObjectMother.ObterPizzaValida();

            _mockPizzaRepositorio.Setup(rp => rp.Adicionar(pizza)).Returns(new Pizza { Id = 1, Nome = "Nome pizza", Ingredientes = "Ingredientes Pizza", Tipo = TipoEnum.Doce, DataFabricacao = DateTime.Now, QuantidadeFatias = 3, Custo = 4 });

            Pizza retorno = _pizzaServico.Adicionar(pizza);

            _mockPizzaRepositorio.Verify(rp => rp.Adicionar(pizza));
            retorno.Should().NotBeNull();
            retorno.Id.Should().BeGreaterThan(0);           
        }

        [Test]
        public void Pizza_Aplicacao_Adicionar_NomeNuloOuVazio_DeveRetornarExcecao()
        {
            Pizza pizza = ObjectMother.ObterPizzaInvalida_NomeNuloOuVazio();

            _mockPizzaRepositorio.Setup(rp => rp.Adicionar(pizza)).Returns(new Pizza { Id = 1, Nome = "Nome pizza", Ingredientes = "Ingredientes Pizza", Tipo = TipoEnum.Doce, DataFabricacao = DateTime.Now, QuantidadeFatias = 3, Custo = 4 });

            Action acaoComExcecao = () => _pizzaServico.Adicionar(pizza);

            acaoComExcecao.Should().Throw<NomeNuloOuVazioExcecao>();
            _mockPizzaRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Pizza_Aplicacao_Adicionar_NomeComMinimoDeCaracteres_DeveRetornarExcecao()
        {
            Pizza pizza = ObjectMother.ObterPizzaInvalida_NomeComMinimoDeCaracteres();

            _mockPizzaRepositorio.Setup(rp => rp.Adicionar(pizza)).Returns(new Pizza { Id = 1, Nome = "Nome pizza", Ingredientes = "Ingredientes Pizza", Tipo = TipoEnum.Doce, DataFabricacao = DateTime.Now, QuantidadeFatias = 3, Custo = 4 });

            Action acaoComExcecao = () => _pizzaServico.Adicionar(pizza);

            acaoComExcecao.Should().Throw<NomeComMinimoDeCaracteresExcecao>();
            _mockPizzaRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Pizza_Aplicacao_Adicionar_SemIngredientes_DeveRetornarExcecao()
        {
            Pizza pizza = ObjectMother.ObterPizzaInvalida_SemIngredientes();

            _mockPizzaRepositorio.Setup(rp => rp.Adicionar(pizza)).Returns(new Pizza { Id = 1, Nome = "Nome pizza", Ingredientes = "Ingredientes Pizza", Tipo = TipoEnum.Doce, DataFabricacao = DateTime.Now, QuantidadeFatias = 3, Custo = 4 });

            Action acaoComExcecao = () => _pizzaServico.Adicionar(pizza);

            acaoComExcecao.Should().Throw<SemIngredientesExcecao>();
            _mockPizzaRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Pizza_Aplicacao_Adicionar_QuantidadeDeFatiasMenorQueUm_DeveRetornarExcecao()
        {
            Pizza pizza = ObjectMother.ObterPizzaInvalida_QuantidadeDeFatiasMenorQueUm();

            _mockPizzaRepositorio.Setup(rp => rp.Adicionar(pizza)).Returns(new Pizza { Id = 1, Nome = "Nome pizza", Ingredientes = "Ingredientes Pizza", Tipo = TipoEnum.Doce, DataFabricacao = DateTime.Now, QuantidadeFatias = 3, Custo = 4 });

            Action acaoComExcecao = () => _pizzaServico.Adicionar(pizza);

            acaoComExcecao.Should().Throw<QuantidadeDeFatiasMenorQueUmExcecao>();
            _mockPizzaRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Pizza_Aplicacao_Atualizar_DeveSerValido()
        {
            Pizza pizza = ObjectMother.ObterPizzaValida();
            pizza.Id = 1;

            _mockPizzaRepositorio.Setup(rp => rp.Atualizar(pizza)).Returns(new Pizza { Id = pizza.Id, Nome = "Nome pizza", Ingredientes = "Ingredientes Pizza", Tipo = TipoEnum.Doce, DataFabricacao = DateTime.Now, QuantidadeFatias = 3, Custo = 4 });

            Pizza retorno = _pizzaServico.Atualizar(pizza);

            retorno.Should().NotBeNull();
            retorno.Id.Should().Be(pizza.Id);
        }

        [Test]
        public void Pizza_Aplicacao_Atualizar_IdMenorQueUm_DeveRetornarExcecao()
        {
            Pizza pizza = ObjectMother.ObterPizzaValida();
            pizza.Id = 0;

            _mockPizzaRepositorio.Setup(rp => rp.Atualizar(pizza)).Returns(new Pizza { Id = 1, Nome = "Nome pizza", Ingredientes = "Ingredientes Pizza", Tipo = TipoEnum.Doce, DataFabricacao = DateTime.Now, QuantidadeFatias = 3, Custo = 4 });

            Action acaoComExcecao = () => _pizzaServico.Atualizar(pizza);

            acaoComExcecao.Should().Throw<IdentificadorIndefinidoExcecao>();
            _mockPizzaRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Pizza_Aplicacao_Excluir_DeveSerValido()
        {
            Pizza pizza = ObjectMother.ObterPizzaValida();
            pizza.Id = 1;

            _mockPizzaRepositorio.Setup(rp => rp.Excluir(pizza));

            _pizzaServico.Excluir(pizza);

            _mockPizzaRepositorio.Verify(rp => rp.Excluir(pizza));
        }

        [Test]
        public void Pizza_Aplicacao_Excluir_IdMenorQueUm_DeveRetornarExcecao()
        {
            Pizza pizza = ObjectMother.ObterPizzaValida();
            pizza.Id = 0;

            _mockPizzaRepositorio.Setup(rp => rp.Excluir(pizza));

            Action acaoComExcecao = () =>_pizzaServico.Excluir(pizza);

            acaoComExcecao.Should().Throw<IdentificadorIndefinidoExcecao>();
            _mockPizzaRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Pizza_Aplicacao_Buscar_DeveSerValido()
        {
            Pizza pizza = ObjectMother.ObterPizzaValida();
            pizza.Id = 1;

            _mockPizzaRepositorio.Setup(rp => rp.Buscar(pizza.Id)).Returns(new Pizza { Id = 1, Nome = "Nome pizza", Ingredientes = "Ingredientes Pizza", Tipo = TipoEnum.Doce, DataFabricacao = DateTime.Now, QuantidadeFatias = 3, Custo = 4 });

            Pizza retorno = _pizzaServico.Buscar(pizza.Id);

            _mockPizzaRepositorio.Verify(rp => rp.Buscar(pizza.Id));

            retorno.Should().NotBeNull();
            retorno.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Pizza_Aplicacao_Buscar_IdMenorQueUm_DeveRetornarExcecao()
        {
            Pizza pizza = ObjectMother.ObterPizzaValida();
            pizza.Id = 0;

            _mockPizzaRepositorio.Setup(rp => rp.Buscar(pizza.Id));
            
            Action acaoComExcecao = () => _pizzaServico.Buscar(pizza.Id);

            acaoComExcecao.Should().Throw<IdentificadorIndefinidoExcecao>();
            _mockPizzaRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Pizza_Aplicacao_BuscarTodos_DeveSerValido()
        {
            _mockPizzaRepositorio.Setup(rp => rp.BuscarTodos()).Returns(Enumerable.Empty<Pizza>);

            IEnumerable<Pizza> retorno = _pizzaServico.BuscarTodos();

            foreach(Pizza pizza in retorno)
            {
                pizza.Id.Should().BeGreaterThan(0);
                pizza.Should().NotBeNull();
            }

            _mockPizzaRepositorio.Verify(rp => rp.BuscarTodos());
        }

    }
}
