using Pizzaria.Dominio.Excecoes;
using Pizzaria.Dominio.Funcionalidades.Pizzas;
using Pizzaria.Funcionalidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Funcionalidades.Pizzas
{
    public class PizzaServico : IService<Pizza>
    {
        IPizzaRepositorio _pizzaRepositorio;

        public PizzaServico(IPizzaRepositorio pizzaRepositorio)
        {
            _pizzaRepositorio = pizzaRepositorio;
        }

        public Pizza Adicionar(Pizza pizza)
        {
            pizza.Validar();

            return _pizzaRepositorio.Adicionar(pizza);
        }

        public Pizza Atualizar(Pizza pizza)
        {
            if (pizza.Id < 1)
                throw new IdentificadorIndefinidoExcecao();

                pizza.Validar();

            return _pizzaRepositorio.Atualizar(pizza);
        }

        public Pizza Buscar(int id)
        {
            if (id < 1)
                throw new IdentificadorIndefinidoExcecao();

            return _pizzaRepositorio.Buscar(id);
        }

        public IEnumerable<Pizza> BuscarTodos()
        {
            return _pizzaRepositorio.BuscarTodos();
        }

        public void Excluir(Pizza pizza)
        {
            if (pizza.Id < 1)
                throw new IdentificadorIndefinidoExcecao();

            pizza.Validar();

            _pizzaRepositorio.Excluir(pizza);
        }
    }
}
