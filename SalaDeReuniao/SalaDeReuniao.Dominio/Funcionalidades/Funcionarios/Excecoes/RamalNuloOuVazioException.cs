using SalaDeReuniao.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Dominio.Funcionalidades.Funcionarios.Excecoes
{
    public class RamalNuloOuVazioException : ExcecaoDeNegocio
    {
        public RamalNuloOuVazioException() : base("O ramal do funcionário não pode ser nulo.")
        {
        }
    }
}
