using DonaLaura.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Features.Produtos.Exceptions
{
    public class CaracteresMinimoException : NegocioException
    {
        public CaracteresMinimoException() : base("O nome não pode ter menos de 4 caracteres.")
        {
        }
    }
}
