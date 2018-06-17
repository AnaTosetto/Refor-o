using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Dominio.Excecoes
{
    public class IdentificadorIndefinidoExcecao : ExcecaoDeNegocio
    {
        public IdentificadorIndefinidoExcecao() : base("O id não pode ser vazio.")
        {
        }
    }
}
