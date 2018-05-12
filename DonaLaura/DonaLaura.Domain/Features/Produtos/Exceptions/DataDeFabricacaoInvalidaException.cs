using DonaLaura.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Produtos.Exceptions
{
    public class DataDeFabricacaoInvalidaException : NegocioException
    {
        public DataDeFabricacaoInvalidaException() : base("A data de fabricação não pode ser maior que a data atual.")
        {
        }
    }
}
