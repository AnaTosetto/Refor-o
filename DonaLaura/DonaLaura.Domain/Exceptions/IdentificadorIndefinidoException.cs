using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Exceptions
{
    public class IdentificadorIndefinidoException : NegocioException
    {
        public IdentificadorIndefinidoException() : base("O id não pode ser vazio.")
        {
        }
    }
}
