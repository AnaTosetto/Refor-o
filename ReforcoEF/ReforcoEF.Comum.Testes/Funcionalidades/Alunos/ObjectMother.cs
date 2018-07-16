using ReforcoEF.Dominio.Funcionalidades.Alunos;
using ReforcoEF.Dominio.Funcionalidades.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReforcoEF.Comum.Testes.Funcionalidades
{
    public partial class ObjectMother
    {
        public static Aluno ObterAlunoValido(Endereco endereco)
        {
            return new Aluno
            {
                Nome = "Ana",
                Endereco = endereco
            };
        }
    }
}
