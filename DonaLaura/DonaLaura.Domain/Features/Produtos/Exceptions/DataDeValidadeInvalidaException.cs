using DonaLaura.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Produtos.Exceptions
{
    public class DataDeValidadeInvalidaException : NegocioException
    {
        public DataDeValidadeInvalidaException() : base("A data de validade deve ser maior que a data de fabricação.")
        {
        }
    }
}
