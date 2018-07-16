using ReforcoEF.Dominio.Funcionalidades.Alunos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReforcoEF.Dominio.Funcionalidades.Resultados
{
    public class Resultado
    {
        public int Id { get; set; }
        public double Nota { get; set; }
        public int AlunoId { get; set; }
        public virtual Aluno Aluno { get; set; }
    }
}
