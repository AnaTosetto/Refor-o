using Pizzaria.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Dominio.Funcionalidades.Pizzas.Excecoes
{
    public class QuantidadeDeFatiasMenorQueUmExcecao : ExcecaoDeNegocio
    {
        public QuantidadeDeFatiasMenorQueUmExcecao() : base("Quantidade de fatias deve ser maior que zero.")
        {
        }
    }
}
