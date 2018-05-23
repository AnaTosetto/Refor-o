using Prova2.Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Dominio.Features.Emprestimos.Exceptions
{
    public class NomeNuloOuVazioException : NegocioException
    {
        public NomeNuloOuVazioException() : base("O nome não pode ser nulo ou vazio.")
        {
        }
    }
}
