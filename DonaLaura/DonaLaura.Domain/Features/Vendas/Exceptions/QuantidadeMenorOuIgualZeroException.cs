using DonaLaura.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Vendas.Exceptions
{
    public class QuantidadeMenorOuIgualZeroException : NegocioException
    {
        public QuantidadeMenorOuIgualZeroException(): base("Quantidade do produto deve ser maior que zero.")
        {
        }
    }
}
