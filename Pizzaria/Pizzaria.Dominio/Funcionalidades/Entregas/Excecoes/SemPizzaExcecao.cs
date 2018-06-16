using Pizzaria.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Dominio.Funcionalidades.Entregas.Excecoes
{
    public class SemPizzaExcecao : ExcecaoDeNegocio
    {
        public SemPizzaExcecao() : base("Precisa conter uma pizza na entrega.")
        {
        }
    }
}
