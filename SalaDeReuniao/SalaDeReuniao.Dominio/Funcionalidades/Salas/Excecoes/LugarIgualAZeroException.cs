using SalaDeReuniao.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaDeReuniao.Dominio.Funcionalidades.Salas.Excecoes
{
    public class LugarIgualAZeroException : ExcecaoDeNegocio
    {
        public LugarIgualAZeroException() : base("O número de lugares não pode ser igual a zero.")
        {
        }
    }
}
