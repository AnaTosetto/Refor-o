using ReforcoEF.Dominio.Funcionalidades.Materias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReforcoEF.Comum.Testes.Funcionalidades
{
    public partial class ObjectMother
    {
        public static Materia ObterMateriaValido()
        {
            return new Materia
            {
                Nome = "portugues"
            };
        }
    }
}
