using Pizzaria.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Dominio.Funcionalidades.Pizzas.Excecoes
{
    public class NomeComMinimoDeCaracteresExcecao : ExcecaoDeNegocio
    {
        public NomeComMinimoDeCaracteresExcecao() : base("O nome da pizza precisa ter mais de 5 caracteres.")
        {
        }
    }
}
