using ProvaTDD.Dominio.Base;
using ProvaTDD.Dominio.Funcionalidades.Enderecos;
using ProvaTDD.Dominio.Funcionalidades.Resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTDD.Dominio.Funcionalidades.Alunos
{
    public class Aluno : Entidade
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public double Media { get; set; }
        public virtual IList<Resultado> Resultados { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
