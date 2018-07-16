using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTDD.Dominio.Base
{
    public interface IRepositorio<T> where T : Entidade
    {
        T Adicionar(T entidade);
        T Editar(T entidade);
        T Buscar(int id);
        IList<T> BuscarTodos();
        void Excluir(T entidade);
    }
}
