using ReforcoEF.Dominio.Funcionalidades.Enderecos;
using ReforcoEF.Dominio.Funcionalidades.Materias;
using ReforcoEF.Dominio.Funcionalidades.Resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReforcoEF.Dominio.Funcionalidades.Alunos
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public virtual List<Resultado> Resultados { get; set; }
        public virtual List<Materia> Materias { get; set; }

        public Aluno()
        {
            Resultados = new List<Resultado>();
            Materias = new List<Materia>();
        }
    }
}
