using DonaLaura.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Vendas.Exceptions
{
    public class ProdutoForaDaDataDeValidadeException : NegocioException
    {
        public ProdutoForaDaDataDeValidadeException() : base("Produto está fora da data data de validade.")
        {
        }
    }
}
