using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Exceptions
{
    public class NomeNuloOuVazioException : NegocioException
    {
        public NomeNuloOuVazioException() : base("O nome não pode ser nulo ou vazio.")
        {
        }
    }
}
