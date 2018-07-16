using ProvaTDD.Dominio.Funcionalidades.Alunos;
using ProvaTDD.Infra.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTDD.Infra.Data.Funcionalidades.Alunos
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        ProvaContexto _provaContexto;

        public AlunoRepositorio(ProvaContexto provaContexto)
        {
            _provaContexto = provaContexto;
        }

        public Aluno Adicionar(Aluno aluno)
        {
            aluno = _provaContexto.Alunos.Add(aluno);
            _provaContexto.SaveChanges();
            return aluno;
        }

        public Aluno Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Aluno> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public Aluno Editar(Aluno aluno)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Aluno aluno)
        {
            throw new NotImplementedException();
        }
    }
}
