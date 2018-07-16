using ReforcoEF.Dominio.Funcionalidades.Alunos;
using ReforcoEF.Dominio.Funcionalidades.Materias;
using ReforcoEF.Dominio.Funcionalidades.Resultados;
using ReforcoEF.Infra.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReforcoEF.Infra.Data.Funcionalidades.Materias
{
    public class MateriaRepositorioSQL : IMateriaRepositorio
    {
        ReforcoEFContexto _reforcoEFContexto;

        public MateriaRepositorioSQL(ReforcoEFContexto reforcoEFContexto)
        {
            _reforcoEFContexto = reforcoEFContexto;
        }

        public Materia Adicionar(Materia materia)
        {
            materia = _reforcoEFContexto.Materias.Add(materia);
            _reforcoEFContexto.SaveChanges();

            return materia;
        }

        public Materia Buscar(int id)
        {
            Materia materia = _reforcoEFContexto.Materias.Find(id);
            return materia;
        }

        public IList<Materia> BuscarTodos()
        {
            return _reforcoEFContexto.Materias.ToList();
        }

        public Materia Editar(Materia materia)
        {
            _reforcoEFContexto.SaveChanges();
            return materia;
        }

        public void Excluir(Materia materia)
        {
            _reforcoEFContexto.Materias.Remove(materia);
            _reforcoEFContexto.SaveChanges();
        }
    }
}
