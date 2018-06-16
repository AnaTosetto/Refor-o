using Pizzaria.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Dominio.Funcionalidades.Entregas.Excecoes
{
    public class NomeClienteNuloOuVazioExcecao : ExcecaoDeNegocio
    {
        public NomeClienteNuloOuVazioExcecao() : base("Nome do cliente não pode ser nulo ou vazio.")
        {
        }
    }
}
