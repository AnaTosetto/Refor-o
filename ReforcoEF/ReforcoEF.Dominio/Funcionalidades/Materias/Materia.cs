using ReforcoEF.Dominio.Funcionalidades.Alunos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReforcoEF.Dominio.Funcionalidades.Materias
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual List<Aluno> Alunos { get; set; }

        public Materia()
        {
            Alunos = new List<Aluno>();
        }
    }
}
