using ReforcoEF.Dominio.Funcionalidades.Alunos;
using ReforcoEF.Dominio.Funcionalidades.Resultados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReforcoEF.Comum.Testes.Funcionalidades
{
    public partial class ObjectMother
    {
        public static Resultado ObterResultadoValido(Aluno aluno)
        {
            return new Resultado
            {
                Nota = 4,
                Aluno = aluno
            };
        }
    }
}
