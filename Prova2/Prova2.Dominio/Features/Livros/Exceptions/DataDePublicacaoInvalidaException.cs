using Prova2.Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Dominio.Features.Livros.Exceptions
{
    class DataDePublicacaoInvalidaException : NegocioException
    {
        DataDePublicacaoInvalidaException() : base("A data de publicação não pode ser maior que a data atual.")
        {
        }
    }
}
