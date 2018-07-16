using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReforcoEF.Dominio.Funcionalidades.Alunos
{
    public interface IAlunoRepositorio
    {
        Aluno Adicionar(Aluno aluno);
        Aluno Editar(Aluno aluno);
        Aluno Buscar(int id);
        IList<Aluno> BuscarTodos();
        void Excluir(Aluno aluno);
    }
}
