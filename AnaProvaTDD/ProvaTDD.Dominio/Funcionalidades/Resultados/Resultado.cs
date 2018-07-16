using ProvaTDD.Dominio.Base;
using ProvaTDD.Dominio.Funcionalidades.Alunos;
using ProvaTDD.Dominio.Funcionalidades.Avaliacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTDD.Dominio.Funcionalidades.Resultados
{
    public class Resultado : Entidade
    {
        public double Nota { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual Avaliacao Avaliacao { get; set; }
    }
}
