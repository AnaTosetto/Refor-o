using ProvaTDD.Dominio.Funcionalidades.Alunos;
using ProvaTDD.Dominio.Funcionalidades.Avaliacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTDD.Dominio.Funcionalidades.Resultados
{
    public class Resultado
    {
        public int Id { get; set; }
        public double Nota { get; set; }
        public Aluno Aluno { get; set; }
        public Avaliacao Avaliacao { get; set; }
    }
}
