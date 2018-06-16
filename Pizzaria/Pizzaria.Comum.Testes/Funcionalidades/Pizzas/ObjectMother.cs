using Pizzaria.Dominio.Enum;
using Pizzaria.Dominio.Funcionalidades.Pizzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Comum.Testes.Funcionalidades.Pizzas
{
    public static partial class ObjectMother
    {
        public static Pizza ObterPizzaValida()
        {
            return new Pizza()
            {
                Nome = "4 Queijos",
                Ingredientes = "Ingredientes",
                Tipo = TipoEnum.Salgada,
                DataFabricacao = DateTime.Now,
                QuantidadeFatias = 4,
                Custo = 4.50
            };
        }

        public static Pizza ObterPizzaInvalida_NomeComMinimoDeCaracteres()
        {
            return new Pizza()
            {
                Nome = "Pizza",
                Ingredientes = "Ingredientes",
                Tipo = TipoEnum.Salgada,
                DataFabricacao = DateTime.Now,
                QuantidadeFatias = 4,
                Custo = 4.50
            };
        }

        public static Pizza ObterPizzaInvalida_NomeNuloOuVazio()
        {
            return new Pizza()
            {
                Nome = "",
                Ingredientes = "Ingredientes",
                Tipo = TipoEnum.Salgada,
                DataFabricacao = DateTime.Now,
                QuantidadeFatias = 4,
                Custo = 4.50
            };
        }

        public static Pizza ObterPizzaInvalida_SemIngredientes()
        {
            return new Pizza()
            {
                Nome = "4 Queijos",
                Ingredientes = "",
                Tipo = TipoEnum.Salgada,
                DataFabricacao = DateTime.Now,
                QuantidadeFatias = 4,
                Custo = 4.50
            };
        }

        public static Pizza ObterPizzaInvalida_QuantidadeDeFatiasMenorQueUm()
        {
            return new Pizza()
            {
                Nome = "4 Queijos",
                Ingredientes = "Ingredientes",
                Tipo = TipoEnum.Salgada,
                DataFabricacao = DateTime.Now,
                QuantidadeFatias = 0,
                Custo = 4.50
            };
        }
    }
}
