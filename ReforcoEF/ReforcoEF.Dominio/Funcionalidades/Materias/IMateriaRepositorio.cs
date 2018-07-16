using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReforcoEF.Dominio.Funcionalidades.Materias
{
    public interface IMateriaRepositorio
    {
        Materia Adicionar(Materia materia);
        Materia Editar(Materia materia);
        Materia Buscar(int id);
        IList<Materia> BuscarTodos();
        void Excluir(Materia materia);
    }
}
