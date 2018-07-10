using ProvaTDD.Dominio.Funcionalidades.Resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTDD.Dominio.Funcionalidades.Alunos
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public double Media { get; set; }
        public List<Resultado> Resultados { get; set; }
    }
}
