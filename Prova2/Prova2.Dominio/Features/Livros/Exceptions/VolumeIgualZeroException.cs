using Prova2.Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Dominio.Features.Livros.Exceptions
{
    public class VolumeIgualZeroException : NegocioException
    {
        public VolumeIgualZeroException() : base("O volume deve ser maior que zero.")
        {
        }
    }
}
