using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Dominio.Excecoes
{
    public class IdentificadorIndefinidoException : ExcecaoDeNegocio
    {
        public IdentificadorIndefinidoException() : base("O id não pode ser vazio.")
        {
        }
    }
}
