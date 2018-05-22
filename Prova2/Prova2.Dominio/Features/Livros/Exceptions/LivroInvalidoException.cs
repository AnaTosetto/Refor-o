using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Dominio.Features.Livros.Exceptions
{
    public class LivroInvalidoException : Exception
    {
        public LivroInvalidoException(string message) : base(message)
        {
        }
    }
}
