using ProvaTDD.Dominio.Base;
using ProvaTDD.Dominio.Funcionalidades.Alunos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTDD.Dominio.Funcionalidades.Enderecos
{
    public class Endereco : Entidade
    {
        public int Numero { get; set; }
        public string Rua { get; set; }
        //public virtual Aluno Aluno { get; set; }
    }
}
