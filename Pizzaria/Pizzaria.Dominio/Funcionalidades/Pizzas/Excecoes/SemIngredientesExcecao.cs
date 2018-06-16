using Pizzaria.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Dominio.Funcionalidades.Pizzas.Excecoes
{
    public class SemIngredientesExcecao : ExcecaoDeNegocio
    {
        public SemIngredientesExcecao() : base("Deve conter os ingredientes da pizza.")
        {
        }
    }
}
