using Pizzaria.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Dominio.Funcionalidades.Entregas.Excecoes
{
    public class ValorTotalMenorQueUmExcecao : ExcecaoDeNegocio
    {
        public ValorTotalMenorQueUmExcecao() : base("Valor Total não pode ser menor ou igual a zero.")
        {
        }
    }
}
