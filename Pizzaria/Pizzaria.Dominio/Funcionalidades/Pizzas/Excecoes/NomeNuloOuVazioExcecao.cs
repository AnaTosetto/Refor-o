using Pizzaria.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Dominio.Funcionalidades.Pizzas.Excecoes
{
    public class NomeNuloOuVazioExcecao : ExcecaoDeNegocio
    {
        public NomeNuloOuVazioExcecao() : base("Deve conter o nome da pizza.")
        {
        }
    }
}
