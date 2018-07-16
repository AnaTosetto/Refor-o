using ReforcoEF.Dominio.Funcionalidades.Alunos;
using ReforcoEF.Infra.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReforcoEF.Infra.Data.Funcionalidades.Alunos
{
    public class AlunoRepositorioSQL : IAlunoRepositorio
    {
        ReforcoEFContexto _reforcoEFContexto;

        public AlunoRepositorioSQL(ReforcoEFContexto reforcoEFContexto)
        {
            _reforcoEFContexto = reforcoEFContexto;
        }

        public Aluno Adicionar(Aluno aluno)
        {
           aluno = _reforcoEFContexto.Alunos.Add(aluno);
            _reforcoEFContexto.SaveChanges();

            return aluno;
        }

        public Aluno Buscar(int id)
        {
            Aluno aluno = _reforcoEFContexto.Alunos.Find(id);
            return aluno;
        }

        public IList<Aluno> BuscarTodos()
        {
            return _reforcoEFContexto.Alunos.ToList();
        }

        public Aluno Editar(Aluno aluno)
        {
            _reforcoEFContexto.SaveChanges();
            return aluno;
        }

        public void Excluir(Aluno aluno)
        {
            _reforcoEFContexto.Alunos.Remove(aluno);
            _reforcoEFContexto.SaveChanges();
        }
    }
}
