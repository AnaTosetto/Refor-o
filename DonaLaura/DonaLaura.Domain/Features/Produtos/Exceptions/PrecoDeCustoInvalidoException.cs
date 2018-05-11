using DonaLaura.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Produtos.Exceptions
{
    public class PrecoDeCustoInvalidoException : NegocioException
    {
        public PrecoDeCustoInvalidoException() : base("O preço de custo deve ser menor que o preço de venda.")
        {
        }
    }
}
