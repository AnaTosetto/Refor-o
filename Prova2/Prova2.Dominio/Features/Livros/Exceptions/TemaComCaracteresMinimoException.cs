﻿using Prova2.Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Dominio.Features.Livros.Exceptions
{
    public class TemaComCaracteresMinimoException : NegocioException
    {
        public TemaComCaracteresMinimoException() : base("O tema não pode ter menos de 4 caracteres.")
        {
        }
    }
}
