using DonaLaura.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Produtos.Exceptions
{
    public class NomeNuloOuVazioException : NegocioException
    {
        public NomeNuloOuVazioException() : base("O nome não pode ser nulo ou vazio.")
        {
        }
    }
}
